$Game::Duration = 0;
$Game::EndGameScore = 3000;
$Game::EndGamePause = 3;
function onServerCreated()
{
	$Game::StartTime = 0;
	exec("./audioProfiles.cs");
	exec("./camera.cs");
	exec("./markers.cs");
	exec("./triggers.cs");
	exec("./inventory.cs");
	exec("./shapeBase.cs");
	exec("./item.cs");
	exec("./staticShape.cs");
	exec("./weapon.cs");
	exec("./radiusDamage.cs");
	exec("./crossbow.cs");
	exec("./coup_de_poing.cs");
	exec("./player.cs");
	exec("./aiPlayer.cs");
	exec("./endgame.cs");
	exec("./orque.cs");
	exec("./geysers.cs");
	exec("./plateforms.cs");
	exec("./glaciers.cs");
	exec("./destructables.cs");
	exec("./feu.cs");
	exec("./debug.cs");
	exec("./frogames_tools.cs");
	exec("./visualDebugTool.cs");
	exec("./bonus/griffes.cs");
	exec("./bonus/invincible.cs");
	exec("./bonus/BdN_observ.cs");
	exec("./bonus/BdN_geante.cs");
	exec("./bonus/BdN_rafale.cs");
	exec("./bonus/BdN_explosive.cs");
	exec("./objects.cs");
	exec("./gameSolo.cs");
	$Game::StartTime = $Sim::Time;
	$Team[1] = new ScriptObject()
	{
		teamId = 1;
		name = "Blue";
		realPlayer = 0;
		playerName = "";
		client = "";
		score = 0;
		scoreLTGtotal = 0;
		scoreLTG[1] = 0;
		scoreLTG[2] = 0;
		scoreLTG[3] = 0;
		scoreLTG[4] = 0;
		scoreLTG[5] = 0;
		scoreLTG[6] = 0;
		scoreLTG[7] = 0;
		scoreLTG[8] = 0;
		scoreLTG[9] = 0;
		scoreLTG[10] = 0;
		numPlayers = 0;
		Player[1] = "";
		Player[2] = "";
		Player[3] = "";
		Player[4] = "";
		Player[5] = "";
		Player[6] = "";
	};
	$Team[2] = new ScriptObject()
	{
		teamId = 2;
		name = "Red";
		realPlayer = 0;
		playerName = "";
		client = "";
		score = 0;
		scoreLTGtotal = 0;
		scoreLTG[1] = 0;
		scoreLTG[2] = 0;
		scoreLTG[3] = 0;
		scoreLTG[4] = 0;
		scoreLTG[5] = 0;
		scoreLTG[6] = 0;
		scoreLTG[7] = 0;
		scoreLTG[8] = 0;
		scoreLTG[9] = 0;
		scoreLTG[10] = 0;
		numPlayers = 0;
		Player[1] = "";
		Player[2] = "";
		Player[3] = "";
		Player[4] = "";
		Player[5] = "";
		Player[6] = "";
	};
	$Team[3] = new ScriptObject()
	{
		teamId = 3;
		name = "Yellow";
		realPlayer = 0;
		playerName = "";
		client = "";
		score = 0;
		scoreLTGtotal = 0;
		scoreLTG[1] = 0;
		scoreLTG[2] = 0;
		scoreLTG[3] = 0;
		scoreLTG[4] = 0;
		scoreLTG[5] = 0;
		scoreLTG[6] = 0;
		scoreLTG[7] = 0;
		scoreLTG[8] = 0;
		scoreLTG[9] = 0;
		scoreLTG[10] = 0;
		numPlayers = 0;
		Player[1] = "";
		Player[2] = "";
		Player[3] = "";
		Player[4] = "";
		Player[5] = "";
		Player[6] = "";
	};
	$Team[4] = new ScriptObject()
	{
		teamId = 4;
		name = "Green";
		realPlayer = 0;
		playerName = "";
		client = "";
		score = 0;
		scoreLTGtotal = 0;
		scoreLTG[1] = 0;
		scoreLTG[2] = 0;
		scoreLTG[3] = 0;
		scoreLTG[4] = 0;
		scoreLTG[5] = 0;
		scoreLTG[6] = 0;
		scoreLTG[7] = 0;
		scoreLTG[8] = 0;
		scoreLTG[9] = 0;
		scoreLTG[10] = 0;
		numPlayers = 0;
		Player[1] = "";
		Player[2] = "";
		Player[3] = "";
		Player[4] = "";
		Player[5] = "";
		Player[6] = "";
	};
	$scores_already_reseted = 0;
}

