datablock ShapeBaseImageData(griffesimage1)
{
	shapeFile = "~/data/shapes/bonus/griffes/griffes.dts";
	firstPerson = 1;
	Item = griffes;
	MountPoint = 4;
	emap = 1;
};
datablock ShapeBaseImageData(griffesimage2)
{
	shapeFile = "~/data/shapes/bonus/griffes/griffes2.dts";
	firstPerson = 1;
	Item = griffes;
	MountPoint = 3;
	emap = 1;
};
datablock ItemData(griffes)
{
	category = "Bonus";
	className = "Bonus";
	shapeFile = "~/data/shapes/bonus/griffes/griffesBonus.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "griffes";
	computeCRC = 0;
};
function griffes::onAdd(%this, %obj)
{
	%obj.playThread(0, "idle");
}

function griffes::onunmountbonus(%this, %player)
{
	%player.unmountImage(2);
	%player.unmountImage(3);
}

function griffes::onPickup(%this, %obj, %player, %__unused)
{
	if (%player.getMountedImage(2) == 0 && %player.getMountedImage(3) == 0)
	{
		%player.mountImage(griffesimage1, 2);
		%player.mountImage(griffesimage2, 3);
		if (%player.client)
		{
			commandToClient(%player.client, 'GotBonus', "griffes", 10 * 1000);
		}
		%this.schedule(10 * 1000, "onunmountbonus", %player);
		%obj.respawn();
		return 1;
	}
	return;
}

