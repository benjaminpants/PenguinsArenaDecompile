exec("~/data/shapes/player/player.cs");
$CorpseTimeoutValue = 2 * 1000;
$DamageLava = 0.009999999776482582;
$DamageHotLava = 0.009999999776482582;
$DamageCrustyLava = 0.009999999776482582;
$PlayerDeathAnim::TorsoFrontFallForward = 1;
$PlayerDeathAnim::TorsoFrontFallBack = 2;
$PlayerDeathAnim::TorsoBackFallForward = 3;
$PlayerDeathAnim::TorsoLeftSpinDeath = 4;
$PlayerDeathAnim::TorsoRightSpinDeath = 5;
$PlayerDeathAnim::LegsLeftGimp = 6;
$PlayerDeathAnim::LegsRightGimp = 7;
$PlayerDeathAnim::TorsoBackFallForward = 8;
$PlayerDeathAnim::HeadFrontDirect = 9;
$PlayerDeathAnim::HeadBackFallForward = 10;
$PlayerDeathAnim::ExplosionBlowBack = 11;
datablock AudioProfile(DeathCrySound)
{
	fileName = "~/data/sound/Creature_SmallA_Pain02.wav";
	description = AudioClose3d;
	preload = 1;
};
datablock AudioProfile(PainCrySound)
{
	fileName = "~/data/sound/HardHit2.wav";
	description = AudioClose3d;
	preload = 1;
};
datablock AudioProfile(ReincarnationSound)
{
	fileName = "~/data/sound/reincarnation.wav";
	description = AudioLoud3d;
	preload = 1;
};
datablock ParticleData(PlayerSplashMist)
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
	textureName = "~/data/shapes/player/splash";
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
datablock ParticleEmitterData(PlayerSplashMistEmitter)
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
	particles = "PlayerSplashMist";
};
datablock ParticleData(PlayerBubbleParticle)
{
	dragCoefficient = 0;
	gravityCoefficient = -0.5;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 400;
	lifetimeVarianceMS = 100;
	useInvAlpha = 0;
	textureName = "~/data/shapes/player/splash";
	colors[0] = "0.7 0.8 1.0 0.4";
	colors[1] = "0.7 0.8 1.0 0.4";
	colors[2] = "0.7 0.8 1.0 0.0";
	sizes[0] = 0.1;
	sizes[1] = 0.3;
	sizes[2] = 0.3;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(PlayerBubbleEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	ejectionOffset = 0.5;
	velocityVariance = 0.5;
	thetaMin = 0;
	thetaMax = 80;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	particles = "PlayerBubbleParticle";
};
datablock ParticleData(PlayerFoamParticle)
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
	textureName = "~/data/shapes/player/splash";
	colors[0] = "0.7 0.8 1.0 0.20";
	colors[1] = "0.7 0.8 1.0 0.20";
	colors[2] = "0.7 0.8 1.0 0.00";
	sizes[0] = 0.2;
	sizes[1] = 0.4;
	sizes[2] = 1.6;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(PlayerFoamEmitter)
{
	ejectionPeriodMS = 10;
	periodVarianceMS = 0;
	ejectionVelocity = 3;
	velocityVariance = 1;
	ejectionOffset = 0;
	thetaMin = 85;
	thetaMax = 85;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	particles = "PlayerFoamParticle";
};
datablock ParticleData(PlayerFoamDropletsParticle)
{
	dragCoefficient = 1;
	gravityCoefficient = 0.2;
	inheritedVelFactor = 0.2;
	constantAcceleration = -0;
	lifetimeMS = 600;
	lifetimeVarianceMS = 0;
	textureName = "~/data/shapes/player/splash";
	colors[0] = "0.7 0.8 1.0 1.0";
	colors[1] = "0.7 0.8 1.0 0.5";
	colors[2] = "0.7 0.8 1.0 0.0";
	sizes[0] = 0.8;
	sizes[1] = 0.3;
	sizes[2] = 0;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(PlayerFoamDropletsEmitter)
{
	ejectionPeriodMS = 7;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 1;
	ejectionOffset = 0;
	thetaMin = 60;
	thetaMax = 80;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	orientParticles = 1;
	particles = "PlayerFoamDropletsParticle";
};
datablock ParticleData(PlayerSplashParticle)
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
datablock ParticleEmitterData(PlayerSplashEmitter)
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
	particles = "PlayerSplashParticle";
};
datablock SplashData(PlayerSplash)
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
	Texture = "~/data/shapes/player/splash";
	emitter[0] = PlayerSplashEmitter;
	emitter[1] = PlayerSplashMistEmitter;
	colors[0] = "0.7 0.8 1.0 0.0";
	colors[1] = "0.7 0.8 1.0 0.3";
	colors[2] = "0.7 0.8 1.0 0.7";
	colors[3] = "0.7 0.8 1.0 0.0";
	times[0] = 0;
	times[1] = 0.4;
	times[2] = 0.8;
	times[3] = 1;
};
datablock ParticleData(snowballparticles3)
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
	sizes[0] = 0.1;
	sizes[1] = 0.1;
	sizes[2] = 0.1;
	times[0] = 0;
	times[1] = 0.5;
	times[2] = 1;
};
datablock ParticleEmitterData(snowballemitter3)
{
	ejectionPeriodMS = 100;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 1;
	thetaMin = 0;
	thetaMax = 180;
	lifetimeMS = 250;
	particles = "snowballparticles2";
};
datablock ParticleData(LightPuff)
{
	dragCoefficient = 2;
	gravityCoefficient = -0.009999999776482582;
	inheritedVelFactor = 0.6;
	constantAcceleration = 0;
	lifetimeMS = 800;
	lifetimeVarianceMS = 100;
	useInvAlpha = 1;
	spinRandomMin = -35;
	spinRandomMax = 35;
	colors[0] = "1.0 1.0 1.0 1.0";
	colors[1] = "1.0 1.0 1.0 0.0";
	sizes[0] = 0.1;
	sizes[1] = 0.8;
	times[0] = 0.3;
	times[1] = 1;
};
datablock ParticleEmitterData(LightPuffEmitter)
{
	ejectionPeriodMS = 35;
	periodVarianceMS = 10;
	ejectionVelocity = 0.2;
	velocityVariance = 0.1;
	ejectionOffset = 0;
	thetaMin = 20;
	thetaMax = 60;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	useEmitterColors = 1;
	particles = "LightPuff";
};
datablock ParticleData(LiftoffDust)
{
	dragCoefficient = 1;
	gravityCoefficient = -0.009999999776482582;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 1000;
	lifetimeVarianceMS = 100;
	useInvAlpha = 1;
	spinRandomMin = -90;
	spinRandomMax = 500;
	colors[0] = "1.0 1.0 1.0 1.0";
	sizes[0] = 1;
	times[0] = 1;
};
datablock ParticleEmitterData(LiftoffDustEmitter)
{
	ejectionPeriodMS = 5;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 0;
	ejectionOffset = 0;
	thetaMin = 90;
	thetaMax = 90;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvance = 0;
	useEmitterColors = 1;
	particles = "LiftoffDust";
};
datablock DecalData(PlayerFootprint)
{
	sizeX = 0.25;
	sizeY = 0.25;
	textureName = "~/data/shapes/player/footprint";
};
datablock DebrisData(PlayerDebris)
{
	explodeOnMaxBounce = 0;
	elasticity = 0.15;
	friction = 0.5;
	lifetime = 4;
	lifetimeVariance = 0;
	minSpinSpeed = 40;
	maxSpinSpeed = 600;
	numBounces = 5;
	bounceVariance = 0;
	staticOnMaxBounce = 1;
	gravModifier = 1;
	useRadiusMass = 1;
	baseRadius = 1;
	velocity = 20;
	velocityVariance = 12;
};
datablock PlayerData(PlayerBody)
{
	renderFirstPerson = 0;
	emap = 1;
	className = armor;
	shapeFile = "~/data/shapes/player/player.dts";
	cameraMaxDist = 3;
	computeCRC = 1;
	airControl = 0.4;
	canObserve = 1;
	cmdCategory = "Clients";
	cameraDefaultFov = 90;
	cameraMinFov = 5;
	cameraMaxFov = 120;
	aiAvoidThis = 1;
	minLookAngle = -1.399999976158142;
	maxLookAngle = 1.4;
	maxFreelookAngle = 3;
	mass = 90;
	drag = 0.15;
	maxDrag = 0.4;
	density = 10;
	maxDamage = 100;
	maxEnergy = 60;
	repairRate = 0.33;
	energyPerDamagePoint = 75;
	rechargeRate = 0.186;
	runForce = 48 * 90;
	runEnergyDrain = 0;
	minRunEnergy = 0;
	maxForwardSpeed = 14;
	maxBackwardSpeed = 13;
	maxSideSpeed = 13;
	maxUnderwaterForwardSpeed = 8.4;
	maxUnderwaterBackwardSpeed = 7.8;
	maxUnderwaterSideSpeed = 7.8;
	jumpForce = 10.5 * 90;
	jumpEnergyDrain = 0;
	minJumpEnergy = 0;
	jumpDelay = 0;
	recoverDelay = 9;
	recoverRunForceScale = 1.2;
	minImpactSpeed = 450;
	speedDamageScale = 0;
	boundingBox = "1.6 1.6 2.1";
	pickupRadius = 2;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.49;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
	footPuffEmitter = snowballemitter3;
	footPuffNumParts = 10;
	footPuffRadius = 0.25;
	Splash = PlayerSplash;
	splashVelocity = 4;
	splashAngle = 67;
	splashFreqMod = 300;
	splashVelEpsilon = 0.6;
	bubbleEmitTime = 0.4;
	splashEmitter[0] = PlayerFoamDropletsEmitter;
	splashEmitter[1] = PlayerFoamEmitter;
	splashEmitter[2] = PlayerBubbleEmitter;
	mediumSplashSoundVelocity = 10;
	hardSplashSoundVelocity = 20;
	exitSplashSoundVelocity = 5;
	runSurfaceAngle = 70;
	jumpSurfaceAngle = 80;
	minJumpSpeed = 20;
	maxJumpSpeed = 40;
	horizMaxSpeed = 68;
	horizResistSpeed = 33;
	horizResistFactor = 0.35;
	upMaxSpeed = 80;
	upResistSpeed = 25;
	upResistFactor = 0.3;
	footstepSplashHeight = 0.35;
	FootSoftSound = FootLightSoftSound;
	FootHardSound = FootLightHardSound;
	FootMetalSound = FootLightMetalSound;
	FootSnowSound = FootLightSnowSound;
	FootShallowSound = FootLightShallowSplashSound;
	FootWadingSound = FootLightWadingSound;
	FootUnderwaterSound = FootLightUnderwaterSound;
	groundImpactMinSpeed = 10;
	groundImpactShakeFreq = "4.0 4.0 4.0";
	groundImpactShakeAmp = "1.0 1.0 1.0";
	groundImpactShakeDuration = 0.8;
	groundImpactShakeFalloff = 10;
	observeParameters = "0.5 4.5 4.5";
	maxInv[Crossbow] = 1;
	maxInv[CrossbowAmmo] = 1000;
	maxInv[BdNgeanteW] = 1;
	maxInv[BdNgeante] = 1;
	maxInv[BdNexplosiveW] = 1;
	maxInv[BdNexplosive] = 1;
	maxInv[rafale] = 1;
	maxInv[rafaleAmmo] = 20;
	maxInv[griffes] = 1;
	maxInv[InvincibleB] = 1;
};
datablock PlayerData(PlayerBody2)
{
	renderFirstPerson = 0;
	emap = 1;
	className = armor;
	shapeFile = "~/data/shapes/player2/player.dts";
	cameraMaxDist = 3;
	computeCRC = 1;
	airControl = 0.4;
	canObserve = 1;
	cmdCategory = "Clients";
	cameraDefaultFov = 90;
	cameraMinFov = 5;
	cameraMaxFov = 120;
	debrisShapeName = "~/data/shapes/player2/debris_player.dts";
	Debris = PlayerDebris;
	aiAvoidThis = 1;
	minLookAngle = -1.399999976158142;
	maxLookAngle = 1.4;
	maxFreelookAngle = 3;
	mass = 90;
	drag = 0.15;
	maxDrag = 0.4;
	density = 10;
	maxDamage = 100;
	maxEnergy = 60;
	repairRate = 0.33;
	energyPerDamagePoint = 75;
	rechargeRate = 0.186;
	runForce = 48 * 90;
	runEnergyDrain = 0;
	minRunEnergy = 0;
	maxForwardSpeed = 14;
	maxBackwardSpeed = 13;
	maxSideSpeed = 13;
	maxUnderwaterForwardSpeed = 8.4;
	maxUnderwaterBackwardSpeed = 7.8;
	maxUnderwaterSideSpeed = 7.8;
	jumpForce = 10.5 * 90;
	jumpEnergyDrain = 0;
	minJumpEnergy = 0;
	jumpDelay = 0;
	recoverDelay = 9;
	recoverRunForceScale = 1.2;
	minImpactSpeed = 450;
	speedDamageScale = 0;
	boundingBox = "1.6 1.6 2.1";
	pickupRadius = 0.75;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.49;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
	DecalData = PlayerFootprint;
	decalOffset = 0.25;
	footPuffEmitter = LightPuffEmitter;
	footPuffNumParts = 10;
	footPuffRadius = 0.25;
	dustEmitter = LiftoffDustEmitter;
	Splash = PlayerSplash;
	splashVelocity = 4;
	splashAngle = 67;
	splashFreqMod = 300;
	splashVelEpsilon = 0.6;
	bubbleEmitTime = 0.4;
	splashEmitter[0] = PlayerFoamDropletsEmitter;
	splashEmitter[1] = PlayerFoamEmitter;
	splashEmitter[2] = PlayerBubbleEmitter;
	mediumSplashSoundVelocity = 10;
	hardSplashSoundVelocity = 20;
	exitSplashSoundVelocity = 5;
	runSurfaceAngle = 70;
	jumpSurfaceAngle = 80;
	minJumpSpeed = 20;
	maxJumpSpeed = 30;
	horizMaxSpeed = 68;
	horizResistSpeed = 33;
	horizResistFactor = 0.35;
	upMaxSpeed = 80;
	upResistSpeed = 25;
	upResistFactor = 0.3;
	footstepSplashHeight = 0.35;
	FootSoftSound = FootLightSoftSound;
	FootHardSound = FootLightHardSound;
	FootMetalSound = FootLightMetalSound;
	FootSnowSound = FootLightSnowSound;
	FootShallowSound = FootLightShallowSplashSound;
	FootWadingSound = FootLightWadingSound;
	FootUnderwaterSound = FootLightUnderwaterSound;
	groundImpactMinSpeed = 10;
	groundImpactShakeFreq = "4.0 4.0 4.0";
	groundImpactShakeAmp = "1.0 1.0 1.0";
	groundImpactShakeDuration = 0.8;
	groundImpactShakeFalloff = 10;
	observeParameters = "0.5 4.5 4.5";
	maxInv[Crossbow] = 1;
	maxInv[CrossbowAmmo] = 1000;
	maxInv[BdNgeante] = 1;
	maxInv[BdNexplosive] = 1;
	maxInv[rafale] = 1;
	maxInv[rafaleAmmo] = 20;
	maxInv[griffes] = 1;
	maxInv[InvincibleB] = 1;
};
datablock PlayerData(PlayerBody3)
{
	renderFirstPerson = 0;
	emap = 1;
	className = armor;
	shapeFile = "~/data/shapes/player3/player.dts";
	cameraMaxDist = 3;
	computeCRC = 1;
	airControl = 0.4;
	canObserve = 1;
	cmdCategory = "Clients";
	cameraDefaultFov = 90;
	cameraMinFov = 5;
	cameraMaxFov = 120;
	debrisShapeName = "~/data/shapes/player3/debris_player.dts";
	Debris = PlayerDebris;
	aiAvoidThis = 1;
	minLookAngle = -1.399999976158142;
	maxLookAngle = 1.4;
	maxFreelookAngle = 3;
	mass = 90;
	drag = 0.15;
	maxDrag = 0.4;
	density = 10;
	maxDamage = 100;
	maxEnergy = 60;
	repairRate = 0.33;
	energyPerDamagePoint = 75;
	rechargeRate = 0.186;
	runForce = 48 * 90;
	runEnergyDrain = 0;
	minRunEnergy = 0;
	maxForwardSpeed = 14;
	maxBackwardSpeed = 13;
	maxSideSpeed = 13;
	maxUnderwaterForwardSpeed = 8.4;
	maxUnderwaterBackwardSpeed = 7.8;
	maxUnderwaterSideSpeed = 7.8;
	jumpForce = 10.5 * 90;
	jumpEnergyDrain = 0;
	minJumpEnergy = 0;
	jumpDelay = 0;
	recoverDelay = 9;
	recoverRunForceScale = 1.2;
	minImpactSpeed = 450;
	speedDamageScale = 0;
	boundingBox = "1.6 1.6 2.1";
	pickupRadius = 0.75;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.49;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
	DecalData = PlayerFootprint;
	decalOffset = 0.25;
	footPuffEmitter = LightPuffEmitter;
	footPuffNumParts = 10;
	footPuffRadius = 0.25;
	dustEmitter = LiftoffDustEmitter;
	Splash = PlayerSplash;
	splashVelocity = 4;
	splashAngle = 67;
	splashFreqMod = 300;
	splashVelEpsilon = 0.6;
	bubbleEmitTime = 0.4;
	splashEmitter[0] = PlayerFoamDropletsEmitter;
	splashEmitter[1] = PlayerFoamEmitter;
	splashEmitter[2] = PlayerBubbleEmitter;
	mediumSplashSoundVelocity = 10;
	hardSplashSoundVelocity = 20;
	exitSplashSoundVelocity = 5;
	runSurfaceAngle = 70;
	jumpSurfaceAngle = 80;
	minJumpSpeed = 20;
	maxJumpSpeed = 30;
	horizMaxSpeed = 68;
	horizResistSpeed = 33;
	horizResistFactor = 0.35;
	upMaxSpeed = 80;
	upResistSpeed = 25;
	upResistFactor = 0.3;
	footstepSplashHeight = 0.35;
	FootSoftSound = FootLightSoftSound;
	FootHardSound = FootLightHardSound;
	FootMetalSound = FootLightMetalSound;
	FootSnowSound = FootLightSnowSound;
	FootShallowSound = FootLightShallowSplashSound;
	FootWadingSound = FootLightWadingSound;
	FootUnderwaterSound = FootLightUnderwaterSound;
	groundImpactMinSpeed = 10;
	groundImpactShakeFreq = "4.0 4.0 4.0";
	groundImpactShakeAmp = "1.0 1.0 1.0";
	groundImpactShakeDuration = 0.8;
	groundImpactShakeFalloff = 10;
	observeParameters = "0.5 4.5 4.5";
	maxInv[Crossbow] = 1;
	maxInv[CrossbowAmmo] = 1000;
	maxInv[BdNgeante] = 1;
	maxInv[BdNexplosive] = 1;
	maxInv[rafale] = 1;
	maxInv[rafaleAmmo] = 20;
	maxInv[griffes] = 1;
	maxInv[InvincibleB] = 1;
};
datablock PlayerData(PlayerBody4)
{
	renderFirstPerson = 0;
	emap = 1;
	className = armor;
	shapeFile = "~/data/shapes/player4/player.dts";
	cameraMaxDist = 3;
	computeCRC = 1;
	airControl = 0.4;
	canObserve = 1;
	cmdCategory = "Clients";
	cameraDefaultFov = 90;
	cameraMinFov = 5;
	cameraMaxFov = 120;
	debrisShapeName = "~/data/shapes/player4/debris_player.dts";
	Debris = PlayerDebris;
	aiAvoidThis = 1;
	minLookAngle = -1.399999976158142;
	maxLookAngle = 1.4;
	maxFreelookAngle = 3;
	mass = 90;
	drag = 0.15;
	maxDrag = 0.4;
	density = 10;
	maxDamage = 100;
	maxEnergy = 60;
	repairRate = 0.33;
	energyPerDamagePoint = 75;
	rechargeRate = 0.186;
	runForce = 48 * 90;
	runEnergyDrain = 0;
	minRunEnergy = 0;
	maxForwardSpeed = 14;
	maxBackwardSpeed = 13;
	maxSideSpeed = 13;
	maxUnderwaterForwardSpeed = 8.4;
	maxUnderwaterBackwardSpeed = 7.8;
	maxUnderwaterSideSpeed = 7.8;
	jumpForce = 10.5 * 90;
	jumpEnergyDrain = 0;
	minJumpEnergy = 0;
	jumpDelay = 0;
	recoverDelay = 9;
	recoverRunForceScale = 1.2;
	minImpactSpeed = 450;
	speedDamageScale = 0;
	boundingBox = "1.6 1.6 2.1";
	pickupRadius = 0.75;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.49;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
	DecalData = PlayerFootprint;
	decalOffset = 0.25;
	footPuffEmitter = LightPuffEmitter;
	footPuffNumParts = 10;
	footPuffRadius = 0.25;
	dustEmitter = LiftoffDustEmitter;
	Splash = PlayerSplash;
	splashVelocity = 4;
	splashAngle = 67;
	splashFreqMod = 300;
	splashVelEpsilon = 0.6;
	bubbleEmitTime = 0.4;
	splashEmitter[0] = PlayerFoamDropletsEmitter;
	splashEmitter[1] = PlayerFoamEmitter;
	splashEmitter[2] = PlayerBubbleEmitter;
	mediumSplashSoundVelocity = 10;
	hardSplashSoundVelocity = 20;
	exitSplashSoundVelocity = 5;
	runSurfaceAngle = 70;
	jumpSurfaceAngle = 80;
	minJumpSpeed = 20;
	maxJumpSpeed = 30;
	horizMaxSpeed = 68;
	horizResistSpeed = 33;
	horizResistFactor = 0.35;
	upMaxSpeed = 80;
	upResistSpeed = 25;
	upResistFactor = 0.3;
	footstepSplashHeight = 0.35;
	FootSoftSound = FootLightSoftSound;
	FootHardSound = FootLightHardSound;
	FootMetalSound = FootLightMetalSound;
	FootSnowSound = FootLightSnowSound;
	FootShallowSound = FootLightShallowSplashSound;
	FootWadingSound = FootLightWadingSound;
	FootUnderwaterSound = FootLightUnderwaterSound;
	groundImpactMinSpeed = 10;
	groundImpactShakeFreq = "4.0 4.0 4.0";
	groundImpactShakeAmp = "1.0 1.0 1.0";
	groundImpactShakeDuration = 0.8;
	groundImpactShakeFalloff = 10;
	observeParameters = "0.5 4.5 4.5";
	maxInv[Crossbow] = 1;
	maxInv[CrossbowAmmo] = 1000;
	maxInv[BdNgeante] = 1;
	maxInv[BdNexplosive] = 1;
	maxInv[rafale] = 1;
	maxInv[rafaleAmmo] = 20;
	maxInv[griffes] = 1;
	maxInv[InvincibleB] = 1;
};
datablock PlayerData(PlayerBodyObserver)
{
	renderFirstPerson = 1;
	emap = 1;
	className = armor;
	shapeFile = "~/data/shapes/deadPlayer/fantome.dts";
	cameraMaxDist = 3;
	computeCRC = 1;
	canObserve = 1;
	cmdCategory = "Clients";
	cameraDefaultFov = 90;
	cameraMinFov = 5;
	cameraMaxFov = 120;
	debrisShapeName = "~/data/shapes/player4/debris_player.dts";
	Debris = PlayerDebris;
	aiAvoidThis = 1;
	minLookAngle = -1.399999976158142;
	maxLookAngle = 1.4;
	maxFreelookAngle = 3;
	mass = 1E-07;
	drag = 31;
	maxDrag = 31;
	density = 10;
	maxDamage = 100;
	maxEnergy = 60;
	repairRate = 0.33;
	energyPerDamagePoint = 75;
	rechargeRate = 0.756;
	runForce = 48 * 90;
	runEnergyDrain = 0;
	minRunEnergy = 0;
	maxForwardSpeed = 14;
	maxBackwardSpeed = 13;
	maxSideSpeed = 13;
	maxUnderwaterForwardSpeed = 8.4;
	maxUnderwaterBackwardSpeed = 7.8;
	maxUnderwaterSideSpeed = 7.8;
	jumpForce = 8.300000190734863 * 90;
	jumpEnergyDrain = 0;
	minJumpEnergy = 0;
	jumpDelay = 15;
	recoverDelay = 9;
	recoverRunForceScale = 1.2;
	minImpactSpeed = 450;
	speedDamageScale = 0;
	boundingBox = "1.2 1.2 2.3";
	pickupRadius = 0.75;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.49;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
	DecalData = PlayerFootprint;
	decalOffset = 0.25;
	footPuffEmitter = LightPuffEmitter;
	footPuffNumParts = 10;
	footPuffRadius = 0.25;
	dustEmitter = LiftoffDustEmitter;
	Splash = PlayerSplash;
	splashVelocity = 4;
	splashAngle = 67;
	splashFreqMod = 300;
	splashVelEpsilon = 0.6;
	bubbleEmitTime = 0.4;
	splashEmitter[0] = PlayerFoamDropletsEmitter;
	splashEmitter[1] = PlayerFoamEmitter;
	splashEmitter[2] = PlayerBubbleEmitter;
	mediumSplashSoundVelocity = 10;
	hardSplashSoundVelocity = 20;
	exitSplashSoundVelocity = 5;
	runSurfaceAngle = 70;
	jumpSurfaceAngle = 80;
	minJumpSpeed = 20;
	maxJumpSpeed = 30;
	horizMaxSpeed = 68;
	horizResistSpeed = 33;
	horizResistFactor = 0.35;
	upMaxSpeed = 80;
	upResistSpeed = 25;
	upResistFactor = 0.3;
	footstepSplashHeight = 0.35;
	groundImpactMinSpeed = 10;
	groundImpactShakeFreq = "4.0 4.0 4.0";
	groundImpactShakeAmp = "1.0 1.0 1.0";
	groundImpactShakeDuration = 0.8;
	groundImpactShakeFalloff = 10;
	observeParameters = "0.5 4.5 4.5";
	maxInv[observAmmo] = 100;
	maxInv[observ] = 1;
};
function armor::onAdd(%this, %obj)
{
	%obj.mountVehicle = 1;
	%obj.setRechargeRate(%this.rechargeRate);
	%obj.setRepairRate(0);
}

