datablock AudioProfile(ExplosionBDN)
{
	fileName = "~/data/sound/explosion.wav";
	description = AudioDefault3d;
	preload = 1;
};
datablock ItemData(BdNexplosive)
{
	category = "Ammo";
	className = "Ammo";
	shapeFile = "~/data/shapes/bonus/BdNexplosive/BdNexplosive.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "Boule de neige explosive";
	maxInventory = 1;
	computeCRC = 0;
};
datablock ItemData(BdNexplosiveW)
{
	category = "Weapon";
	className = "Weapon";
	shapeFile = "~/data/shapes/bonus/BdNexplosive/BdNexplosive.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "a grenade";
	image = grenadeImage;
};
function BdNexplosive::onAdd(%this, %obj)
{
	%obj.playThread(0, "idle");
}

function BdNexplosive::onPickup(%this, %obj, %user, %__unused)
{
	%user.setInventory(rafaleAmmo, 0);
	%user.setInventory(BdNgeanteW, 0);
	%user.setInventory(BdNgeante, 0);
	%user.mountImage(grenadeImage, 0);
	%user.setInventory(BdNexplosive, 1);
	%user.setInventory(BdNexplosiveW, 1);
	if (%user.client)
	{
		commandToClient(%user.client, 'GotBonus', "BdNexplosive");
	}
	if (%obj.isStatic())
	{
		%obj.respawn();
	}
	else
	{
		%obj.delete();
	}
	return 1;
}

datablock ParticleData(BdNexplosiveparticles1)
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
datablock ParticleData(BdNexplosiveparticles2)
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
datablock ParticleData(BdNexplosiveparticles3)
{
	textureName = "~/data/shapes/particles/explosion_verte";
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
datablock ParticleEmitterData(BdNexplosiveemitter1)
{
	ejectionPeriodMS = 50;
	periodVarianceMS = 0;
	ejectionVelocity = 15;
	velocityVariance = 5;
	thetaMin = 0;
	thetaMax = 90;
	lifetimeMS = 250;
	particles = BdNexplosiveparticles1;
};
datablock ParticleEmitterData(BdNexplosiveemitter2)
{
	ejectionPeriodMS = 50;
	periodVarianceMS = 0;
	ejectionVelocity = 15;
	velocityVariance = 5;
	thetaMin = 0;
	thetaMax = 90;
	lifetimeMS = 150;
	particles = BdNexplosiveparticles2;
};
datablock ParticleEmitterData(BdNexplosiveemitter3)
{
	ejectionPeriodMS = 100;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0;
	thetaMin = 0;
	thetaMax = 0;
	lifetimeMS = 100;
	particles = BdNexplosiveparticles3;
};
datablock ExplosionData(BdNexplosiveExplosion)
{
	soundProfile = ExplosionBDN;
	lifetimeMS = 200;
	particleDensity = 5;
	particleRadius = 1;
	emitter[0] = BdNexplosiveemitter1;
	emitter[1] = BdNexplosiveemitter2;
	emitter[2] = BdNexplosiveemitter3;
	shakeCamera = 1;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10;
};
datablock ProjectileData(BdNexplosiveProjectile)
{
	projectileShapeName = "~/data/shapes/bonus/BdNexplosive/grenade.dts";
	directDamage = 0;
	radiusDamage = 0;
	damageRadius = 26;
	areaImpulse = 4000;
	Explosion = BdNexplosiveExplosion;
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
	lightRadius = 3;
	lightColor = "0.3 0.8 0.3";
	hasWaterLight = 0;
};
function BdNexplosiveProjectile::onCollision(%this, %obj, %__unused, %__unused, %pos, %__unused)
{
	radiusDamageImpulse(%obj, %pos, %this.damageRadius, %this.radiusDamage, "Radius", %this.areaImpulse);
}

datablock ShapeBaseImageData(grenadeImage)
{
	shapeFile = "~/data/shapes/bonus/BdNexplosive/grenadew.dts";
	emap = 1;
	MountPoint = 0;
	eyeOffset = "0.3 0.5 -1";
	correctMuzzleVector = 0;
	className = "WeaponImage";
	Item = BdNexplosiveW;
	Ammo = BdNexplosive;
	Projectile = BdNexplosiveProjectile;
	projectileType = Projectile;
	stateName[0] = "Preactivate";
	stateTransitionOnLoaded[0] = "Activate";
	stateTransitionOnNoAmmo[0] = "NoAmmo";
	stateName[1] = "Activate";
	stateTransitionOnTimeout[1] = "Ready";
	stateTimeoutValue[1] = 0.01;
	stateSequence[1] = "Activate";
	stateName[2] = "Ready";
	stateTransitionOnNoAmmo[2] = "NoAmmo";
	stateTransitionOnTriggerDown[2] = "Fire";
	stateName[3] = "Fire";
	stateTransitionOnTimeout[3] = "Reload";
	stateTimeoutValue[3] = 0.01;
	stateFire[3] = 1;
	stateRecoil[3] = LightRecoil;
	stateAllowImageChange[3] = 0;
	stateSequence[3] = "yoyo";
	stateScript[3] = "onFire";
	stateSound[3] = rafaleFireSound;
	stateName[4] = "Reload";
	stateTransitionOnNoAmmo[4] = "NoAmmo";
	stateTransitionOnTimeout[4] = "Ready";
	stateTimeoutValue[4] = 2;
	stateAllowImageChange[4] = 0;
	stateSequence[4] = "Fire";
	stateEjectShell[4] = 1;
	stateSound[4] = rafaleReloadSound;
	stateName[5] = "NoAmmo";
	stateTransitionOnAmmo[5] = "Reload";
	stateSequence[5] = "NoAmmo";
	stateTransitionOnTriggerDown[5] = "DryFire";
	stateName[6] = "DryFire";
	stateTimeoutValue[6] = 1;
	stateTransitionOnTimeout[6] = "NoAmmo";
	stateSound[6] = rafaleFireEmptySound;
};
function grenadeImage::onFire(%this, %obj, %slot)
{
	%obj.stop();
	%obj.setActionThread("fire");
	%projectile = %this.Projectile;
	if ($Server::MissionType !$= "Unlimited")
	{
		%obj.decInventory(%this.Ammo, 1);
	}
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
	if (%obj.getInventory(BdNexplosive) <= 0)
	{
		%obj.setInventory(Crossbow, 1);
		%obj.setInventory(CrossbowAmmo, 250);
		%obj.mountImage(CrossbowImage, 0);
	}
	return %p;
}

