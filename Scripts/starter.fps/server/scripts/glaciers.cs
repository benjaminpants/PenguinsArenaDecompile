datablock ParticleData(glacierParticles1)
{
	textureName = "~/data/shapes/particles/spark";
	dragCoeffiecient = 5;
	gravityCoefficient = 0.4;
	inheritedVelFactor = 0.5;
	constantAcceleration = 0.1;
	lifetimeMS = 1000;
	lifetimeVarianceMS = 300;
	useInvAlpha = 0;
	spinRandomMin = -80;
	spinRandomMax = 80;
	colors[0] = "1 1 1 0";
	colors[1] = "1 1 1 0.5";
	colors[2] = "1 1 1 0";
	sizes[0] = 10;
	sizes[1] = 20;
	sizes[2] = 40;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(glacierEmitter1)
{
	ejectionPeriodMS = 60;
	periodVarianceMS = 10;
	ejectionVelocity = 15;
	velocityVariance = 10;
	thetaMin = 0;
	thetaMax = 90;
	particles = glacierParticles1;
};
datablock ExplosionData(glacierExplosion)
{
	lifetimeMS = 6000;
	particleDensity = 1000;
	particleRadius = 10;
	emitter[0] = glacierEmitter1;
};
datablock StaticShapeData(glacierLoin)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/glaciera.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
};
function glacierLoin::onAdd(%__unused, %obj)
{
	schedule(10000 + getRandom(15000), 0, AnimationFonteGlaces, %obj);
}

datablock StaticShapeData(glaciera)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/glaciera.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
};
function glaciera::onAdd(%__unused, %obj)
{
	schedule(35000 + getRandom(15000), 0, AnimationFonteGlaces, %obj);
}

datablock StaticShapeData(glacierb)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/glacierb.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
};
function glacierb::onAdd(%__unused, %obj)
{
	schedule(25000 + getRandom(9000), 0, AnimationFonteGlaces, %obj);
}

datablock StaticShapeData(glacierc)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/glacierc.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
};
function glacierc::onAdd(%__unused, %obj)
{
	schedule(20000 + getRandom(6000), 0, AnimationFonteGlaces, %obj);
}

datablock StaticShapeData(glacierd)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/glacierd.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.001;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
};
function glacierd::onAdd(%__unused, %obj)
{
	schedule(15000 + getRandom(3000), 0, AnimationFonteGlaces, %obj);
}

datablock StaticShapeData(glaciere)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/glaciere.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.001;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
};
function glaciere::onAdd(%__unused, %obj)
{
	schedule(30000 + getRandom(12000), 0, AnimationFonteGlaces, %obj);
}

datablock AudioProfile(GlacierSound)
{
	fileName = "~/data/sound/glacier.ogg";
	description = AudioLoud3d;
	preload = 1;
};
function AnimationFonteGlaces(%obj)
{
	%loc = getWord(%obj.getTransform(), 0) SPC getWord(%obj.getTransform(), 1) SPC "205";
	spawnExplosion(%loc, "0 0 1", 0, "glacierExplosion");
	%obj.playThread(0, "idle");
	%obj.playAudio(2, GlacierSound);
	%obj.schedule(8000, "delete");
}