function onServerDestroyed()
{
	cancel($Server::Schedule);
}

function onMissionLoaded()
{
	$rules = "";
	%rulesSelection = "MissionGroup/rules";
	$rules = nameToID(%rulesSelection);
	if ($rules != -1.0)
	{
		startSoloGame();
	}
	else
	{
		startGame();
	}
}

function onMissionEnded()
{
	cancel($Game::Schedule);
	$Game::Running = 0;
	$Game::Cycling = 0;
	$Game::Sessionfinished = 0;
	$Game::WiningTeam = 0;
}

function startGame()
{
	if ($Game::Running)
	{
		error("startGame: End the game first!");
		return;
	}
	%clientIndex = 0;
	while(%clientIndex < ClientGroup.getCount())
	{
		%cl = ClientGroup.getObject(%clientIndex);
		%cl.score = 0;
		%cl.ready = 0;
		%clientIndex = %clientIndex + 1.0;
	}
	$nb_teams = 2;
	if ($pref::Server::nbTeams2)
	{
		$nb_teams = 2;
	}
	if ($pref::Server::nbTeams3)
	{
		$nb_teams = 3;
	}
	if ($pref::Server::nbTeams4)
	{
		$nb_teams = 4;
	}
	if ($Server::MissionType $= "Classic")
	{
		$nb_pingouins = 12;
		$nb_joueurs_par_team = $nb_pingouins / $nb_teams;
	}
	else
	{
		if ($Server::MissionType $= "Duels")
		{
			$nb_pingouins = $nb_teams;
			$nb_joueurs_par_team = 1;
		}
		else
		{
			if ($Server::MissionType $= "Unlimited")
			{
				$nb_pingouins = $nb_teams;
				$nb_joueurs_par_team = 1;
			}
			else
			{
				if ($Server::MissionType $= "Modding")
				{
					$nb_pingouins = 12;
					$nb_joueurs_par_team = $nb_pingouins / $nb_teams;
				}
			}
		}
	}
	%i = 1;
	while(%i <= 12.0)
	{
		$spawnPointsUsed[%i] = 0;
		%i = %i + 1.0;
	}
	%ID_team_bonus_AI = getRandom(1, $nb_teams);
	echo("== ID_team_bonus_AI : " @ %ID_team_bonus_AI);
	%current_team_ID = 1;
	while(%current_team_ID <= $nb_teams)
	{
		if (%current_team_ID == 1.0)
		{
			%current_team_name = "Blue";
		}
		else
		{
			if (%current_team_ID == 2.0)
			{
				%current_team_name = "Red";
			}
			else
			{
				if (%current_team_ID == 3.0)
				{
					%current_team_name = "Yellow";
				}
				else
				{
					if (%current_team_ID == 4.0)
					{
						%current_team_name = "Green";
					}
				}
			}
		}
		if (%ID_team_bonus_AI == %current_team_ID)
		{
			%bonus_AI_level = 1;
		}
		else
		{
			%bonus_AI_level = 0;
		}
		%current_player_ID = 1;
		while(%current_player_ID <= $nb_joueurs_par_team)
		{
			$Team[%current_team_ID].Player[%current_player_ID] = AIPlayer::spawn(%current_team_name @ %current_player_ID, pickSpawnPoint(%current_team_name, %current_player_ID), %current_team_ID, %current_player_ID, %bonus_AI_level);
			%current_player_ID = %current_player_ID + 1.0;
		}
		if ($Server::MissionType $= "Classic")
		{
			$Team[%current_team_ID].numPlayers = $nb_joueurs_par_team;
		}
		else
		{
			if ($Server::MissionType $= "Duels")
			{
				$Team[%current_team_ID].numPlayers = 3;
			}
			else
			{
				if ($Server::MissionType $= "Unlimited")
				{
					$Team[%current_team_ID].numPlayers = 3;
				}
				else
				{
					if ($Server::MissionType $= "Modding")
					{
						$Team[%current_team_ID].numPlayers = $nb_joueurs_par_team;
					}
				}
			}
		}
		messageAll('MsgMembersTeamChanged', "", 1, $Team[%current_team_ID].numPlayers, 0);
		%current_team_ID = %current_team_ID + 1.0;
	}
	debugTeams();
	$achivement_temp_duel = 0;
	$Game::Running = 1;
	waitingBeforeCountDown();
}

