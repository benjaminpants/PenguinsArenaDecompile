datablock StaticShapeData(plateform)
{
	category = "decors";
	shapeFile = "~/data/shapes/decors/plateform.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	computeCRC = 0;
	shadowEnable = 0;
};
function plateform::onAdd(%__unused, %__unused)
{
}

datablock ParticleData(plateformParticles)
{
	textureName = "~/data/shapes/particles/fumee.png";
	gravityCoefficient = -0.25;
	lifetimeMS = 10000;
	lifetimeVarianceMS = 1000;
	useInvAlpha = 1;
	colors[0] = "1 1 1 1";
	colors[1] = "1 1 1 0.8";
	colors[2] = "1 1 1 0";
	sizes[0] = 2;
	sizes[1] = 20;
	sizes[2] = 60;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(plateformEmitter)
{
	ejectionPeriodMS = 100;
	periodVarianceMS = 0;
	ejectionVelocity = 5;
	velocityVariance = 1;
	thetaMin = 10;
	thetaMax = 20;
	particles = plateformParticles;
};
