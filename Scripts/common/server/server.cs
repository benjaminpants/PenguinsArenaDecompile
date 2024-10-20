function portInit(%port)
{
	for (%failCount = 0; %failCount < 10 && !setNetPort(%port); %failCount++)
	{
		echo("Port init failed on port " @ %port @ " trying next port.");
		%port++;
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
		allowConnections(1);
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
	allowConnections(0);
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
	while (ClientGroup.getCount())
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
	for (%i = 0; %i < %count; %i++)
	{
		if (getField($Server::GuidList, %i) == %guid)
		{
			return;
		}
	}
	$Server::GuidList = $Server::GuidList $= "" ? %guid : $Server::GuidList TAB %guid;
}

function removeFromServerGuidList(%guid)
{
	%count = getFieldCount($Server::GuidList);
	for (%i = 0; %i < %count; %i++)
	{
		if (getField($Server::GuidList, %i) == %guid)
		{
			$Server::GuidList = removeField($Server::GuidList, %i);
			return;
		}
	}
}

function onServerInfoQuery()
{
	return "Doing Ok";
}

