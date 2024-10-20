function serverCmdToggleCamera(%client)
{
	%control = %client.getControlObject();
	if (%control == %client.Player)
	{
		%control = %client.Camera;
		%control.mode = toggleCameraFly;
	}
	else
	{
		%control = %client.Player;
		%control.mode = observerFly;
	}
	%client.setControlObject(%control);
}

function serverCmdDropPlayerAtCamera(%client)
{
	if ($Server::TestCheats || isObject(EditorGui))
	{
		%client.Player.setTransform(%client.Camera.getTransform());
		%client.Player.setVelocity("0 0 0");
		%client.setControlObject(%client.Player);
	}
}

function serverCmdDropCameraAtPlayer(%client)
{
	%client.Camera.setTransform(%client.Player.getEyeTransform());
	%client.Camera.setVelocity("0 0 0");
	%client.setControlObject(%client.Camera);
}

function serverCmdSuicide(%client)
{
	if (isObject(%client.Player))
	{
		%client.Player.kill("Suicide");
	}
}

function serverCmdPlayCel(%client, %anim)
{
	if (isObject(%client.Player))
	{
		%client.Player.playCelAnimation(%anim);
	}
}

function serverCmdPlayDeath(%client)
{
	if (isObject(%client.Player))
	{
		%client.Player.playDeathAnimation();
	}
}

function serverCmdJoinTeam(%client, %teamid)
{
	%client.joinTeam(%teamid);
}

