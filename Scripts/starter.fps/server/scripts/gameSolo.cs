function startSoloGame()
{
	if ($Game::Running)
	{
		error("startGame: End the game first!");
		return;
	}
	for (%clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++)
	{
		%cl = ClientGroup.getObject(%clientIndex);
		%cl.score = 0;
		%cl.ready = 0;
	}
	echo("---- JEU SOLO - rules :");
	echo("time_limit : " @ $rules.time_limit);
	echo("player_droppoint : " @ $rules.player_droppoint);
	echo("player_nb_boulesdeneiges : " @ $rules.player_nb_boulesdeneiges);
	echo("bots_level : " @ $rules.bots_level);
	echo("-----------------------");
	$spawnPointsUsed = 0;
	$nb_players_per_team = 6;
	$Team[1].Player[1] = AIPlayer::spawn("Blue1", pickSpawnPointSolo(), 1, 1, 0);
	$Team[1].numPlayers = 1;
	for (%current_player_ID = 1; %current_player_ID <= $rules.bots_redteam; %current_player_ID++)
	{
		$Team[2].Player[%current_player_ID] = AIPlayer::spawn("Red" @ %current_player_ID, pickSpawnPointSolo(), 2, %current_player_ID, $rules.bots_redteam_levelmodifier);
	}
	$Team[2].numPlayers = $rules.bots_redteam;
	for (%current_player_ID = 1; %current_player_ID <= $rules.bots_yellowteam; %current_player_ID++)
	{
		$Team[3].Player[%current_player_ID] = AIPlayer::spawn("Yellow" @ %current_player_ID, pickSpawnPointSolo(), 3, %current_player_ID, $rules.bots_yellowteam_levelmodifier);
	}
	$Team[3].numPlayers = $rules.bots_yellowteam;
	for (%current_player_ID = 1; %current_player_ID <= $rules.bots_greenteam; %current_player_ID++)
	{
		$Team[4].Player[%current_player_ID] = AIPlayer::spawn("Green" @ %current_player_ID, pickSpawnPointSolo(), 4, %current_player_ID, $rules.bots_greenteam_levelmodifier);
	}
	$Team[4].numPlayers = $rules.bots_greenteam;
	if ($rules.bots_redteam)
	{
		$nb_teams = 2;
	}
	if ($rules.bots_yellowteam)
	{
		$nb_teams = 3;
	}
	if ($rules.bots_greenteam)
	{
		$nb_teams = 4;
	}
	debugTeams();
	$Game::Running = 1;
	waitingBeforeSoloRules();
}

function waitingBeforeSoloRules()
{
	$Game::CountdownFinished = 0;
	if (!LocalClientConnection.ready)
	{
		$Game::Schedule = schedule(500, 0, "waitingBeforeCountDown");
	}
	else
	{
		commandToClient(LocalClientConnection, 'SoloGameMapIntro');
	}
}

function pickSpawnPointSolo()
{
	%groupName = "MissionGroup/PlayerDropPoints";
	%group = nameToID(%groupName);
	if (%group != -1)
	{
		%index = $spawnPointsUsed++;
		%spawn = %group.getObject(%index);
		return %spawn.getTransform();
	}
	else
	{
		error("Missing spawn points group " @ %groupName);
	}
	return "0 0 300 1 0 0 0";
}

