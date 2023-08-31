function portInit(%port)
{
	%failCount = 0;
	while(%failCount < 10.0 && !setNetPort(%port))
	{
		echo("Port init failed on port " @ %port @ " trying next port.");
		%port = %port + 1.0;
		%failCount = %failCount + 1.0;
	}
}

function createServer(%serverType, %mission)
{
	if (%mission $= "")
	{
		error("createServer: mission name unspecified");
		return;
	}
	destroyServer();
	$missionSequence = 0;
	$Server::PlayerCount = 0;
	$Server::ServerType = %serverType;
	if (%serverType $= "MultiPlayer")
	{
		echo("Starting multiplayer mode");
		portInit($Pref::Server::Port);
		allowConnections(true);
		if ($pref::Net::DisplayOnMaster !$= "Never")
		{
			schedule(0, 0, startHeartbeat);
		}
	}
	$ServerGroup = new SimGroup(ServerGroup);
	onServerCreated();
	loadMission(%mission, 1);
}

function destroyServer()
{
	$Server::ServerType = "";
	allowConnections(false);
	stopHeartbeat();
	$missionRunning = 0;
	endMission();
	onServerDestroyed();
	if (isObject(MissionGroup))
	{
		MissionGroup.delete();
	}
	if (isObject(MissionCleanup))
	{
		MissionCleanup.delete();
	}
	if (isObject($ServerGroup))
	{
		$ServerGroup.delete();
	}
	while(ClientGroup.getCount())
	{
		%client = ClientGroup.getObject(0);
		%client.delete();
	}
	$Server::GuidList = "";
	deleteDataBlocks();
	echo("Exporting server prefs...");
	export("$Pref::Server::*", "~/prefs.cs", 0);
	purgeResources();
}

function resetServerDefaults()
{
	echo("Resetting server defaults...");
	exec("~/defaults.cs");
	exec("~/prefs.cs");
	loadMission($Server::MissionFile);
}

function addToServerGuidList(%guid)
{
	%count = getFieldCount($Server::GuidList);
	%i = 0;
	while(%i < %count)
	{
		if (getField($Server::GuidList, %i) == %guid)
		{
			return;
		}
		%i = %i + 1.0;
	}
	// TODO: look into this
	if ($Server::GuidList $= "")
	{
	}
	else
	{
	}
	$Server::GuidList = $Server::GuidList TAB %guid;
	return %guid;
}

function removeFromServerGuidList(%guid)
{
	%count = getFieldCount($Server::GuidList);
	%i = 0;
	while(%i < %count)
	{
		if (getField($Server::GuidList, %i) == %guid)
		{
			$Server::GuidList = removeField($Server::GuidList, %i);
			return;
		}
		%i = %i + 1.0;
	}
}

function onServerInfoQuery()
{
	return "Doing Ok";
}

