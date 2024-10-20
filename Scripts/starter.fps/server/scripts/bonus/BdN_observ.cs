datablock AudioProfile(observExplosionSound)
{
	fileName = "~/data/sound/explosion.wav";
	description = AudioDefault3d;
	preload = 1;
};
datablock AudioProfile(observReloadSound)
{
	fileName = "~/data/sound/crossbow_reload.ogg";
	description = AudioClose3d;
	preload = 1;
};
datablock AudioProfile(observFireSound)
{
	fileName = "~/data/sound/fire_bdn.wav";
	description = AudioClose3d;
	preload = 1;
};
datablock ItemData(observAmmo)
{
	category = "Ammo";
	className = "Ammo";
	shapeFile = "~/data/shapes/bonus/BdNexplosive/BdNexplosive.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "Boule de neige explosive";
	maxInventory = 100;
	computeCRC = 0;
};
datablock ItemData(observ)
{
	category = "Weapon";
	className = "Weapon";
	shapeFile = "~/data/shapes/bonus/BdNexplosive/BdNexplosive.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "a observ weapon";
	image = observImage;
};
datablock ParticleData(observParticles1)
{
	textureName = "~/data/shapes/particles/poisson1";
	dragCoeffiecient = 10;
	gravityCoefficient = 2.5;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 1500;
	lifetimeVarianceMS = 300;
	useInvAlpha = 0;
	spinSpeed = 1;
	spinRandomMin = -90;
	spinRandomMax = 90;
	colors[0] = "1 1 1 1";
	colors[1] = "1 1 1 1";
	colors[2] = "1 1 1 0";
	sizes[0] = 0.7;
	sizes[1] = 0.7;
	sizes[2] = 0.7;
	times[0] = 0;
	times[1] = 0.9;
	times[2] = 1;
};
datablock ParticleData(observParticles2)
{
	textureName = "~/data/shapes/particles/poisson2";
	dragCoeffiecient = 10;
	gravityCoefficient = 2.5;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 1500;
	lifetimeVarianceMS = 300;
	useInvAlpha = 0;
	spinSpeed = 1;
	spinRandomMin = -90;
	spinRandomMax = 90;
	colors[0] = "1 1 1 1";
	colors[1] = "1 1 1 1";
	colors[2] = "1 1 1 0";
	sizes[0] = 1;
	sizes[1] = 1;
	sizes[2] = 1;
	times[0] = 0;
	times[1] = 0.9;
	times[2] = 1;
};
datablock ParticleData(observParticles3)
{
	textureName = "~/data/shapes/bonus/BdNexplosive/invi.png";
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
	colors[1] = "1 0.5 1 1";
	colors[2] = "1 0 1 0";
	sizes[0] = 1;
	sizes[1] = 22;
	sizes[2] = 32;
	times[0] = 0;
	times[1] = 0.2;
	times[2] = 1;
};
datablock ParticleEmitterData(observEmitter1)
{
	ejectionPeriodMS = 50;
	periodVarianceMS = 0;
	ejectionVelocity = 15;
	velocityVariance = 5;
	thetaMin = 0;
	thetaMax = 90;
	lifetimeMS = 250;
	particles = observParticles1;
};
datablock ParticleEmitterData(observEmitter2)
{
	ejectionPeriodMS = 50;
	periodVarianceMS = 0;
	ejectionVelocity = 15;
	velocityVariance = 5;
	thetaMin = 0;
	thetaMax = 90;
	lifetimeMS = 150;
	particles = observParticles2;
};
datablock ParticleEmitterData(observEmitter3)
{
	ejectionPeriodMS = 100;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0;
	thetaMin = 0;
	thetaMax = 0;
	lifetimeMS = 100;
	particles = observParticles3;
};
datablock ExplosionData(observExplosion)
{
	soundProfile = observExplosionSound;
	lifetimeMS = 200;
	particleDensity = 5;
	particleRadius = 1;
	emitter[0] = observEmitter3;
	shakeCamera = 1;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10;
};
datablock ProjectileData(observProjectile)
{
	projectileShapeName = "~/data/shapes/bonus/BdNexplosive/Fantomegrenade.dts";
	directDamage = 0;
	radiusDamage = 0;
	damageRadius = 15;
	areaImpulse = 3000;
	Explosion = observExplosion;
	particleWaterEmitter = CrossbowBoltBubbleEmitter;
	Splash = CrossbowSplash;
	muzzleVelocity = 30;
	velInheritFactor = 0.4;
	armingDelay = 2000;
	lifetime = 5000;
	fadeDelay = 5000;
	bounceElasticity = 0.3;
	bounceFriction = 0.6;
	isBallistic = 1;
	gravityMod = 1;
	hasLight = 1;
	lightRadius = 2.5;
	lightColor = "0.8 0.3 0.8";
	hasWaterLight = 0;
};
function observProjectile::onCollision(%this, %obj, %__unused, %__unused, %pos, %__unused)
{
	radiusDamageImpulse(%obj, %pos, %this.damageRadius, %this.radiusDamage, "Radius", %this.areaImpulse);
}

