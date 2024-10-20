function initServer()
{
	echo("\n--------- Initializing MOD: FPS Starter Kit: Server ---------");
	$Server::Status = "Unknown";
	$Server::TestCheats = 0;
	$Server::MissionFileSpec = "*/missions/*.mis";
	initBaseServer();
	exec("./scripts/commands.cs");
	exec("./scripts/centerPrint.cs");
	exec("./scripts/game.cs");
	compile("./scripts/dedicated_server.cs");
}

function initDedicated()
{
	enableWinConsole(1);
	echo("\n--------- Starting Dedicated Server ---------");
	exec("./scripts/dedicated_server.cs");
	exec("./scripts/dedicated_server_official.cs");
	if ($Server::MissionType $= "")
	{
		if (getRandom(1, 2) == 1)
		{
			$Server::MissionType = "Classic";
		}
		else
		{
			$Server::MissionType = "Unlimited";
		}
	}
	if ($dedicatedServerName !$= "")
	{
		$Pref::Server::Name = $dedicatedServerName;
	}
	else
	{
		$Pref::Server::Name = "PA Server";
	}
	if ($dedicatedServerSlots >= 1 && $dedicatedServerSlots <= 4)
	{
		$Pref::Server::PlayersSlots = $dedicatedServerSlots;
	}
	else
	{
		$Pref::Server::PlayersSlots = 4;
	}
	if ($dedicatedServerAIlevel)
	{
		$pref::Server::AI_level = $dedicatedServerAIlevel;
	}
	else
	{
		$pref::Server::AI_level = getRandom(5, 8);
	}
	$Pref::Server::Info = $pref::Server::AI_level;
	if ($Pref::Server::PlayersSlots == 2)
	{
		$pref::Server::nbTeams2 = 1;
		$pref::Server::nbTeams3 = 0;
		$pref::Server::nbTeams4 = 0;
		$Pref::Server::MaxPlayers = 2;
	}
	else if ($Pref::Server::PlayersSlots == 3)
	{
		$pref::Server::nbTeams2 = 0;
		$pref::Server::nbTeams3 = 1;
		$pref::Server::nbTeams4 = 0;
		$Pref::Server::MaxPlayers = 3;
	}
	else if ($Pref::Server::PlayersSlots == 4)
	{
		$pref::Server::nbTeams2 = 0;
		$pref::Server::nbTeams3 = 0;
		$pref::Server::nbTeams4 = 1;
		$Pref::Server::MaxPlayers = 4;
	}
	else
	{
		$pref::Server::nbTeams2 = 0;
		$pref::Server::nbTeams3 = 0;
		$pref::Server::nbTeams4 = 1;
		$Pref::Server::MaxPlayers = 4;
	}
	echo("CREATING SERVER:" SPC $Pref::Server::Name SPC "- type:" SPC $Server::MissionType SPC "slots:" SPC $Pref::Server::PlayersSlots SPC "ailevel:" SPC $Pref::Server::Info);
	$Server::Dedicated = 1;
	if ($missionArg !$= "")
	{
		createServer("MultiPlayer", $missionArg);
	}
	else
	{
		%i = 0;
		for (%file = findFirstFile($Server::MissionFileSpec); %file !$= ""; %file = findNextFile($Server::MissionFileSpec))
		{
			if (strstr(%file, "/CVS/") == -1)
			{
				%map_list[%i] = %file;
				%i++;
			}
		}
		%map_list_count = %i;
		%aleat = getRandom(%map_list_count - 1);
		%mission = %map_list[%aleat];
		createServer("MultiPlayer", %mission);
	}
	schedule(30 * 1000, 0, "dedicatedAIconnect");
	checkAI();
}

function dedicatedAIconnect()
{
	%ai_names[0] = "SUPERBOT MasterT";
	%ai_names[1] = "SUPERBOT MEAGAIN";
	%ai_names[2] = "SUPERBOT Lorenzo";
	%ai_names[3] = "SUPERBOT jpp";
	%ai_names[4] = "SUPERBOT TodaH";
	%ai_names[5] = "SUPERBOT Iylararel";
	%ai_names[6] = "SUPERBOT faKe";
	%ai_names[7] = "SUPERBOT qwertqwry";
	%ai_names[8] = "SUPERBOT H H H H H";
	%ai_names[9] = "SUPERBOT Kem";
	%ai_names[10] = "SUPERBOT Noam";
	%aleat = getRandom(0, 10);
	%name = %ai_names[%aleat];
	for (%clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++)
	{
		%cl = ClientGroup.getObject(%clientIndex);
		if (%cl.isAIControlled())
		{
			return;
		}
	}
	if ($Server::PlayerCount < $Pref::Server::MaxPlayers - 1)
	{
		echo("=[SUPERAI] Nouveau bot : " SPC %name);
		%botConnection = aiConnect(%name);
		schedule(25 * 60 * 1000, 0, "dedicatedAIdisconnect", %botConnection);
	}
	else
	{
		schedule(3 * 60 * 1000, 0, "dedicatedAIconnect");
	}
}

function dedicatedAIdisconnect(%client)
{
	if (isObject())
	{
		echo("=[SUPERAI] byebye SUPER AI");
		%client.delete();
	}
	schedule(5 * 60 * 1000, 0, "dedicatedAIconnect");
}

function checkAI()
{
	if (ClientGroup.getCount() >= $Pref::Server::MaxPlayers)
	{
		for (%clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++)
		{
			%cl = ClientGroup.getObject(%clientIndex);
			if (%cl.isAIControlled())
			{
				%cl.delete();
				echo("=[SUPERAI] plus de place on vire les bots");
			}
		}
	}
	schedule(3 * 1000, 0, "checkAI");
}