function waitingBeforeCountDown()
{
	$Game::DecompteFini = 0;
	if (!LocalClientConnection.ready && !$Server::Dedicated)
	{
		$Game::Schedule = schedule(500, 0, "waitingBeforeCountDown");
	}
	else
	{
		initCountDown(200);
	}
}

function initCountDown(%attente)
{
	%nb_clients_ready = 0;
	%nb_clients = 0;
	%clientIndex = 0;
	while(%clientIndex < ClientGroup.getCount())
	{
		%cl = ClientGroup.getObject(%clientIndex);
		%nb_clients = %nb_clients + 1.0;
		if (%cl.ready == 1.0 || %cl.isAIControlled())
		{
			%nb_clients_ready = %nb_clients_ready + 1.0;
		}
		else
		{
			if (%attente <= 10.0)
			{
				kick(%cl);
			}
		}
		%clientIndex = %clientIndex + 1.0;
	}
	if (ClientGroup.getCount() == %nb_clients_ready || %attente <= 0.0 && %nb_clients > 0.0)
	{
		if ($dev_build == 1.0)
		{
			$Game::Schedule = schedule(400, 0, "countDown", 1);
		}
		else
		{
			$Game::Schedule = schedule(1400, 0, "countDown", 5);
		}
	}
	else
	{
		%clientIndex = 0;
		while(%clientIndex < ClientGroup.getCount())
		{
			%cl = ClientGroup.getObject(%clientIndex);
			commandToClient(%cl, 'WaitingForPlayers');
			%clientIndex = %clientIndex + 1.0;
		}
		if (ClientGroup.getCount() <= 0.0 && $Server::Dedicated)
		{
			$Game::Schedule = schedule(100, 0, "initCountDown", 1000);
			resetScores();
		}
		else
		{
			%attente = %attente - 1.0;
			$Game::Schedule = schedule(100, 0, "initCountDown", %attente - 1.0);
		}
	}
}

function countDown(%i)
{
	%clientIndex = 0;
	while(%clientIndex < ClientGroup.getCount())
	{
		%cl = ClientGroup.getObject(%clientIndex);
		commandToClient(%cl, 'SetCounter', %i);
		%clientIndex = %clientIndex + 1.0;
	}
	if (%i == 0.0)
	{
		$Game::DecompteFini = 1;
		if ($Game::Duration)
		{
			$Game::Schedule = schedule($Game::Duration * 1000.0, 0, "onGameDurationEnd");
		}
		%current_team_ID = 1;
		while(%current_team_ID <= $nb_teams)
		{
			%current_player_ID = 1;
			while(%current_player_ID <= $nb_joueurs_par_team)
			{
				$Team[%current_team_ID].Player[%current_player_ID].schedule(getRandom(400, 1000), "doscan", $Team[%current_team_ID].Player[%current_player_ID]);
				%current_player_ID = %current_player_ID + 1.0;
			}
			%current_team_ID = %current_team_ID + 1.0;
		}
		%clientIndex = 0;
		while(%clientIndex < ClientGroup.getCount())
		{
			%cl = ClientGroup.getObject(%clientIndex);
			commandToClient(%cl, 'GameStart');
			%clientIndex = %clientIndex + 1.0;
		}
	}
	else
	{
		%i = %i - 1.0;
		$Game::Schedule = schedule(1000, 0, "countDown", %i);
	}
}