function armor::onRemove(%this, %obj)
{
	if (%obj.client.Player == %obj)
	{
		%obj.client.Player = 0;
	}
}

function armor::onNewDataBlock(%this, %obj)
{
}

function armor::onMount(%this, %obj, %vehicle, %node)
{
	if (%node == 0)
	{
		%obj.setTransform("0 0 0 0 0 1 0");
		%obj.setActionThread(%vehicle.getDataBlock().mountPose[%node], 1, 1);
		%obj.lastWeapon = %obj.getMountedImage($WeaponSlot);
		%obj.unmountImage($WeaponSlot);
		%obj.setControlObject(%vehicle);
		%obj.client.setObjectActiveImage(%vehicle, 2);
	}
}

function armor::onUnmount(%this, %obj, %vehicle, %node)
{
	if (%node == 0)
	{
		%obj.mountImage(%obj.lastWeapon, $WeaponSlot);
	}
}

function armor::doDismount(%this, %obj, %forced)
{
	if (!%obj.isMounted())
	{
		return;
	}
	%pos = getWords(%obj.getTransform(), 0, 2);
	%oldPos = %pos;
	%vec[0] = " 0  0  1";
	%vec[1] = " 0  0  1";
	%vec[2] = " 0  0 -1";
	%vec[3] = " 1  0  0";
	%vec[4] = "-1  0  0";
	%impulseVec = "0 0 0";
	%vec[0] = MatrixMulVector(%obj.getTransform(), %vec[0]);
	%pos = "0 0 0";
	%numAttempts = 5;
	%success = -1;
	for (%i = 0; %i < %numAttempts; %i++)
	{
		%pos = VectorAdd(%oldPos, VectorScale(%vec[%i], 3));
		if (%obj.checkDismountPoint(%oldPos, %pos))
		{
			%success = %i;
			%impulseVec = %vec[%i];
			break;
		}
	}
	if (%forced && %success == -1)
	{
		%pos = %oldPos;
	}
	%obj.mountVehicle = 0;
	%obj.schedule(4000, "mountVehicles", 1);
	%obj.setTransform(%pos);
	%obj.applyImpulse(%pos, VectorScale(%impulseVec, %obj.getDataBlock().mass));
	%obj.setPilot(0);
	%obj.vehicleTurret = "";
}

