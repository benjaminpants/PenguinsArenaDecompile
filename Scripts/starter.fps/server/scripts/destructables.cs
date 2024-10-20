datablock StaticShapeData(AnimatedIceCube)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/animatedcube.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
};
function AnimatedIceCube::onAdd(%__unused, %obj)
{
	%obj.touche = 1;
}

datablock StaticShapeData(AnimatedIceCube2)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/animatedcube2.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
};
function AnimatedIceCube2::onAdd(%__unused, %obj)
{
	%obj.touche = 1;
}

datablock StaticShapeData(AnimatedIceCube3)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/animatedcube3.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
};
function AnimatedIceCube3::onAdd(%__unused, %obj)
{
	%obj.touche = 1;
}

function ExplosionCube(%obj)
{
	if (%obj.touche == 1)
	{
		%obj.touche = 2;
		%obj.playThread(0, "hit");
	}
	else if (%obj.touche == 2)
	{
		%obj.playThread(0, "fall");
		%obj.schedule(3000, "delete");
	}
}

