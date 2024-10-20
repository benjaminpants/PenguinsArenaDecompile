datablock AudioProfile(ImpactGeante)
{
	fileName = "~/data/sound/impact_geante.wav";
	description = AudioDefault3d;
	preload = 1;
};
datablock ItemData(BdNgeante)
{
	category = "Ammo";
	className = "Ammo";
	shapeFile = "~/data/shapes/bonus/BdNgeante/BdNgeante.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "Boule de neige geante";
};
function BdNgeante::onAdd(%this, %obj)
{
	%obj.playThread(0, "idle");
}

function BdNgeante::onPickup(%this, %obj, %user, %__unused)
{
	%user.setInventory(rafaleAmmo, 0);
	%user.setInventory(BdNexplosive, 0);
	%user.setInventory(BdNexplosiveW, 0);
	%user.mountImage(geanteImage, 0);
	%user.setInventory(BdNgeanteW, 1);
	%user.setInventory(BdNgeante, 1);
	if (%user.client)
	{
		commandToClient(%user.client, 'GotBonus', "BdNgeante");
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

datablock ItemData(BdNgeanteW)
{
	category = "Weapon";
	className = "Weapon";
	shapeFile = "~/data/shapes/bonus/BdNgeante/BdNgeante.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "a geante";
	image = geanteImage;
};
datablock ParticleData(Mineparticles3)
{
	textureName = "~/data/shapes/particles/explosion_rouge";
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
	colors[1] = "1 0.5 0.5 1";
	colors[2] = "1 0 0 0";
	sizes[0] = 1;
	sizes[1] = 10;
	sizes[2] = 15;
	times[0] = 0;
	times[1] = 0.2;
	times[2] = 1;
};
datablock ParticleEmitterData(Mineemitter3)
{
	ejectionPeriodMS = 100;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0;
	thetaMin = 0;
	thetaMax = 0;
	lifetimeMS = 100;
	particles = Mineparticles3;
};
datablock DebrisData(GeanteExplosionDebris)
{
	shapeFile = "~/data/shapes/bonus/BdNgeante/debris.dts";
	elasticity = 0.8;
	friction = 0.5;
	numBounces = 1;
	bounceVariance = 0;
	explodeOnMaxBounce = 0;
	staticOnMaxBounce = 0;
	snapOnMaxBounce = 0;
	minSpinSpeed = 0;
	maxSpinSpeed = 180;
	render2D = 0;
	lifetime = 3;
	lifetimeVariance = 0.4;
	velocity = 20;
	velocityVariance = 0.5;
	fade = 1;
	useRadiusMass = 0;
	baseRadius = 2;
	gravModifier = 1;
	terminalVelocity = 20;
	ignoreWater = 1;
};
datablock ExplosionData(MineExplosion)
{
	lifetimeMS = 300;
	particleDensity = 5;
	particleRadius = 1;
	emitter[2] = Mineemitter3;
	shakeCamera = 1;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10;
	Debris = GeanteExplosionDebris;
	debrisThetaMin = 0;
	debrisThetaMax = 60;
	debrisPhiMin = 0;
	debrisPhiMax = 360;
	debrisNum = 2;
	debrisNumVariance = 1;
	debrisVelocity = 15;
	debrisVelocityVariance = 2;
};
datablock ProjectileData(BdNgeanteProjectile)
{
	projectileShapeName = "~/data/shapes/bonus/BdNgeante/projectile.dts";
	directDamage = 0;
	radiusDamage = 0;
	damageRadius = 3.9;
	areaImpulse = 1400;
	Explosion = MineExplosion;
	particleEmitter = snowballemitter2;
	particleWaterEmitter = CrossbowBoltBubbleEmitter;
	Splash = CrossbowSplash;
	muzzleVelocity = 45;
	velInheritFactor = 0.3;
	armingDelay = 0;
	lifetime = 3000;
	fadeDelay = 3000;
	bounceElasticity = 0;
	bounceFriction = 0;
	isBallistic = 0;
	gravityMod = 0.3;
	hasLight = 0;
	hasWaterLight = 0;
};
function BdNgeanteProjectile::onCollision(%this, %obj, %col, %__unused, %pos, %__unused)
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
				%col.teamResponsibleForDeath = %obj.teamId;
				%col.playAudio(2, ImpactGeante);
				%kickBack = 8000;
				if (%col.getMountedImage(2) != 0 && %col.getMountedImage(3) != 0)
				{
					%kickBack -= 4000;
				}
				%direction_expulsion = VectorSub(%obj.getoldPosition(), %pos);
				%direction_expulsion = VectorNormalize(%direction_expulsion);
				%direction_expulsion = VectorScale(%direction_expulsion, -%kickBack);
				%col.applyImpulse(%obj.getoldPosition(), %direction_expulsion);
				if ($debugVisualDebug)
				{
					vdtVector(%obj.getoldPosition(), %direction_expulsion, VectorLen(%direction_expulsion) / 1000, 6000, "0.3 0.3 0.7 1.0", 0);
				}
				%col.stop();
				if (getWord(%direction_expulsion, 2) > 0)
				{
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
				if ($pref::Frogames::optionsSet == 3)
				{
					%col.setSkinName("hit");
					%col.schedule(1000, setSkinName, "base");
				}
			}
		}
	}
	radiusDamageImpulse(%obj, %pos, %this.damageRadius, %this.radiusDamage, "Radius", %this.areaImpulse);
}

datablock ShapeBaseImageData(geanteImage)
{
	shapeFile = "~/data/shapes/bonus/BdNgeante/weapon.dts";
	emap = 1;
	MountPoint = 0;
	offset = "0 0 1";
	eyeOffset = "0.2 0.5 0.1";
	correctMuzzleVector = 0;
	className = "WeaponImage";
	Item = BdNgeanteW;
	Ammo = BdNgeante;
	Projectile = BdNgeanteProjectile;
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
	stateTimeoutValue[4] = 1.1;
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
function geanteImage::onFire(%this, %obj, %slot)
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
		teamId = %obj.team_id;
	};
	MissionCleanup.add(%p);
	if (%obj.getInventory(BdNgeante) <= 0)
	{
		%obj.setInventory(Crossbow, 1);
		%obj.setInventory(CrossbowAmmo, 500);
		%obj.mountImage(CrossbowImage, 0);
	}
	return %p;
}

