loadDir("common");
$FrogamesOptionsLow = 1001;
$FrogamesOptionsMedium = 1501;
echo("\n--------- Loading prefs ---------");
exec("./client/defaults.cs");
if (!$ProcessorMhz || $ProcessorMhz < 100)
{
	echo("default : medium (can't detect processor frequency) ->" @ $ProcessorMhz);
	exec("./client/defaults_medium.cs");
	$pref::Video::resolution = "1024 768 32";
	$pref::Video::windowedRes = "1024 768";
}
else if ($ProcessorMhz < $FrogamesOptionsLow)
{
	echo("default : low -> " @ $ProcessorMhz @ " Mhz < " @ $FrogamesOptionsLow @ " Mhz");
	exec("./client/defaults_low.cs");
	$pref::Video::resolution = "800 600 32";
	$pref::Video::windowedRes = "800 600";
}
else if ($ProcessorMhz < $FrogamesOptionsMedium)
{
	echo("default : medium -> " @ $ProcessorMhz @ " Mhz < " @ $FrogamesOptionsMedium @ " Mhz");
	exec("./client/defaults_medium.cs");
	$pref::Video::resolution = "1024 768 32";
	$pref::Video::windowedRes = "1024 768";
}
else
{
	echo("default : heavy -> " @ $ProcessorMhz @ " Mhz > " @ $FrogamesOptionsMedium @ " Mhz");
	exec("./client/defaults_heavy.cs");
	$pref::Video::resolution = "1280 800 32";
	$pref::Video::windowedRes = "1280 800";
}
echo("This prefs will be overwrited by your previously selected options.");
exec("./dev_tools.cs");
exec("./server/defaults.cs");
exec("./client/prefs.cs");
exec("./server/prefs.cs");
$pref::Master[1] = "2:192.30.35.187:28002";
compile("./localization_fr.cs");
compile("./localization_en.cs");
%localization = $pref::Localization;
if (%localization $= "")
{
	%localization = "en";
}
exec("./localization_" @ %localization @ ".cs");
package FpsStarterKit
{
	function displayHelp()
	{
		Parent::displayHelp();
		error("FPS Mod options:\n" @ "  -dedicated             Start as dedicated server\n" @ "  -connect <address>     For non-dedicated: Connect to a game at <address>\n" @ "  -mission <filename>    For dedicated: Load the mission\n" @ "  -gametype <type>       For dedicated: Type of game (Classic/Duels/Unlimited)\n");
	}

	function parseArgs()
	{
		Parent::parseArgs();
		for (%i = 1; %i < $Game::argc; %i++)
		{
			%arg = $Game::argv[%i];
			%nextArg = $Game::argv[%i + 1];
			%hasNextArg = $Game::argc - %i > 1;
			if (%arg $= "-dedicated")
			{
				$Server::Dedicated = 1;
				enableWinConsole(1);
				$argUsed[%i]++;
			}
			else if (%arg $= "-mission")
			{
				$argUsed[%i]++;
				if (%hasNextArg)
				{
					$missionArg = %nextArg;
					$argUsed[%i + 1]++;
					%i++;
				}
				else
				{
					error("Error: Missing Command Line argument. Usage: -mission <filename>");
				}
			}
			else if (%arg $= "-gametype")
			{
				$argUsed[%i]++;
				if (%hasNextArg)
				{
					$Server::MissionType = %nextArg;
					$argUsed[%i + 1]++;
					%i++;
				}
				else
				{
					error("Error: Missing Command Line argument. Usage: -gametype <type>");
				}
			}
			else if (%arg $= "-connect")
			{
				$argUsed[%i]++;
				if (%hasNextArg)
				{
					$JoinGameAddress = %nextArg;
					$argUsed[%i + 1]++;
					%i++;
					continue;
				}
				error("Error: Missing Command Line argument. Usage: -connect <ip_address>");
			}
		}
	}

	function onStart()
	{
		Parent::onStart();
		echo("\n--------- Initializing MOD: FPS Starter Kit ---------");
		exec("./client/init.cs");
		exec("./server/init.cs");
		exec("./data/init.cs");
		initServer();
		if ($Server::Dedicated)
		{
			initDedicated();
		}
		else
		{
			initClient();
		}
	}

	function onExit()
	{
		echo("Exporting client prefs");
		export("$pref::*", "./client/prefs.cs", False);
		echo("Exporting client config");
		if (isObject(moveMap))
		{
			moveMap.save("./client/config.cs", 0);
		}
		echo("Exporting server prefs");
		export("$Pref::Server::*", "./server/prefs.cs", False);
		BanList::export("./server/banlist.cs");
		Parent::onExit();
	}

};
activatePackage(FpsStarterKit);
