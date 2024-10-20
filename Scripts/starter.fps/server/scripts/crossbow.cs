// snowball

datablock AudioProfile(CrossbowFireSound)
{
	fileName = "~/data/sound/fire_bdn.wav";
	description = AudioClose3d;
	preload = 1;
};
datablock AudioProfile(CrossbowExplosionSound)
{
	fileName = "~/data/sound/impact_bdn.wav";
	description = AudioDefault3d;
	preload = 1;
};
datablock ParticleData(CrossbowSplashMist)
{
	dragCoefficient = 2;
	gravityCoefficient = -0.05000000074505806;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 400;
	lifetimeVarianceMS = 100;
	useInvAlpha = 0;
	spinRandomMin = -90;
	spinRandomMax = 500;
	textureName = "~/data/shapes/crossbow/splash";
	colors[0] = "0.7 0.8 1.0 1.0";
	colors[1] = "0.7 0.8 1.0 0.5";
	colors[2] = "0.7 0.8 1.0 0.0";
	sizes[0] = 0.5;
	sizes[1] = 0.5;
	sizes[2] = 0.8;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(CrossbowSplashMistEmitter)
{
	ejectionPeriodMS = 5;
	periodVarianceMS = 0;
	ejectionVelocity = 3;
	velocityVariance = 2;
	ejectionOffset = 0;
	thetaMin = 85;
	thetaMax = 85;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	lifetimeMS = 250;
	particles = "CrossbowSplashMist";
};
datablock ParticleData(CrossbowSplashParticle)
{
	dragCoefficient = 1;
	gravityCoefficient = 0.2;
	inheritedVelFactor = 0.2;
	constantAcceleration = -0;
	lifetimeMS = 600;
	lifetimeVarianceMS = 0;
	colors[0] = "0.7 0.8 1.0 1.0";
	colors[1] = "0.7 0.8 1.0 0.5";
	colors[2] = "0.7 0.8 1.0 0.0";
	sizes[0] = 0.5;
	sizes[1] = 0.5;
	sizes[2] = 0.5;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(CrossbowSplashEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 3;
	velocityVariance = 1;
	ejectionOffset = 0;
	thetaMin = 60;
	thetaMax = 80;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	orientParticles = 1;
	lifetimeMS = 100;
	particles = "CrossbowSplashParticle";
};
datablock SplashData(CrossbowSplash)
{
	numSegments = 15;
	ejectionFreq = 15;
	ejectionAngle = 40;
	ringLifetime = 0.5;
	lifetimeMS = 300;
	velocity = 4;
	startRadius = 0;
	acceleration = -3;
	texWrap = 5;
	Texture = "~/data/shapes/crossbow/splash";
	emitter[0] = CrossbowSplashEmitter;
	emitter[1] = CrossbowSplashMistEmitter;
	colors[0] = "0.7 0.8 1.0 0.0";
	colors[1] = "0.7 0.8 1.0 0.3";
	colors[2] = "0.7 0.8 1.0 0.7";
	colors[3] = "0.7 0.8 1.0 0.0";
	times[0] = 0;
	times[1] = 0.4;
	times[2] = 0.8;
	times[3] = 1;
};
datablock ParticleData(CrossbowBoltParticle)
{
	textureName = "~/data/shapes/particles/smoke";
	dragCoefficient = 0;
	gravityCoefficient = -0.10000000149011612;
	inheritedVelFactor = 0;
	lifetimeMS = 150;
	lifetimeVarianceMS = 10;
	useInvAlpha = 0;
	spinRandomMin = -30;
	spinRandomMax = 30;
	colors[0] = "0.1 0.1 0.1 1.0";
	colors[1] = "0.1 0.1 0.1 1.0";
	colors[2] = "0.1 0.1 0.1 0";
	sizes[0] = 0.15;
	sizes[1] = 0.2;
	sizes[2] = 0.25;
	times[0] = 0;
	times[1] = 0.3;
	times[2] = 1;
};
datablock ParticleData(CrossbowBubbleParticle)
{
	textureName = "~/data/shapes/particles/bubble";
	dragCoefficient = 0;
	gravityCoefficient = -0.25;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 1500;
	lifetimeVarianceMS = 600;
	useInvAlpha = 0;
	spinRandomMin = -100;
	spinRandomMax = 100;
	colors[0] = "0.7 0.8 1.0 0.4";
	colors[1] = "0.7 0.8 1.0 1.0";
	colors[2] = "0.7 0.8 1.0 0.0";
	sizes[0] = 0.2;
	sizes[1] = 0.2;
	sizes[2] = 0.2;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(CrossbowBoltEmitter)
{
	ejectionPeriodMS = 2;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0.1;
	thetaMin = 0;
	thetaMax = 90;
	particles = CrossbowBoltParticle;
};
datablock ParticleEmitterData(CrossbowBoltBubbleEmitter)
{
	ejectionPeriodMS = 9;
	periodVarianceMS = 0;
	ejectionVelocity = 1;
	ejectionOffset = 0.1;
	velocityVariance = 0.5;
	thetaMin = 0;
	thetaMax = 80;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvances = 0;
	particles = CrossbowBubbleParticle;
};
datablock ParticleData(CrossbowDebrisSpark)
{
	textureName = "~/data/shapes/particles/fire";
	dragCoefficient = 0;
	gravityCoefficient = 0;
	windCoefficient = 0;
	inheritedVelFactor = 0.5;
	constantAcceleration = 0;
	lifetimeMS = 500;
	lifetimeVarianceMS = 50;
	spinRandomMin = -90;
	spinRandomMax = 90;
	useInvAlpha = 0;
	colors[0] = "0.8 0.2 0 1.0";
	colors[1] = "0.8 0.2 0 1.0";
	colors[2] = "0 0 0 0.0";
	sizes[0] = 0.2;
	sizes[1] = 0.3;
	sizes[2] = 0.1;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(CrossbowDebrisSparkEmitter)
{
	ejectionPeriodMS = 20;
	periodVarianceMS = 0;
	ejectionVelocity = 0.5;
	velocityVariance = 0.25;
	ejectionOffset = 0;
	thetaMin = 0;
	thetaMax = 90;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvances = 0;
	orientParticles = 0;
	lifetimeMS = 300;
	particles = "CrossbowDebrisSpark";
};
datablock ExplosionData(CrossbowDebrisExplosion)
{
	emitter[0] = CrossbowDebrisSparkEmitter;
	shakeCamera = 0;
	impulseRadius = 0;
	lightStartRadius = 0;
	lightEndRadius = 0;
};
datablock ParticleData(CrossbowDebrisTrail)
{
	textureName = "~/data/shapes/particles/fire";
	dragCoefficient = 1;
	gravityCoefficient = 0;
	inheritedVelFactor = 0;
	windCoefficient = 0;
	constantAcceleration = 0;
	lifetimeMS = 800;
	lifetimeVarianceMS = 100;
	spinSpeed = 0;
	spinRandomMin = -90;
	spinRandomMax = 90;
	useInvAlpha = 1;
	colors[0] = "0.8 0.3 0.0 1.0";
	colors[1] = "0.1 0.1 0.1 0.7";
	colors[2] = "0.1 0.1 0.1 0.0";
	sizes[0] = 0.2;
	sizes[1] = 0.3;
	sizes[2] = 0.4;
	times[0] = 0.1;
	times[1] = 0.2;
	times[2] = 1;
};
datablock ParticleEmitterData(CrossbowDebrisTrailEmitter)
{
	ejectionPeriodMS = 30;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0;
	ejectionOffset = 0;
	thetaMin = 170;
	thetaMax = 180;
	phiReferenceVel = 0;
	phiVariance = 360;
	lifetimeMS = 5000;
	particles = "CrossbowDebrisTrail";
};
datablock DebrisData(CrossbowExplosionDebris)
{
	shapeFile = "~/data/shapes/crossbow/debris.dts";
	emitters = "CrossbowDebrisTrailEmitter";
	Explosion = CrossbowDebrisExplosion;
	elasticity = 0.6;
	friction = 0.5;
	numBounces = 1;
	bounceVariance = 1;
	explodeOnMaxBounce = 1;
	staticOnMaxBounce = 0;
	snapOnMaxBounce = 0;
	minSpinSpeed = 0;
	maxSpinSpeed = 700;
	render2D = 0;
	lifetime = 4;
	lifetimeVariance = 0.4;
	velocity = 5;
	velocityVariance = 0.5;
	fade = 0;
	useRadiusMass = 1;
	baseRadius = 0.3;
	gravModifier = 0.5;
	terminalVelocity = 6;
	ignoreWater = 1;
};
datablock ParticleData(CrossbowExplosionSmoke)
{
	textureName = "~/data/shapes/particles/smoke";
	dragCoeffiecient = 100;
	gravityCoefficient = 0;
	inheritedVelFactor = 0.25;
	constantAcceleration = -0.30000001192092896;
	lifetimeMS = 1200;
	lifetimeVarianceMS = 300;
	useInvAlpha = 1;
	spinRandomMin = -80;
	spinRandomMax = 80;
	colors[0] = "0.56 0.36 0.26 1.0";
	colors[1] = "0.2 0.2 0.2 1.0";
	colors[2] = "0.0 0.0 0.0 0.0";
	sizes[0] = 4;
	sizes[1] = 2.5;
	sizes[2] = 1;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleData(CrossbowExplosionBubble)
{
	textureName = "~/data/shapes/particles/bubble";
	dragCoeffiecient = 0;
	gravityCoefficient = -0.25;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 1500;
	lifetimeVarianceMS = 600;
	useInvAlpha = 0;
	spinRandomMin = -100;
	spinRandomMax = 100;
	colors[0] = "0.7 0.8 1.0 0.4";
	colors[1] = "0.7 0.8 1.0 0.4";
	colors[2] = "0.7 0.8 1.0 0.0";
	sizes[0] = 0.3;
	sizes[1] = 0.3;
	sizes[2] = 0.3;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(CrossbowExplosionSmokeEmitter)
{
	ejectionPeriodMS = 10;
	periodVarianceMS = 0;
	ejectionVelocity = 4;
	velocityVariance = 0.5;
	thetaMin = 0;
	thetaMax = 180;
	lifetimeMS = 250;
	particles = "CrossbowExplosionSmoke";
};
datablock ParticleEmitterData(CrossbowExplosionBubbleEmitter)
{
	ejectionPeriodMS = 9;
	periodVarianceMS = 0;
	ejectionVelocity = 1;
	ejectionOffset = 0.1;
	velocityVariance = 0.5;
	thetaMin = 0;
	thetaMax = 80;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvances = 0;
	particles = "CrossbowExplosionBubble";
};
datablock ParticleData(CrossbowExplosionFire)
{
	textureName = "~/data/shapes/particles/fire";
	dragCoeffiecient = 100;
	gravityCoefficient = 0;
	inheritedVelFactor = 0.25;
	constantAcceleration = 0.1;
	lifetimeMS = 1200;
	lifetimeVarianceMS = 300;
	useInvAlpha = 0;
	spinRandomMin = -80;
	spinRandomMax = 80;
	colors[0] = "0.8 0.4 0 0.8";
	colors[1] = "0.2 0.0 0 0.8";
	colors[2] = "0.0 0.0 0.0 0.0";
	sizes[0] = 1.5;
	sizes[1] = 0.9;
	sizes[2] = 0.5;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(CrossbowExplosionFireEmitter)
{
	ejectionPeriodMS = 10;
	periodVarianceMS = 0;
	ejectionVelocity = 0.8;
	velocityVariance = 0.5;
	thetaMin = 0;
	thetaMax = 180;
	lifetimeMS = 250;
	particles = "CrossbowExplosionFire";
};
datablock ParticleData(CrossbowExplosionSparks)
{
	textureName = "~/data/shapes/particles/spark";
	dragCoefficient = 1;
	gravityCoefficient = 0;
	inheritedVelFactor = 0.2;
	constantAcceleration = 0;
	lifetimeMS = 500;
	lifetimeVarianceMS = 350;
	colors[0] = "0.60 0.40 0.30 1.0";
	colors[1] = "0.60 0.40 0.30 1.0";
	colors[2] = "1.0 0.40 0.30 0.0";
	sizes[0] = 0.25;
	sizes[1] = 0.15;
	sizes[2] = 0.15;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleData(CrossbowExplosionWaterSparks)
{
	textureName = "~/data/shapes/particles/bubble";
	dragCoefficient = 0;
	gravityCoefficient = 0;
	inheritedVelFactor = 0.2;
	constantAcceleration = 0;
	lifetimeMS = 500;
	lifetimeVarianceMS = 350;
	colors[0] = "0.4 0.4 1.0 1.0";
	colors[1] = "0.4 0.4 1.0 1.0";
	colors[2] = "0.4 0.4 1.0 0.0";
	sizes[0] = 0.5;
	sizes[1] = 0.5;
	sizes[2] = 0.5;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(CrossbowExplosionSparkEmitter)
{
	ejectionPeriodMS = 3;
	periodVarianceMS = 0;
	ejectionVelocity = 5;
	velocityVariance = 1;
	ejectionOffset = 0;
	thetaMin = 0;
	thetaMax = 180;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvances = 0;
	orientParticles = 1;
	lifetimeMS = 100;
	particles = "CrossbowExplosionSparks";
};
datablock ParticleEmitterData(CrossbowExplosionWaterSparkEmitter)
{
	ejectionPeriodMS = 3;
	periodVarianceMS = 0;
	ejectionVelocity = 4;
	velocityVariance = 4;
	ejectionOffset = 0;
	thetaMin = 0;
	thetaMax = 60;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvances = 0;
	orientParticles = 1;
	lifetimeMS = 200;
	particles = "CrossbowExplosionWaterSparks";
};
datablock ExplosionData(CrossbowSubExplosion1)
{
	offset = 0;
	emitter[0] = CrossbowExplosionSmokeEmitter;
	emitter[1] = CrossbowExplosionSparkEmitter;
};
datablock ExplosionData(CrossbowSubExplosion2)
{
	offset = 1;
	emitter[0] = CrossbowExplosionSmokeEmitter;
	emitter[1] = CrossbowExplosionSparkEmitter;
};
datablock ExplosionData(CrossbowSubWaterExplosion1)
{
	delayMS = 100;
	offset = 1.2;
	playSpeed = 1.5;
	emitter[0] = CrossbowExplosionBubbleEmitter;
	emitter[1] = CrossbowExplosionWaterSparkEmitter;
	sizes[0] = "0.75 0.75 0.75";
	sizes[1] = "1.0 1.0 1.0";
	sizes[2] = "0.5 0.5 0.5";
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ExplosionData(CrossbowSubWaterExplosion2)
{
	delayMS = 50;
	offset = 1.2;
	playSpeed = 0.75;
	emitter[0] = CrossbowExplosionBubbleEmitter;
	emitter[1] = CrossbowExplosionWaterSparkEmitter;
	sizes[0] = "1.5 1.5 1.5";
	sizes[1] = "1.5 1.5 1.5";
	sizes[2] = "1.0 1.0 1.0";
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleData(snowballparticles)
{
	textureName = "~/data/shapes/particles/spark";
	dragCoeffiecient = 100;
	gravityCoefficient = 0;
	inheritedVelFactor = 0.25;
	constantAcceleration = 0.1;
	lifetimeMS = 500;
	lifetimeVarianceMS = 300;
	useInvAlpha = 0;
	spinRandomMin = -80;
	spinRandomMax = 80;
	colors[0] = "1 1 1 1";
	colors[1] = "1 1 1 0.5";
	colors[2] = "1 1 1 0";
	sizes[0] = 0.3;
	sizes[1] = 0.3;
	sizes[2] = 0.3;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleData(snowballparticles2)
{
	textureName = "~/data/shapes/particles/spark";
	dragCoeffiecient = 10;
	gravityCoefficient = 0;
	inheritedVelFactor = 0.25;
	constantAcceleration = 0.1;
	lifetimeMS = 500;
	lifetimeVarianceMS = 300;
	useInvAlpha = 0;
	spinRandomMin = -80;
	spinRandomMax = 80;
	colors[0] = "1 1 1 1";
	colors[1] = "1 1 1 0.5";
	colors[2] = "1 1 1 0";
	sizes[0] = 0.3;
	sizes[1] = 0.4;
	sizes[2] = 0.5;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(snowballemitter)
{
	ejectionPeriodMS = 4;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 1;
	thetaMin = 0;
	thetaMax = 180;
	lifetimeMS = 250;
	particles = snowballparticles;
};
datablock ParticleEmitterData(snowballemitter2)
{
	ejectionPeriodMS = 30;
	periodVarianceMS = 0;
	ejectionVelocity = 0.5;
	velocityVariance = 0.1;
	thetaMin = 0;
	thetaMax = 90;
	particles = snowballparticles2;
};
datablock ExplosionData(CrossbowExplosion)
{
	lifetimeMS = 100;
	particleEmitter = snowballemitter;
	particleDensity = 30;
	particleRadius = 1;
	shakeCamera = 1;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10;
};
datablock ExplosionData(CrossbowWaterExplosion)
{
	soundProfile = CrossbowExplosionSound;
	particleEmitter = CrossbowExplosionBubbleEmitter;
	particleDensity = 375;
	particleRadius = 2;
	emitter[0] = CrossbowExplosionBubbleEmitter;
	emitter[1] = CrossbowExplosionWaterSparkEmitter;
	subExplosion[0] = CrossbowSubWaterExplosion1;
	subExplosion[1] = CrossbowSubWaterExplosion2;
	shakeCamera = 1;
	camShakeFreq = "8.0 9.0 7.0";
	camShakeAmp = "3.0 3.0 3.0";
	camShakeDuration = 1.3;
	camShakeRadius = 20;
	Debris = CrossbowExplosionDebris;
	debrisThetaMin = 0;
	debrisThetaMax = 60;
	debrisPhiMin = 0;
	debrisPhiMax = 360;
	debrisNum = 6;
	debrisNumVariance = 2;
	debrisVelocity = 0.5;
	debrisVelocityVariance = 0.2;
	impulseRadius = 10;
	impulseForce = 15;
	lightStartRadius = 6;
	lightEndRadius = 3;
	lightStartColor = "0 0.5 0.5";
	lightEndColor = "0 0 0";
};
datablock ProjectileData(CrossbowProjectile)
{
	projectileShapeName = "~/data/shapes/crossbow/projectile.dts";
	directDamage = 20;
	radiusDamage = 20;
	damageRadius = 1.7;
	Explosion = CrossbowExplosion;
	particleEmitter = snowballemitter2;
	particleWaterEmitter = CrossbowBoltBubbleEmitter;
	Splash = CrossbowSplash;
	muzzleVelocity = 63;
	velInheritFactor = 0.1;
	armingDelay = 0;
	lifetime = 3000;
	fadeDelay = 3000;
	bounceElasticity = 0;
	bounceFriction = 0;
	isBallistic = 0;
	gravityMod = 0.9;
	hasLight = 0;
	hasWaterLight = 0;
};
datablock AudioProfile(HardHit1)
{
	fileName = "~/data/sound/HardHit1.wav";
	description = AudioClose3d;
	preload = 1;
};
datablock AudioProfile(HardHit2)
{
	fileName = "~/data/sound/HardHit2.wav";
	description = AudioClose3d;
	preload = 1;
};
datablock AudioProfile(HardHit3)
{
	fileName = "~/data/sound/HardHit3.wav";
	description = AudioClose3d;
	preload = 1;
};
function CrossbowProjectile::onCollision(%this, %obj, %col, %__unused, %pos, %__unused)
{
	if (%col.getType() & $TypeMasks::PlayerObjectType)
	{
		if (!%col.isObserver)
		{
			if (%col.getMountedImage(2) && !%col.getMountedImage(3) || %col.reincarnationInvincible)
			{
				%col.playAudio(2, EffetInvincibleSound);
			}
			else
			{
				%col.playAudio(2, CrossbowExplosionSound);
				%kickBack = 4100;
				if (%col.getMountedImage(2) != 0 && %col.getMountedImage(3) != 0)
				{
					%kickBack -= 2500;
				}
				%direction_expulsion = VectorSub(%obj.getoldPosition(), %pos);
				%direction_expulsion = VectorNormalize(%direction_expulsion);
				%direction_expulsion = VectorScale(%direction_expulsion, -%kickBack);
				%col.applyImpulse(%obj.getoldPosition(), %direction_expulsion);
				if ($debugVisualDebug)
				{
					vdtVector(%obj.getoldPosition(), %direction_expulsion, VectorLen(%direction_expulsion) / 1000, 6000, "0.0 1.0 1.0 1.0", 1);
				}
				%col.stop();
				if (getWord(%direction_expulsion, 2) > 0)
				{
					%tmp = getRandom(1, 3);
					%tmp = "HardHit" @ %tmp;
					eval("%col.playAudio(2," @ %tmp @ ");");
					%col.setActionThread("fly");
				}
				else if (getRandom(1, 2) == 1)
				{
					%col.setActionThread("hit");
				}
				else
				{
					%col.setActionThread("turn");
				}
				%col.setSkinName("hit");
				%col.schedule(1000, setSkinName, "base");
			}
		}
	}
}

datablock ItemData(CrossbowAmmo)
{
	category = "Ammo";
	className = "Ammo";
	shapeFile = "~/data/shapes/crossbow/ammo.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	pickUpName = "crossbow bolts";
	maxInventory = 20;
};
datablock ItemData(Crossbow)
{
	category = "Weapon";
	className = "Weapon";
	shapeFile = "~/data/shapes/crossbow/weapon.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "a crossbow";
	image = CrossbowImage;
};
datablock ShapeBaseImageData(CrossbowImage)
{
	shapeFile = "~/data/shapes/crossbow/boule.dts";
	emap = 1;
	MountPoint = 0;
	eyeOffset = "0.1 0.4 -0.8";
	correctMuzzleVector = 0;
	className = "WeaponImage";
	Item = Crossbow;
	Ammo = CrossbowAmmo;
	Projectile = CrossbowProjectile;
	projectileType = Projectile;
	stateName[0] = "Preactivate";
	stateTransitionOnLoaded[0] = "Activate";
	stateTransitionOnNoAmmo[0] = "NoAmmo";
	stateName[1] = "Activate";
	stateTransitionOnTimeout[1] = "Ready";
	stateTimeoutValue[1] = 0.6;
	stateSequence[1] = "Activate";
	stateName[2] = "Ready";
	stateTransitionOnNoAmmo[2] = "NoAmmo";
	stateTransitionOnTriggerDown[2] = "Fire";
	stateName[3] = "Fire";
	stateTransitionOnTimeout[3] = "Reload";
	stateTimeoutValue[3] = 0.8;
	stateFire[3] = 1;
	stateRecoil[3] = LightRecoil;
	stateAllowImageChange[3] = 0;
	stateSequence[3] = "Wfire";
	stateScript[3] = "onFire";
	stateSound[3] = CrossbowFireSound;
	stateName[4] = "Reload";
	stateTransitionOnNoAmmo[4] = "NoAmmo";
	stateTransitionOnTimeout[4] = "Ready";
	stateTimeoutValue[4] = 0;
	stateAllowImageChange[4] = 0;
	stateSequence[4] = "Reload";
	stateEjectShell[4] = 1;
	stateName[5] = "NoAmmo";
	stateTransitionOnAmmo[5] = "Reload";
	stateSequence[5] = "NoAmmo";
	stateTransitionOnTriggerDown[5] = "DryFire";
	stateName[6] = "DryFire";
	stateTimeoutValue[6] = 1;
	stateTransitionOnTimeout[6] = "NoAmmo";
};
function CrossbowImage::onFire(%this, %obj, %slot)
{
	%obj.stop();
	%obj.setActionThread("fire");
	%projectile = %this.Projectile;
	%muzzleVector = %obj.getMuzzleVector(%slot);
	%objectVelocity = %obj.getVelocity();
	%muzzleVelocity = VectorAdd(VectorScale(%muzzleVector, %projectile.muzzleVelocity), VectorScale(%objectVelocity, %projectile.velInheritFactor));
	%p = new (%this.projectileType)()
	{
		dataBlock = %projectile;
		initialVelocity = %muzzleVelocity;
		initialPosition = %obj.getMuzzlePoint(%slot);
		sourceObject = %obj;
		sourceSlot = %slot;
		client = %obj.client;
	};
	MissionCleanup.add(%p);
	return %p;
}