function serverCmdDecompteTermine(%client)
{
	if (!$Game::DecompteFini)
	{
		commandToClient(%client, 'GameWillStart');
	}
}

function resetScores()
{
	%team = 1;
	while(%team <= $nb_teams)
	{
		$Team[%team].score = 0;
		%i = 1;
		while(%i <= 10.0)
		{
			$Team[%team].scoreLTG[%i] = 0;
			%i = %i + 1.0;
		}
		$Team[%team].scoreLTGtotal = 0;
		messageAll('MsgTeamScoreLTGChanged', "", %team, $Team[%team].scoreLTGtotal);
		messageAll('MsgTeamScoreChanged', "", %team, $Team[%team].score, $Team[%team].playerName);
		messageAll('MsgResetScores', "");
		%team = %team + 1.0;
	}
}

function serverCmdResetScores(%client)
{
	resetScores();
}

function cancelResetScoresSchedule()
{
	$scores_already_reseted = 0;
}

function endGame()
{
	if (!$Game::Running)
	{
		error("endGame: No game running!");
		return;
	}
	cancel($Game::Schedule);
	resetMission();
	$Game::Running = 0;
}

function onGameDurationEnd()
{
	if ($Game::Duration && !isObject(EditorGui))
	{
		cycleGame();
	}
}

function cycleGame()
{
	if (!$Game::Cycling)
	{
		$Game::Cycling = 1;
		$Game::Schedule = schedule(10000, 0, "onCycleExec");
	}
}

function onCycleExec()
{
	%clientIndex = 0;
	while(%clientIndex < ClientGroup.getCount())
	{
		%cl = ClientGroup.getObject(%clientIndex);
		commandToClient(%cl, 'GameEndTakeScreenshot');
		%clientIndex = %clientIndex + 1.0;
	}
	endGame();
	$Game::Schedule = schedule($Game::EndGamePause * 0.0, 0, "onCyclePauseEnd");
}

function onCyclePauseEnd()
{
	$Game::Cycling = 0;
	if ($Server::MissionType $= "Modding")
	{
		%file = "starter.fps/data/missions_modding/" @ $pref::nextCustomMap;
		$Pref::Server::Name = "[Mod:" @ getSubStr($pref::nextCustomMap, 0, strlen($pref::nextCustomMap) - 4.0) @ "] " @ badWordStrip($pref::Player::Name);
	}
	else
	{
		%search = $Server::MissionFileSpec;
		%file = findFirstFile(%search);
		while(%file $= "")
		{
			if (%file $= $Server::MissionFile)
			{
				%file = findNextFile(%search);
				if (%file $= "")
				{
					%file = findFirstFile(%search);
				}
			}
			else
			{
				%file = findNextFile(%search);
			}
		}
	}
	loadMission(%file);
}