function armor::onCollision(%this, %obj, %col)
{
	if (%obj.getState() $= "Dead")
	{
		return;
	}
	if (%col.getClassName() $= "Item")
	{
		%obj.pickup(%col);
	}
	if (%col.getClassName() $= "AIPlayer" && %obj.lastCollisionPlayer != %col)
	{
		%vec = %obj.getVelocityFromPlayerColl();
		if (%vec != 0)
		{
			%col.applyImpulse(getWords(%col.getTransform(), 0, 2), VectorScale(%vec, 1.3));
			%obj.lastCollisionPlayer = %col;
			%obj.schedule(250, removeLastCollisionPlayer, %obj);
		}
	}
}

function Player::removeLastCollisionPlayer(%this, %obj)
{
	%obj.lastCollisionPlayer = "";
}

function armor::onImpact(%this, %obj, %__unused, %vec, %vecLen)
{
	%obj.Damage(0, VectorAdd(%obj.getPosition(), %vec), %vecLen * %this.speedDamageScale, "Impact");
}

function Player::enleverHITinvincible(%this)
{
	if (%this.getSkinName() $= "HITinvincible")
	{
		%this.setSkinName("invincible");
	}
}

function armor::Damage(%this, %obj, %sourceObject, %__unused, %damage, %damageType)
{
	if (%obj.getState() $= "Dead")
	{
		return;
	}
	%obj.applyDamage(%damage);
	%location = "Body";
	%client = %obj.client;
	%sourceClient = %sourceObject ? %sourceObject.client : "0";
	if (%obj.getState() $= "Dead")
	{
		if (%obj.getControllingClient())
		{
			%obj.getControllingClient().onDeath(%sourceObject, %sourceClient, %damageType, %location);
		}
		else if (%client && %client.isAIControlled())
		{
			%client.onDeath(%sourceObject, %sourceClient, %damageType, %location);
		}
		else
		{
			%obj.onDeath();
		}
	}
}

