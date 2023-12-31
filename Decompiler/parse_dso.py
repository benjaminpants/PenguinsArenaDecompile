from __future__ import print_function
import sys
import struct
import argparse
import os
import shutil

from decompile import decompile


class DSOFile:
    def __init__(self, path):
        with open(path, 'rb') as f:
            self.version, = struct.unpack("I", f.read(4))
            size, = struct.unpack("I", f.read(4))
            self.global_string_table = f.read(size)
            size, = struct.unpack("I", f.read(4))
            self.function_string_table = f.read(size)
            self.global_float_table = []
            self.function_float_table = []
            self.read_floats(f)
            self.code = []
            self.linebreak_pairs = []
            self.read_code(f)
            self.patch_string_references(f)

    @staticmethod
    def dump_string_table(st):
        return [s.encode('string_escape') for s in st.split("\x00")]

    def read_floats(self, fd):
        """
        Read the file's Float Tables.
        """
        def read_float_table(ft_size, fd):
            ft = []
            for i in range(0, ft_size):
                f, = struct.unpack("d", fd.read(8))
                ft.append(f)
            return ft

        size, = struct.unpack("I", fd.read(4))
        if size > 0:
            self.global_float_table = read_float_table(size, fd)
        size, = struct.unpack("I", fd.read(4))
        if size > 0:
            self.function_float_table = read_float_table(size, fd)

    def read_code(self, fd):
        """
        Reads the file's bytecode.
        """
        (code_size, line_break_pair_count) = struct.unpack("II", fd.read(8))
        # The code size is a number of opcodes and arguments, not a number of bytes.
        count = 0
        while count < code_size:
            value, = struct.unpack("B", fd.read(1))
            count += 1
            if value == 0xFF:
                value = struct.unpack("I", fd.read(4))[0]
            self.code.append(value)

        count = 0
        while count < line_break_pair_count * 2:
            value, = struct.unpack("I", fd.read(4))
            count += 1
            self.linebreak_pairs.append(value)

    def get_string(self, offset, in_function=False):
        """
        Returns the value located at the given offset in a stringtable.
        """
        if not in_function:
            st = self.global_string_table
        else:
            st = self.function_string_table
        return st[offset:st.find("\x00", offset)].rstrip("\n")

    def get_float(self, pos, in_function = False):
        """
        Returns the value located at the given position in a FloatTable.
        """
        if not in_function:
            ft = self.global_float_table
        else:
            ft = self.function_float_table
        return ft[pos]

    def patch_string_references(self, fd):
        """
        The IdentTable contains a list of code locations where each String is used.
        Their offset into the StringTable has to be patched in the code where zero values
        have been set as placeholders.
        """
        size, = struct.unpack("I", fd.read(4))
        for i in range(0, size):
            offset, count = struct.unpack("II", fd.read(8))
            for j in range(0, count):
                location_to_patch, = struct.unpack("I", fd.read(4))
                self.code[location_to_patch] = offset


def main():
    parser = argparse.ArgumentParser(description="Decompile DSO files.")
    parser.add_argument("file", metavar='file', nargs="+", help="The DSO file to decompile.")
    parser.add_argument("--stdout", action="store_true", help="Dump the decompiled script to stdout.")
    args = parser.parse_args()
    for f in args.file:
        # Verify that the file exists.
        if not os.path.exists(f):
            print("{!] Error: could not find %s" % f, file=sys.stderr)
            continue

        # Set the output filename
        if args.stdout:
            out = sys.stdout
        else:
            if f.endswith(".cs.dso"):
                outfile = f[:-4]  # file.cs.dso -> file.cs
            else:
                outfile = "%s.cs" % f  # file -> file.cs
            out = open(outfile, 'w')

        # Create a backup of the original DSO in case the decompiled one is broken.
        if not os.path.exists("%s.bak" % f) and not args.stdout:
            shutil.copy(f, "%s.bak" % f)
        else:
            f = "%s.bak" % f  # Work on the original DSO instead of possibly decompiling our own file.

        # Decompile the file
        dso = DSOFile(sys.argv[1])
        try:
            decompile(dso, sink=out)
        except Exception:
            exc_type, exc_value, tb = sys.exc_info()
            if tb is not None:
                prev = tb
                curr = tb.tb_next
                while curr is not None:
                    prev = curr
                    curr = curr.tb_next
                    if "ip" in prev.tb_frame.f_locals and "offset" in prev.tb_frame.f_locals:
                        break
                if "ip" in prev.tb_frame.f_locals:
                    ip = prev.tb_frame.f_locals["ip"]
                    opcode = prev.tb_frame.f_locals["opcode"]
                    print("Error encountered at ip=%d (%s) while decompiling %s." % (ip, opcode, f), file=sys.stderr)
                out.close()
                if not args.stdout:
                    os.remove(outfile)
            raise
        if not args.stdout:
            out.close()
            print("%s successfully decompiled to %s." % (f, outfile))


if __name__ == "__main__":
    main()