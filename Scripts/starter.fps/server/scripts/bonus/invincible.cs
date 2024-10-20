datablock AudioProfile(EffetInvincibleSound)
{
	fileName = "~/data/sound/invincible_sound.wav";
	description = AudioDefault3d;
	preload = 1;
};
datablock ShapeBaseImageData(InvincibleImage)
{
	shapeFile = "~/data/shapes/bonus/invincible/invincible.dts";
	firstPerson = 0;
	Item = InvincibleB;
	MountPoint = 5;
	emap = 1;
};
datablock ItemData(InvincibleB)
{
	category = "Bonus";
	className = "Bonus";
	shapeFile = "~/data/shapes/bonus/invincible/invincibleBonus.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "Invincible";
	computeCRC = 0;
};
function InvincibleB::onAdd(%this, %obj)
{
	%obj.playThread(0, "idle");
}

function InvincibleB::onunmountbonus(%this, %player)
{
	%player.unmountImage(2);
	%player.setSkinName("base");
}

function InvincibleB::onPickup(%this, %obj, %player, %__unused)
{
	spawnExplosion(%obj.getTransform(), "0 0 1", 0, "InvincibleEffectExplosion");
	%player.unmountImage(2);
	%player.unmountImage(3);
	%player.mountImage(InvincibleImage, 2);
	%player.setSkinName("invincible");
	%this.schedule(10 * 1000, "onunmountbonus", %player);
	if (%player.client)
	{
		commandToClient(%player.client, 'GotBonus', "invincibilite", 10 * 1000);
	}
	%obj.respawn();
	return 1;
}

datablock ParticleData(InvincibleEffectparticles)
{
	textureName = "~/data/shapes/bonus/invincible/invi.png";
	dragCoeffiecient = 0;
	gravityCoefficient = 0;
	inheritedVelFactor = 0.1;
	constantAcceleration = 0;
	lifetimeMS = 1500;
	lifetimeVarianceMS = 0;
	useInvAlpha = 0;
	spinRandomMin = 0;
	spinRandomMax = 0;
	colors[0] = "1 1 1 1";
	colors[1] = "0.5 1 0.5 1";
	colors[2] = "0 1 0 0";
	sizes[0] = 1;
	sizes[1] = 30;
	sizes[2] = 40;
	times[0] = 0;
	times[1] = 0.2;
	times[2] = 1;
};
datablock ParticleEmitterData(InvincibleEffectemitter)
{
	ejectionPeriodMS = 100;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0;
	thetaMin = 0;
	thetaMax = 0;
	lifetimeMS = 100;
	particles = InvincibleEffectparticles;
};
datablock ExplosionData(InvincibleEffectExplosion)
{
	lifetimeMS = 200;
	particleDensity = 5;
	particleRadius = 1;
	emitter[0] = InvincibleEffectemitter;
	shakeCamera = 1;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10;
	lightStartRadius = 6;
	lightEndRadius = 3;
	lightStartColor = "0.5 0.5 0";
	lightEndColor = "0 0 0";
};