function armor::onDamage(%this, %obj, %__unused)
{
}

function armor::onDisabled(%this, %obj, %__unused)
{
	%obj.playDeathCry();
	%obj.setImageTrigger(0, 0);
	%obj.schedule($CorpseTimeoutValue - 1000, "startFade", 1000, 0, 1);
}

function armor::onLeaveMissionArea(%this, %obj)
{
	%obj.client.onLeaveMissionArea();
}

function armor::onEnterMissionArea(%this, %obj)
{
	%obj.client.onEnterMissionArea();
}

function armor::onEnterLiquid(%this, %obj, %__unused, %type)
{
	if (%type == 0)
	{
	}
	else if (%type == 1)
	{
	}
	else if (%type == 2)
	{
	}
	else if (%type == 3)
	{
	}
	else if (%type == 4)
	{
	}
	else if (%type == 5)
	{
	}
	else if (%type == 6)
	{
	}
	else if (%type == 7)
	{
	}
}

function armor::onLeaveLiquid(%this, %obj, %type)
{
	%obj.clearDamageDt();
}

function armor::onTrigger(%this, %obj, %__unused, %__unused)
{
}

function Player::kill(%this, %damageType)
{
	%this.Damage(0, %this.getPosition(), 10000, %damageType);
}

function Player::playDeathAnimation(%this)
{
}