datablock ShapeBaseImageData(observImage)
{
	shapeFile = "~/data/shapes/bonus/BdNexplosive/FantomegrenadeW.dts";
	emap = 1;
	MountPoint = 2;
	offset = "0 0 0";
	correctMuzzleVector = 0;
	className = "WeaponImage";
	Item = observ;
	Ammo = observAmmo;
	Projectile = observProjectile;
	projectileType = Projectile;
	stateName[0] = "Preactivate";
	stateTransitionOnLoaded[0] = "Activate";
	stateTransitionOnNoAmmo[0] = "NoAmmo";
	stateName[1] = "Activate";
	stateTransitionOnTimeout[1] = "Ready";
	stateTimeoutValue[1] = 0.7;
	stateSequence[1] = "Activate";
	stateName[2] = "Ready";
	stateTransitionOnNoAmmo[2] = "NoAmmo";
	stateTransitionOnTriggerDown[2] = "Fire";
	stateName[3] = "Fire";
	stateTransitionOnTimeout[3] = "Reload";
	stateTimeoutValue[3] = 0.1;
	stateFire[3] = 1;
	stateRecoil[3] = LightRecoil;
	stateAllowImageChange[3] = 0;
	stateSequence[3] = "WFire";
	stateScript[3] = "onFire";
	stateSound[3] = observFireSound;
	stateName[4] = "Reload";
	stateTransitionOnNoAmmo[4] = "NoAmmo";
	stateTransitionOnTimeout[4] = "Ready";
	stateTimeoutValue[4] = 1.1;
	stateAllowImageChange[4] = 0;
	stateSequence[4] = "Reload";
	stateEjectShell[4] = 1;
	stateSound[4] = observReloadSound;
	stateName[5] = "NoAmmo";
	stateTransitionOnAmmo[5] = "Reload";
	stateSequence[5] = "NoAmmo";
	stateTransitionOnTriggerDown[5] = "DryFire";
	stateScript[5] = "onNoAmmo";
	stateName[6] = "DryFire";
	stateTimeoutValue[6] = 1;
	stateTransitionOnTimeout[6] = "NoAmmo";
	stateSound[6] = observFireEmptySound;
};
function observImage::onFire(%this, %obj, %slot)
{
	%obj.setActionThread("fire");
	%projectile = %this.Projectile;
	%obj.decInventory(%this.Ammo, 1);
	%muzzleVector = %obj.client.Player.getEyeVector();
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
		teamId = %obj.team_id;
	};
	MissionCleanup.add(%p);
	return %p;
}

function observImage::onNoAmmo(%this, %obj, %slot)
{
	commandToClient(%obj.client, 'FullGameOnlyFantome');
}

