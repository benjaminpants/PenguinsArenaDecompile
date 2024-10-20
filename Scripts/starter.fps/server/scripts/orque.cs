datablock AudioProfile(OrqueSound)
{
	fileName = "~/data/sound/Son_orque.wav";
	description = AudioDefault3d;
	preload = 1;
};
datablock StaticShapeData(orque)
{
	category = "decors";
	shapeFile = "~/data/shapes/orque/orque.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
};
function orque::onAdd(%__unused, %obj)
{
	%obj.playThread(0, "attaque");
	%obj.playAudio(2, OrqueSound);
}

function orqueEclaboussures(%loc)
{
	spawnExplosion(%loc, "0 0 1", 0, "OrqueExplosion");
}

datablock StaticShapeData(aileron)
{
	category = "decors";
	shapeFile = "~/data/shapes/orque/aileron.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
};
function aileron::onAdd(%__unused, %obj)
{
	%aleat = getRandom(1000);
	%obj.schedule(%aleat, playThread, 0, "idle");
}

datablock ParticleData(Orqueparticles)
{
	textureName = "~/data/shapes/particles/smoke";
	dragCoeffiecient = 1;
	gravityCoefficient = 5;
	inheritedVelFactor = 0.5;
	constantAcceleration = 0;
	lifetimeMS = 500;
	lifetimeVarianceMS = 100;
	useInvAlpha = 0;
	spinRandomMin = 0;
	spinRandomMax = 0;
	colors[0] = "1 1 1 0.5";
	colors[1] = "1 1 1 0";
	sizes[0] = 0.5;
	sizes[1] = 0.5;
	times[0] = 0;
	times[1] = 1;
};
datablock ParticleEmitterData(Orqueemitter)
{
	ejectionPeriodMS = 5;
	periodVarianceMS = 0;
	ejectionVelocity = 10;
	velocityVariance = 2;
	thetaMin = 20;
	thetaMax = 60;
	lifetimeMS = 300;
	particles = Orqueparticles;
};
datablock ExplosionData(OrqueExplosion)
{
	lifetimeMS = 2000;
	particleDensity = 1000;
	particleRadius = 10;
	emitter[0] = PlayerSplashEmitter;
	emitter[1] = PlayerSplashMistEmitter;
	emitter[2] = Orqueemitter;
};
datablock StaticShapeData(DeadPenguin)
{
	category = "decors";
	shapeFile = "~/data/shapes/deadPlayer/deadpenguin.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
};
function DeadPenguin::onAdd(%__unused, %obj)
{
	%obj.playThread(0, "idle");
}

datablock StaticShapeData(SacPoubelle)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/decharge_sacanime.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
};
function SacPoubelle::onAdd(%__unused, %obj)
{
	%obj.playThread(0, "idle");
}

datablock StaticShapeData(auroreA)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/aurore1.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
};
function auroreA::onAdd(%__unused, %obj)
{
	%obj.playThread(0, "idle");
}

datablock StaticShapeData(auroreB)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/aurore2.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
};
function auroreB::onAdd(%__unused, %obj)
{
	%obj.playThread(0, "idle");
}