function Player::playCelAnimation(%this, %__unused)
{
}

function Player::playDeathCry(%this)
{
	%this.playAudio(2, DeathCrySound);
}

function Player::playPain(%this)
{
	%this.playAudio(2, PainCrySound);
}

function Player::playReincarnationSound(%this)
{
	%this.playAudio(3, ReincarnationSound);
}

function Player::playReincarnation(%this)
{
	if (%this.getMountedImage(2))
	{
		%this.unmountImage(ReincarnationImage, 2);
	}
	if (%this.getMountedImage(3))
	{
		%this.unmountImage(ReincarnationImage, 3);
	}
	%this.mountImage(ReincarnationImage, 3);
	%this.schedule(800, "unmountImage", 3);
	%this.reincarnationInvincible = 1;
	%this.schedule(1300, "unReincarnationInvincible");
	if (%this.client && %this.client.isAIControlled())
	{
		spawnExplosion(%this.getTransform(), "0 0 1", 0, "ReincarnationExplosionAI");
	}
	else
	{
		spawnExplosion(%this.getTransform(), "0 0 1", 0, "ReincarnationExplosion");
	}
	if (%this.client)
	{
		if (%this.client.isAIControlled())
		{
			%this.mountImage(PlayerTagAIImage, 7);
		}
		else
		{
			%this.mountImage(PlayerTagImage, 7);
		}
	}
	%this.setActionThread("reincarnation");
	%this.playReincarnationSound();
}

