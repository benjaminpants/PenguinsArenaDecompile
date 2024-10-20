datablock ParticleData(ChimneyFire1)
{
	textureName = "~/data/shapes/particles/feu";
	dragCoefficient = 0;
	gravityCoefficient = -0.10000000149011612;
	inheritedVelFactor = 0;
	lifetimeMS = 2000;
	lifetimeVarianceMS = 600;
	useInvAlpha = 0;
	spinRandomMin = -20;
	spinRandomMax = 20;
	colors[0] = "1 1 1 0.0";
	colors[1] = "1 1 1 1.0";
	colors[2] = "1 1 1 0.0";
	sizes[0] = 4;
	sizes[1] = 3;
	sizes[2] = 1;
	times[0] = 0;
	times[1] = 0.2;
	times[2] = 1;
};
datablock ParticleEmitterData(ChimneyFireEmitter)
{
	ejectionPeriodMS = 200;
	periodVarianceMS = 10;
	ejectionVelocity = 0.15;
	velocityVariance = 0.05;
	thetaMin = 3;
	thetaMax = 90;
	particles = "ChimneyFire1";
};
datablock ParticleEmitterNodeData(ChimneyFireEmitterNode)
{
	timeMultiple = 1;
};
