from parse_dso import DSOFile
from torque_vm_values import get_opcode
import sys

file1 = DSOFile(sys.argv[1])
file2 = DSOFile(sys.argv[2])

excessive = False

if len(sys.argv) == 4:
    if sys.argv[3] == "excessive":
        excessive = True

if file1.global_string_table != file2.global_string_table:
    print("GST: Different")
    print("F1:")
    print(DSOFile.dump_string_table(file1.global_string_table))
    print("F2:")
    print(DSOFile.dump_string_table(file2.global_string_table))

if file1.function_string_table != file2.function_string_table:
    print("FST: Different")
    print("F1:")
    print(DSOFile.dump_string_table(file1.function_string_table))
    print("F2:")
    print(DSOFile.dump_string_table(file2.function_string_table))

if file1.global_float_table != file2.global_float_table:
    print("GFT: Different")

if file1.function_float_table != file2.function_float_table:
    print("FFT: Different")

if file1.code != file2.code:
    print("Code: Different")
    if len(file1.code) < len(file2.code):
        size = len(file1.code)
    else:
        size = len(file2.code)
    
    correct = 0
    wrong = 0

    for i in range(0, size):
        if get_opcode(file1.version, file1.code[i]) != get_opcode(file2.version, file2.code[i]):
            if excessive:
                print("Diff " + str(i) + " " + str(get_opcode(file1.version, file1.code[i])) + " " + str(get_opcode(file2.version, file2.code[i])))
            wrong = wrong + 1
        else:
            correct = correct + 1

    print("Code is " + str(float(correct) / float(wrong)) + "% correct")