$frogames_game = "FPS";
$frogames_server = "www.frogames.net:80";
$frogames_gpmserver = "gpm.frogames.net:80";
$frogames_webserver = "http://www.frogames.net";
$frogames_project = 12;
$frogames_hash_id = "e7d4f5z8a2s2";
$frogames_current_version = "1.9.2";
$frogames_licensetype = "plimus";
$frogames_graindesel = "tfr45a7";
$frogames_buynow = "http://www.frogames.com/penguins_arena/";
$frogames_farabel = "http://farabel.com/?utm_source=penguinsarena&utm_medium=banner&utm_campaign=farabel";
$BuildType = 22;
$Client::GameTypeQuery = "FroGames - " @ $frogames_game @ " v" @ $frogames_current_version;
$Pref::Server::Name = $frogames_game @ " v" @ $frogames_current_version;
$Pref::Server::Info = $pref::Server::AI_level;
$Server::GameType = $Client::GameTypeQuery;
exec("./ui/frogames_debugtools.gui");
exec("./scripts/frogames_debugtools.cs");
exec("./scripts/frogames_builds.cs");
exec("./scripts/frogames_versions.cs");
exec("./scripts/frogames_inviteafriend.cs");
exec("./ui/frogames_inviteafriend.gui");
exec("./scripts/frogames_rss.cs");
exec("./scripts/frogames_reporting.cs");
exec("./scripts/intel_gaming.cs");
if ($BuildType == 25)
{
	exec("./scripts/frogames_steam.cs");
}
else
{
	exec("./scripts/frogames_achievements.cs");
}
addBadWord("poop");
addBadWord("ass");
addBadWord("sex");
addBadWord("pussy");
addBadWord("cunt");
addBadWord("naked");
addBadWord("teen");
addBadWord("nigga");
addBadWord("bastard");
addBadWord("fag");
addBadWord("cock");
addBadWord("suck");
addBadWord("crap");
addBadWord("bush");
addBadWord("wank");
addBadWord("dick");
addBadWord("whore");
addBadWord("bitch");
addBadWord("biatch");
addBadWord("gay");
addBadWord("penis");
addBadWord("fcuk");
addBadWord("porn");
addBadWord("pron");
addBadWord("p0rn");
addBadWord("merde");
addBadWord("encul");
addBadWord("suce");
