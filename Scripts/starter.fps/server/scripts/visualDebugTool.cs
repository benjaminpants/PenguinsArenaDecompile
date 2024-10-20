$VDT_PLAYER_Z_OFFSET = 2.4000000953674316;
function ObjectBuilderGui::buildDebugVector(%this)
{
	%this.className = "DebugVector";
	%this.process();
}

function vdtVector(%position, %vector, %length, %duration, %color, %alwaysVisible)
{
	%obj = new DebugVector()
	{
		position = %position;
		color = %color;
		vector = %vector;
		length = %length;
		alwaysVisible = %alwaysVisible;
		duration = %duration;
		format = 1;
	};
	return %obj;
}

function vdtSphere(%position, %radius, %duration, %color, %alwaysVisible)
{
	%obj = new DebugVector()
	{
		position = %position;
		color = %color;
		vector = "1.0 0.0 0.0";
		length = %radius;
		alwaysVisible = %alwaysVisible;
		duration = %duration;
		format = 2;
	};
	return %obj;
}

function vdtPoint(%position, %size, %duration, %color, %alwaysVisible)
{
	%obj = new DebugVector()
	{
		position = %position;
		color = %color;
		vector = "1.0 0.0 0.0";
		length = %size;
		alwaysVisible = %alwaysVisible;
		duration = %duration;
		format = 3;
	};
	return %obj;
}

$VDT_TRACKVELOCITY_TICK = 200;
$VDT_TRACKVELOCITY_NB_VECTORS = 20;
function Player::vdtTrackPlayerVelocity_loop(%this, %locked)
{
	%vec = %this.getVelocity();
	%pos = %this.getPosition();
	%pos = setWord(%pos, 2, getWord(%pos, 2) + $VDT_PLAYER_Z_OFFSET);
	if (%locked == 1 && %this.vectorTrackingVelocity)
	{
		%this.vectorTrackingVelocity.vector = %vec;
		%this.vectorTrackingVelocity.length = VectorLen(%vec) / 100;
	}
	else
	{
		vdtVector(%pos, %vec, VectorLen(%vec) / 100, $VDT_TRACKVELOCITY_TICK * $VDT_TRACKVELOCITY_NB_VECTORS, "0.0 0.0 1.0 1.0", 1);
	}
	%this.schedule($VDT_TRACKVELOCITY_TICK, "vdtTrackPlayerVelocity_loop", %locked);
}

function vdtTrackPlayerVelocity(%id, %locked)
{
	if (!%id)
	{
		echo("VDT : Tracking Velocity of Local Player");
		%player = LocalClientConnection.Player;
	}
	else if (isObject(%id))
	{
		echo("VDT : Tracking Velocity of Player" SPC %id);
		%player = %id;
	}
	else
	{
		echo("VDT : Tracking Velocity - " @ %id @ " is not an object");
	}
	if (%player)
	{
		if (%locked == 1)
		{
			echo("VDT : Tracking Velocity - locked vector");
			%vectorTrackingVelocity = new DebugVector()
			{
				position = %player.getPosition();
				color = "0.0 0.0 1.0 1.0";
				vector = %player.getVelocity();
				length = 1;
				alwaysVisible = 1;
				duration = 0;
				format = 1;
				lockedPlayerA = %player;
			};
			%player.vectorTrackingVelocity = %vectorTrackingVelocity;
		}
		%player.vdtTrackPlayerVelocity_loop(%locked);
	}
}

function a()
{
	vdtTrackPlayerVelocity(0, 1);
}

function vdtRadiusDamage(%position, %radius)
{
	%halfRadius = %radius / 2;
	vdtSphere(%position, %halfRadius, 3000, "1.0 0.0 0.0 1.0", 0);
	vdtSphere(%position, %radius, 3000, "1.0 0.5 0.5 1.0", 0);
}

function vdtRadiusDamageImpulse(%position, %impulseVec)
{
	vdtVector(%position, VectorNormalize(%impulseVec), VectorLen(%impulseVec) / 100, 2000, "0.8 0.0 0.0 0.8", 0);
}

$VDT_TRACKAIDESTINATION_TICK = 300;
function AIPlayer::vdtTrackAIdestination_loop(%this)
{
	%this.aiDestinationPoint.setPosition(%this.getMoveDestination());
	%this.aiDestinationVector.lockedPositionB = %this.getMoveDestination();
	%this.schedule($VDT_TRACKAIDESTINATION_TICK, "vdtTrackAIdestination_loop");
}

function AIPlayer::vdtTrackAIdestination(%this)
{
	vdtTrackPlayerVelocity(%this, 1);
	%position = %this.getPosition();
	%destination = %this.getMoveDestination();
	%vec = VectorSub(%destination, %position);
	%basicObj = vdtPoint(%destination, 6, 0, "1.0 0.0 1.0 1.0", 1);
	%this.aiDestinationPoint = %basicObj;
	%obj = new DebugVector()
	{
		position = %position;
		color = "0.0 1.0 0.0 1.0";
		vector = VectorNormalize(%vec);
		length = VectorLen(%vec);
		alwaysVisible = 0;
		duration = 0;
		format = 1;
		lockedPlayerA = %this;
		lockedPositionB = %destination;
	};
	%this.aiDestinationVector = %obj;
	%this.schedule($VDT_TRACKAIDESTINATION_TICK, "vdtTrackAIdestination_loop");
}