function GameConnection::onClientEnterGame(%this)
{
	commandToClient(%this, 'SyncClock', $Sim::Time - $Game::StartTime);
	%this.ready = 0;
	%this.score = 0;
	%this.Camera = new Camera()
	{
		dataBlock = "Observer";
	};
	MissionCleanup.add(%this.Camera);
	%this.Camera.scopeToClient(%this);
	if (%this.team_id)
	{
		%this.joinTeam(%this.team_id);
		commandToClient(%this, 'RejoindreEquipe', %this.team_id);
	}
	else
	{
		echo("Pas d'equipe ??");
		quit();
	}
	%team_num = 1;
	while(%team_num <= $nb_teams)
	{
		if ($Team[%team_num].scoreLTG[10] >= 1.0)
		{
			%last_winning_team = %team_num;
		}
		%team_num = %team_num + 1.0;
	}
	messageClient(%this, 'MsgInitTeamGUI', "", %this.team_id, $nb_teams, %last_winning_team);
	%team_num = 1;
	while(%team_num <= $nb_teams)
	{
		%controled_by_player = 0;
		%dead = 0;
		if ($Team[%team_num].realPlayer >= 1.0)
		{
			%controled_by_player = 1;
		}
		if ($Team[%team_num].numPlayers == 0.0)
		{
			%dead = 1;
		}
		messageClient(%this, 'MsgUpdateTeamGUI', "", %this.team_id, $nb_teams, %team_num, %controled_by_player, %dead, $Team[%team_num].playerName);
		messageClient(%this, 'MsgMembersTeamChanged', "", %team_num, $Team[%team_num].numPlayers, 0);
		messageClient(%this, 'MsgTeamScoreChanged', "", %team_num, $Team[%team_num].score, $Team[%team_num].playerName);
		messageClient(%this, 'MsgTeamScoreLTGChanged', "", %team_num, $Team[%team_num].scoreLTGtotal);
		%team_num = %team_num + 1.0;
	}
	%thisTeam_dead = 0;
	if ($Team[%this.team_id].numPlayers == 0.0)
	{
		%thisTeam_dead = 1;
	}
	%clientIndex = 0;
	while(%clientIndex < ClientGroup.getCount())
	{
		%cl = ClientGroup.getObject(%clientIndex);
		messageClient(%cl, 'MsgUpdateTeamGUI', "", %cl.team_id, $nb_teams, %this.team_id, 1, %thisTeam_dead, %this.getPlayerName());
		if (%cl != %this && $Game::Running && $Game::DecompteFini)
		{
			messageClient(%cl, 'MsgJoinMessage', "", %this.team_id, %this.getPlayerName());
		}
		%clientIndex = %clientIndex + 1.0;
	}
	%this.ready = 1;
}

function GameConnection::onClientLeaveGame(%this)
{
	%thisTeam_dead = 0;
	if ($Team[%this.team_id].numPlayers == 0.0)
	{
		%thisTeam_dead = 1;
	}
	%clientIndex = 0;
	while(%clientIndex < ClientGroup.getCount())
	{
		%cl = ClientGroup.getObject(%clientIndex);
		messageClient(%cl, 'MsgUpdateTeamGUI', "", %cl.team_id, $nb_teams, %this.team_id, 0, %thisTeam_dead, "");
		if (%cl != %this)
		{
			messageClient(%cl, 'MsgLeaveMessage', "", %this.getPlayerName());
		}
		%clientIndex = %clientIndex + 1.0;
	}
	%this.ready = 0;
	%this.leaveTeam();
	if (isObject(%this.Camera))
	{
		%this.Camera.delete();
	}
	if (isObject(%this.Player) && $Team[%this.team.teamId].Player[%this.id_in_team])
	{
		$Team[%this.team.teamId].Player[%this.id_in_team].schedule(1000, "doscan", $Team[%this.team.teamId].Player[%this.id_in_team]);
		$Team[%this.team.teamId].Player[%this.id_in_team].unmountImage(7);
	}
	else
	{
		if (isObject(%this.Player) && %this.Player.isObserver)
		{
			%this.Player.delete();
		}
	}
}

function GameConnection::onLeaveMissionArea(%this)
{
}

function GameConnection::onEnterMissionArea(%this)
{
}

