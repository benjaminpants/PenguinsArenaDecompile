datablock AudioProfile(ImpactCCSound)
{
	fileName = "~/data/sound/impact_cc.wav";
	description = AudioDefault3d;
	preload = 1;
};
datablock AudioProfile(NoImpactCCSound)
{
	fileName = "~/data/sound/CaC_miss.wav";
	description = AudioDefault3d;
	preload = 1;
};
datablock ItemData(coup_de_poing)
{
	category = "Weapon";
	className = "Weapon";
	shapeFile = "~/data/shapes/bonus/coupdepoing/weapon.dts";
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	emap = 1;
	pickUpName = "coup de poing";
	image = coup_de_poingImage;
};
datablock ParticleData(coup_de_poingParticle)
{
	textureName = "~/data/shapes/particles/cc";
	dragCoefficient = 2;
	gravityCoefficient = 0.2;
	inheritedVelFactor = 0.2;
	constantAcceleration = 0;
	lifetimeMS = 300;
	lifetimeVarianceMS = 0;
	colors[0] = "1 1 1 1.0";
	colors[1] = "1 1 1 1.0";
	colors[2] = "1 1 1 1.0";
	sizes[0] = 0.2;
	sizes[1] = 3;
	sizes[2] = 0.2;
	times[0] = 0;
	times[1] = 0.3;
	times[2] = 1;
};
datablock ParticleEmitterData(coup_de_poingEmitter)
{
	ejectionPeriodMS = 200;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 1;
	ejectionOffset = 0;
	thetaMin = 0;
	thetaMax = 60;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvances = 0;
	particles = "coup_de_poingParticle";
};
datablock ParticleData(coup_de_poingSmoke)
{
	textureName = "~/data/shapes/particles/cc";
	dragCoefficient = 2;
	gravityCoefficient = 0.2;
	inheritedVelFactor = 0.2;
	constantAcceleration = 0;
	lifetimeMS = 500;
	lifetimeVarianceMS = 0;
	colors[0] = "1 1 1 1.0";
	colors[1] = "1 1 1 1.0";
	colors[2] = "1 1 1 0";
	sizes[0] = 8;
	sizes[1] = 10;
	sizes[2] = 9;
	times[0] = 0;
	times[1] = 0.3;
	times[2] = 1;
};
datablock ParticleEmitterData(coup_de_poingSmokeEmitter)
{
	ejectionPeriodMS = 51;
	periodVarianceMS = 0;
	ejectionVelocity = 4;
	velocityVariance = 0.5;
	thetaMin = 0;
	thetaMax = 180;
	lifetimeMS = 250;
	particles = "coup_de_poingSmoke";
};
datablock ExplosionData(coup_de_poingExplosion)
{
	lifetimeMS = 100;
	particleEmitter = coup_de_poingEmitter;
	particleDensity = 1;
	particleRadius = 0.1;
	emitter[0] = coup_de_poingSmokeEmitter;
	shakeCamera = 1;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "0.7 0.7 0.7";
	camShakeDuration = 1.5;
	camShakeRadius = 5;
	lightStartRadius = 6;
	lightEndRadius = 3;
	lightStartColor = "0.5 0.5 0";
	lightEndColor = "0 0 0";
};
datablock ShapeBaseImageData(coup_de_poingImage)
{
	shapeFile = "~/data/shapes/bonus/coupdepoing/weapon.dts";
	emap = 1;
	MountPoint = 1;
	eyeOffset = "0.1 0.4 -0.8";
	correctMuzzleVector = 0;
	className = "WeaponImage";
	Item = coup_de_poing;
	ammo = CrossbowAmmo;
	Projectile = CrossbowProjectile;
	projectileType = Projectile;
	stateName[0] = "Preactivate";
	stateTransitionOnLoaded[0] = "Activate";
	stateName[1] = "Activate";
	stateTransitionOnTimeout[1] = "Ready";
	stateTimeoutValue[1] = 0.6;
	stateSequence[1] = "Activate";
	stateName[2] = "Ready";
	stateTransitionOnTriggerDown[2] = "Fire";
	stateName[3] = "Fire";
	stateTransitionOnTimeout[3] = "Reload";
	stateTimeoutValue[3] = 0.4;
	stateFire[3] = 1;
	stateRecoil[3] = LightRecoil;
	stateAllowImageChange[3] = 0;
	stateSequence[3] = "fight1";
	stateScript[3] = "onFire";
	stateName[4] = "Reload";
	stateTransitionOnTimeout[4] = "Ready";
	stateTimeoutValue[4] = 0;
	stateAllowImageChange[4] = 0;
	stateEjectShell[4] = 1;
};
function coup_de_poingImage::onFire(%__unused, %obj, %__unused)
{
	if ($debugVisualDebug)
	{
		vdtVector(%obj.getEyeTransform(), %obj.getEyeVector(), 4.5, 6000, "0.0 1.0 1.0 1.0", 1);
	}
	%startvec = %obj.getEyeTransform();
	%endvec = VectorAdd(%obj.getEyeTransform(), VectorScale(%obj.getEyeVector(), 4.5));
	%searchResult = containerRayCast(%startvec, %endvec, $TypeMasks::PlayerObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType, %obj);
	%foundObject = getWord(%searchResult, 0);
	if (%foundObject && %foundObject.getType() & $TypeMasks::PlayerObjectType)
	{
		if (%foundObject.reincarnationInvincible)
		{
			%foundObject.playAudio(2, EffetInvincibleSound);
		}
		else
		{
			%direction = VectorSub(%foundObject.getWorldBoxCenter(), %obj.getPosition());
			%direction = VectorNormalize(%direction);
			%velocity = VectorNormalize(%obj.getVelocity());
			%directionImpulse2 = VectorAdd(VectorScale(%velocity, 100 * VectorLen(%obj.getVelocity())), VectorScale(%direction, 900));
			%foundObject.applyImpulse(%foundObject.getPosition(), %directionImpulse2);
			%foundObject.setActionThread("hit");
			if ($pref::Frogames::optionsSet == 3)
			{
				if (%foundObject.getMountedImage(2) && !%foundObject.getMountedImage(3))
				{
					%foundObject.setSkinName("HITinvincible");
					%foundObject.schedule(1000, enleverHITinvincible);
				}
				else
				{
					%foundObject.setSkinName("hit");
					%foundObject.schedule(1000, setSkinName, "base");
				}
			}
			spawnExplosion(%foundObject.getWorldBoxCenter(), "0 0 1", 0, "coup_de_poingExplosion");
			%foundObject.playAudio(2, ImpactCCSound);
			if (%foundObject.client)
			{
				commandToClient(%foundObject.client, 'CaChit');
			}
			if (%obj.client)
			{
				commandToClient(%obj.client, 'CaCtouche', 180);
			}
		}
	}
	else
	{
		%obj.playAudio(2, NoImpactCCSound);
	}
}