datablock ParticleData(ReincarnationParticleAI)
{
	textureName = "~/data/shapes/particles/star_ai.png";
	dragCoeffiecient = 0;
	gravityCoefficient = 0;
	inheritedVelFactor = 1;
	constantAcceleration = 0;
	lifetimeMS = 1000;
	lifetimeVarianceMS = 0;
	useInvAlpha = 1;
	spinRandomMin = 0;
	spinRandomMax = 0;
	colors[0] = "1 1 1 1";
	colors[1] = "1 1 1 0";
	sizes[0] = 0.3;
	sizes[1] = 1;
	times[0] = 0;
	times[1] = 1;
};
datablock ParticleData(ReincarnationParticle)
{
	textureName = "~/data/shapes/particles/star.png";
	dragCoeffiecient = 0;
	gravityCoefficient = 0;
	inheritedVelFactor = 1;
	constantAcceleration = 0;
	lifetimeMS = 1000;
	lifetimeVarianceMS = 0;
	useInvAlpha = 1;
	spinRandomMin = 0;
	spinRandomMax = 0;
	colors[0] = "1 1 1 1";
	colors[1] = "1 1 1 0";
	sizes[0] = 0.3;
	sizes[1] = 1;
	times[0] = 0;
	times[1] = 1;
};
datablock ParticleEmitterData(ReincarnationEmitter)
{
	ejectionPeriodMS = 30;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 1;
	thetaMin = 0;
	thetaMax = 180;
	lifetimeMS = 250;
	particles = ReincarnationParticle;
};
datablock ParticleEmitterData(ReincarnationEmitterAI)
{
	ejectionPeriodMS = 30;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 1;
	thetaMin = 0;
	thetaMax = 180;
	lifetimeMS = 250;
	particles = ReincarnationParticleAI;
};
datablock ExplosionData(ReincarnationExplosion)
{
	lifetimeMS = 100;
	particleEmitter = ReincarnationEmitter;
	particleDensity = 30;
	particleRadius = 1;
};
datablock ExplosionData(ReincarnationExplosionAI)
{
	lifetimeMS = 100;
	particleEmitter = ReincarnationEmitterAI;
	particleDensity = 30;
	particleRadius = 1;
};
datablock ShapeBaseImageData(ReincarnationImage)
{
	shapeFile = "~/data/shapes/particles/reincarnation.dts";
	emap = 1;
	MountPoint = 5;
	eyeOffset = "0 0 0";
};
datablock ShapeBaseImageData(PlayerTagImage)
{
	shapeFile = "~/data/shapes/particles/playertag.dts";
	emap = 1;
	MountPoint = 5;
	eyeOffset = "0 0 0";
};
datablock ShapeBaseImageData(PlayerTagAIImage)
{
	shapeFile = "~/data/shapes/particles/playertag_ai.dts";
	emap = 1;
	MountPoint = 5;
	eyeOffset = "0 0 0";
};
datablock ShapeBaseImageData(CrownImage)
{
	shapeFile = "~/data/shapes/couronne/couronne.dts";
	firstPerson = 0;
	emap = 1;
	MountPoint = 6;
};
function Player::unReincarnationInvincible(%this)
{
	%this.reincarnationInvincible = 0;
}