function GameConnection::onDeath(%this, %unused_var_1, %unused_var_2, %unused_var_3, %unused_var_4)
{
	%this.Player = '';
	if ($Server::MissionType $= "Classic" || $Server::MissionType $= "Modding")
	{
		$Team[%this.team.teamId].Player[%this.id_in_team] = 0;
	}
	else
	{
		if ($Team[%this.team.teamId].numPlayers != 0.0)
		{
			$Team[%this.team.teamId].Player[1] = AIPlayer::spawn($Team[%this.team.teamId].name @ 1, pickSpawnPoint($Team[%this.team.teamId].name, 1), %this.team.teamId, 1, 0);
		}
		else
		{
			$Team[%this.team.teamId].Player[1] = 0;
		}
	}
	if (!$Game::Sessionfinished)
	{
		commandToClient(%this, 'death');
	}
	%this.schedule(900, spawnPlayer);
	if ($Team[%this.team_id].numPlayers != 0.0)
	{
		%this.schedule(700, ReincarnationMessage);
	}
}

function GameConnection::ReincarnationMessage(%this)
{
	if ($Team[%this.team_id].numPlayers != 0.0)
	{
		if ($Server::MissionType $= "Classic" || $Server::MissionType $= "Modding")
		{
			commandToClient(%this, 'ReincarnationMessage');
		}
		else
		{
			commandToClient(%this, 'RespawnMessage');
		}
	}
}

function GameConnection::spawnPlayer(%this)
{
	if (%this.Player > 0.0)
	{
		error("Attempting to create an angus ghost!");
	}
	if (!$Game::Sessionfinished)
	{
		%this.chooseAI();
	}
}

function GameConnection::chooseAI(%this)
{
	echo("== [" @ %this SPC "ai:" @ %this.isAIControlled() SPC "team:" @ %this.team.teamId SPC %this.getPlayerName() @ "] chooseAI");
	commandToClient(%this, 'ResetGUIBonus');
	%i = 1;
	while(%i <= $nb_joueurs_par_team)
	{
		%current_ai = $Team[%this.team.teamId].Player[%i];
		if (%current_ai && %current_ai.getState() $= "Move")
		{
			echo("== [" @ %this SPC "ai:" @ %this.isAIControlled() SPC "team:" @ %this.team.teamId SPC %this.getPlayerName() @ "] chooseAI - found available Penguin (" @ %i @ ")");
			cancel(%current_ai.ailoop);
			%current_ai.setImageTrigger(0, 0);
			%current_ai.client = %this;
			%this.Player = %current_ai;
			if (%this.isAIControlled())
			{
				if ($Game::DecompteFini)
				{
					%current_ai.schedule(getRandom(50, 200), "doscan", %current_ai);
				}
			}
			else
			{
				%this.Camera.setTransform(%current_ai.getEyeTransform());
				%this.setControlObject(%current_ai);
			}
			%this.id_in_team = %i;
			%current_ai.stop();
			// %current_ai.playReincarnation();
			commandToClient(%this, 'MountDecoObjects');
			%i = %i + 1.0;
		}
		else
		{
			%i = %i + 1.0;
		}
	}
	if (!%this.Player)
	{
		echo("== [" @ %this SPC "ai:" @ %this.isAIControlled() SPC "team:" @ %this.team.teamId SPC %this.getPlayerName() @ "] No Penguins available (gameover)");
		%spawnPoint = pickObserverPoint(%this, %this.team.teamId);
		%this.createObserver(%spawnPoint);
		commandToClient(%this, 'ControlCameraObserver');
	}
}

function GameConnection::endgameNoCamera(%this)
{
	if (%this.Player.isObserver)
	{
		%this.Camera.setMode("Corpse", %this.Player);
		%this.setControlObject(%this.Camera);
	}
	else
	{
		%spawnPoint = pickObserverPoint(%this, %this.team.teamId);
		%this.createObserver(%spawnPoint);
		commandToClient(%this, 'ControlCameraObserver');
	}
}

