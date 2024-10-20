datablock ShapeBaseImageData(TopObjectData1)
{
	shapeFile = "~/data/shapes/objects/objectT1.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
};
datablock ShapeBaseImageData(TopObjectData2)
{
	shapeFile = "~/data/shapes/objects/objectT2.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
};
datablock ShapeBaseImageData(TopObjectData3)
{
	shapeFile = "~/data/shapes/objects/objectT3.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
};
datablock ShapeBaseImageData(TopObjectData4)
{
	shapeFile = "~/data/shapes/objects/objectT4.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
};
datablock ShapeBaseImageData(TopObjectData5)
{
	shapeFile = "~/data/shapes/objects/objectT5.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
};
datablock ShapeBaseImageData(TopObjectData6)
{
	shapeFile = "~/data/shapes/objects/objectT6.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
};
datablock ShapeBaseImageData(TopObjectData7)
{
	shapeFile = "~/data/shapes/objects/objectT7.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
};
datablock ShapeBaseImageData(TopObjectData8)
{
	shapeFile = "~/data/shapes/objects/objectT8.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
};
datablock ShapeBaseImageData(TopObjectData9)
{
	shapeFile = "~/data/shapes/objects/objectT9.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
};
datablock ShapeBaseImageData(TopObjectData10)
{
	shapeFile = "~/data/shapes/objects/objectT10.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
};
datablock ShapeBaseImageData(TopObjectData11)
{
	shapeFile = "~/data/shapes/objects/objectT11.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
};
datablock ShapeBaseImageData(TopObjectData12)
{
	shapeFile = "~/data/shapes/objects/objectT12.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
};
datablock ShapeBaseImageData(TopObjectData13)
{
	shapeFile = "~/data/shapes/objects/objectT13.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 7;
};
datablock ShapeBaseImageData(BottomObjectData1)
{
	shapeFile = "~/data/shapes/objects/objectB1.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 8;
};
datablock ShapeBaseImageData(BottomObjectData2)
{
	shapeFile = "~/data/shapes/objects/objectB2.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 8;
};
datablock ShapeBaseImageData(BottomObjectData3)
{
	shapeFile = "~/data/shapes/objects/objectB3.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 8;
};
datablock ShapeBaseImageData(BottomObjectData4)
{
	shapeFile = "~/data/shapes/objects/objectB4.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 8;
};
datablock ShapeBaseImageData(BottomObjectData5)
{
	shapeFile = "~/data/shapes/objects/objectB5.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 8;
};
datablock ShapeBaseImageData(BottomObjectData6)
{
	shapeFile = "~/data/shapes/objects/objectB6.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 8;
};
function serverCmdMountDecoObjects(%client, %place, %numeroObjet)
{
	if (%client.Player)
	{
		if (%place $= "top")
		{
			eval("%client.player.mountImage(TopObjectData" @ %numeroObjet @ ",4);");
		}
		else if (%place $= "bottom")
		{
			eval("%client.player.mountImage(BottomObjectData" @ %numeroObjet @ ",5);");
		}
	}
}

