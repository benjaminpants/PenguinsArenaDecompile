datablock StaticShapeData(geyser1)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/geyser1.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 1;
};
function geyser1::onAdd(%__unused, %obj)
{
	%obj.playThread(0, "idle");
}

datablock ParticleEmitterNodeData(DefaultEmitterNode)
{
	timeMultiple = 1;
};
datablock ParticleData(geyserParticles1)
{
	textureName = "~/data/shapes/particles/spark";
	dragCoeffiecient = 10;
	gravityCoefficient = 0.5;
	inheritedVelFactor = 0.25;
	constantAcceleration = 0.1;
	lifetimeMS = 1000;
	lifetimeVarianceMS = 300;
	useInvAlpha = 0;
	spinRandomMin = -80;
	spinRandomMax = 80;
	colors[0] = "1 1 1 0";
	colors[1] = "1 1 1 0.5";
	colors[2] = "1 1 1 0";
	sizes[0] = 2;
	sizes[1] = 5;
	sizes[2] = 10;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(geyserEmitter1)
{
	ejectionPeriodMS = 200;
	periodVarianceMS = 0;
	ejectionVelocity = 5;
	velocityVariance = 3;
	thetaMin = 0;
	thetaMax = 90;
	particles = geyserParticles1;
};
datablock ParticleData(geyserParticles2)
{
	textureName = "~/data/shapes/particles/spark";
	dragCoeffiecient = 10;
	gravityCoefficient = 3;
	inheritedVelFactor = 0.25;
	constantAcceleration = 0.1;
	lifetimeMS = 2000;
	lifetimeVarianceMS = 500;
	useInvAlpha = 0;
	spinRandomMin = -80;
	spinRandomMax = 80;
	colors[0] = "1 1 1 0";
	colors[1] = "1 1 1 0.5";
	colors[2] = "1 1 1 0";
	sizes[0] = 0.2;
	sizes[1] = 0.2;
	sizes[2] = 0.2;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(geyserEmitter2)
{
	ejectionPeriodMS = 4;
	periodVarianceMS = 0;
	ejectionVelocity = 35;
	velocityVariance = 1;
	thetaMin = 0;
	thetaMax = 5;
	particles = geyserParticles2;
};
datablock ParticleData(geyserParticles3)
{
	textureName = "~/data/shapes/particles/spark";
	dragCoeffiecient = 10;
	gravityCoefficient = 3;
	inheritedVelFactor = 0.25;
	constantAcceleration = 0.1;
	lifetimeMS = 1000;
	lifetimeVarianceMS = 300;
	useInvAlpha = 0;
	spinRandomMin = -80;
	spinRandomMax = 80;
	colors[0] = "1 1 1 0";
	colors[1] = "1 1 1 1";
	colors[2] = "1 1 1 0";
	sizes[0] = 0.2;
	sizes[1] = 0.2;
	sizes[2] = 0.2;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(geyserEmitter3)
{
	ejectionPeriodMS = 100;
	periodVarianceMS = 0;
	ejectionVelocity = 20;
	velocityVariance = 0.1;
	thetaMin = 10;
	thetaMax = 20;
	particles = geyserParticles3;
};
datablock ParticleData(geyserParticles4)
{
	textureName = "~/data/shapes/particles/spark";
	dragCoeffiecient = 10;
	gravityCoefficient = 2.5;
	inheritedVelFactor = 0.25;
	constantAcceleration = 0.1;
	lifetimeMS = 1000;
	lifetimeVarianceMS = 300;
	useInvAlpha = 0;
	spinRandomMin = -80;
	spinRandomMax = 80;
	colors[0] = "1 1 1 0";
	colors[1] = "1 1 1 1";
	colors[2] = "1 1 1 0";
	sizes[0] = 5;
	sizes[1] = 5;
	sizes[2] = 15;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(geyserEmitter4)
{
	ejectionPeriodMS = 100;
	periodVarianceMS = 0;
	ejectionVelocity = 10;
	velocityVariance = 3;
	thetaMin = 10;
	thetaMax = 20;
	particles = geyserParticles4;
};