function GameConnection::createObserver(%this, %spawnPoint)
{
	if (%this.Player > 0.0)
	{
		error("Attempting to create an angus ghost!");
	}
	%playerObserver = new Player()
	{
		dataBlock = "PlayerBodyObserver";
		client = %this;
	};
	MissionCleanup.add(%playerObserver);
	%playerObserver.setTransform(%spawnPoint);
	%playerObserver.setShapeName(%this.name);
	if (!$Game::Sessionfinished)
	{
		%playerObserver.setInventory(observ, 1);
		if (strstr(%this.getPlayerName(), "DemoPenguin") == 0.0)
		{
			%playerObserver.setInventory(observAmmo, 2);
		}
		else
		{
			%playerObserver.setInventory(observAmmo, 100);
		}
		%playerObserver.mountImage(observImage, 0);
	}
	%playerObserver.isObserver = 1;
	%playerObserver.setActionThread("idle2");
	%this.Camera.setTransform(%playerObserver.getEyeTransform());
	%this.Player = %playerObserver;
	%this.setControlObject(%playerObserver);
}

function pickSpawnPoint(%team, %unused_var_1)
{
	%groupName = "MissionGroup/PlayerDropPoints";
	%group = nameToID(%groupName);
	if (%group != -1.0)
	{
		%count = %group.getCount();
		if (%count > 0.0)
		{
			%spawn_counter = 0;
			while(%spawnOK != 1.0 && %spawn_counter < 200.0)
			{
				%current_spawn = getRandom(%count - 1.0);
				if ($spawnPointsUsed[%current_spawn] == 0.0)
				{
					%spawnOK = 1;
					$spawnPointsUsed[%current_spawn] = 1;
					%index = %current_spawn;
				}
				%spawn_counter = %spawn_counter + 1.0;
			}
			%spawn = %group.getObject(%index);
			return %spawn.getTransform();
		}
		else
		{
			error("No spawn points found in " @ %groupName);
		}
	}
	else
	{
		error("Missing spawn points group " @ %groupName);
	}
	return "0 0 300 1 0 0 0";
}

function pickObserverPoint(%client, %numTeam)
{
	%groupName = "MissionGroup/ObserverDropPoints";
	%group = nameToID(%groupName);
	if (%group != -1.0)
	{
		%count = %group.getCount();
		if (%count != 0.0)
		{
			echo("== [" @ %client SPC "ai:" @ %client.isAIControlled() SPC "team:" @ %client.team.teamId SPC %client.getPlayerName() @ "] pickObserverPoint");
			if (%numTeam >= 1.0)
			{
				%index = %numTeam - 1.0;
				%spawn = %group.getObject(%index);
				return %spawn.getTransform();
			}
			else
			{
				error("Pas de numTeam !?");
			}
		}
		else
		{
			error("No observer spawn points found in " @ %groupName);
		}
	}
	else
	{
		error("Missing observer spawn points group " @ %groupName);
	}
	return "0 0 300 1 0 0 0";
}

function GameConnection::joinTeam(%this, %teamid)
{
	if (%teamid > 4.0 || %teamid < 0.0)
	{
		return 0;
	}
	%this.team = $Team[%teamid];
	$Team[%teamid].realPlayer = 1;
	$Team[%teamid].client = %this;
	$Team[%teamid].playerName = %this.getPlayerName();
	messageAll('MsgClientJoinTeam', '', %this.name, %this.team.name, %this.team.teamId, %this, %this.sendGuid, %this.score, %this.isAIControlled(), %this.isAdmin, %this.isSuperAdmin);
	%this.schedule(0, "spawnPlayer");
}

function GameConnection::leaveTeam(%this)
{
	%this.score = 0;
	$Team[%this.team_id].realPlayer = 0;
	$Team[%this.team_id].client = "";
	$Team[%this.team_id].playerName = "";
	messageAll('MsgClientLeaveTeam', '%1 left the %2 team.', %client.name, %client.team.name, %client);
}

