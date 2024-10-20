$checkdedicated_server = "www.frogames.com:80";
$checkdedicated_script_logs = "/penguins_arena/dedicated/logs.php";
$checkdedicated_hash_id = "e7d4f5z8a2s2";
$Server::GameType = "FroGames - FPS v1.9.2";
function logDedicated(%player, %tolog)
{
	%query = "hash=" @ $checkdedicated_hash_id @ "\tplayer=" @ %player @ "\taction=" @ %tolog @ "\r";
	%httpversion = new HTTPObject(logDedicated);
	%httpversion.get($checkdedicated_server, $checkdedicated_script_logs, %query);
	%file = new FileObject();
	%file.openForAppend("starter.fps/server/logs.txt");
	%file.writeLine("LOGINGPLAYER - " @ $Pref::Server::Name @ "\t" @ getRealTime() @ "\t" @ %player @ "\t" @ %tolog);
	%file.close();
}

