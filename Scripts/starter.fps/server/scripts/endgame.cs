function endgame_check()
{
	if (!$Game::Sessionfinished)
	{
		for (%i = 1; %i <= $team_count; %i++)
		{
			if ($Team[%i].numPlayers >= 1)
			{
				%living_teams_count = %living_teams_count + 1;
			}
		}
		if (%living_teams_count < 2)
		{
			for (%i = 1; %i <= $team_count; %i++)
			{
				if ($Team[%i].numPlayers)
				{
					endgame_ok(%i, $Team[%i].numPlayers);
					$Game::WiningTeam = %i;
					break;
				}
			}
		}
		else if ($Team[1].numPlayers + $Team[2].numPlayers + $Team[3].numPlayers + $Team[4].numPlayers == 2)
		{
			messageAll('MsgDuel');
			$achivement_temp_duel = 1;
		}
	}
	else
	{
		endgame_cameras($Game::WiningTeam, 1);
	}
}

function endgame_ok(%winning_team, %number_winners)
{
	if (!$Game::Sessionfinished)
	{
		$Game::Sessionfinished = 1;
		endgame_danser(%winning_team);
		endgame_cameras(%winning_team, 0);
		endgame_scores(%winning_team, %number_winners);
		schedule(3000, 0, endgame_screenscores1, %winning_team, %number_winners);
		schedule(6000, 0, endgame_screenscores2, %winning_team);
		cycleGame();
	}
}

function endgame_danser(%winning_team)
{
	for (%current_player_ID = 1; %current_player_ID <= $players_per_team; %current_player_ID++)
	{
		if ($Team[%winning_team].Player[%current_player_ID])
		{
			if (!%first_winning_player)
			{
				%first_winning_player = $Team[%winning_team].Player[%current_player_ID];
				$Team[%winning_team].Player[%current_player_ID].schedule(2000, setSkinName, "base");
			}
			$Team[%winning_team].Player[%current_player_ID].setImageTrigger(0, 0);
			$Team[%winning_team].Player[%current_player_ID].setImageTrigger(1, 0);
			cancel($Team[%winning_team].Player[%current_player_ID].ailoop);
			$Team[%winning_team].Player[%current_player_ID].stop();
			$Team[%winning_team].Player[%current_player_ID].setSkinName("happy");
			$Team[%winning_team].Player[%current_player_ID].setActionThread("danse");
		}
	}
}

function endgame_cameras(%winning_team, %alreadyPlaying)
{
	for (%current_player_ID = 1; %current_player_ID <= $players_per_team; %current_player_ID++)
	{
		if ($Team[%winning_team].Player[%current_player_ID])
		{
			if (!%first_winning_player)
			{
				%first_winning_player = $Team[%winning_team].Player[%current_player_ID];
			}
			break;
		}
	}
	if (%first_winning_player)
	{
		%first_winning_player.unmountImage(2);
		%first_winning_player.unmountImage(3);
	}
	for (%clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++)
	{
		%cl = ClientGroup.getObject(%clientIndex);
		if (isObject(%cl.Camera) && %first_winning_player)
		{
			%cl.Camera.setMode("Corpse", %first_winning_player);
			%cl.setControlObject(%cl.Camera);
			if (!%alreadyPlaying)
			{
				commandToClient(%cl, 'GameEndScores0');
			}
		}
		else if (!%cl.isAIControlled())
		{
			echo("CAMERA - oups... endgameNoCamera");
			%cl.endgameNoCamera();
		}
	}
}

function endgame_scores(%winning_team, %nb_vivants)
{
	%score_current_partie = 2 + %nb_vivants;
	$Team[%winning_team].score += %score_current_partie;
	messageAll('MsgTeamScoreChanged', "", %winning_team, $Team[%winning_team].score);
	for (%team = 1; %team <= $team_count; %team++)
	{
		for (%i = 1; %i <= 9; %i++)
		{
			$Team[%team].scoreLTG[%i] = $Team[%team].scoreLTG[%i + 1];
		}
		if (%team == %winning_team)
		{
			$Team[%team].scoreLTG[10] = %score_current_partie;
		}
		else
		{
			$Team[%team].scoreLTG[10] = 0;
		}
		$Team[%team].scoreLTGtotal = 0;
		for (%i = 1; %i <= 10; %i++)
		{
			$Team[%team].scoreLTGtotal = $Team[%team].scoreLTGtotal + $Team[%team].scoreLTG[%i];
		}
		messageAll('MsgTeamScoreLTGChanged', "", %team, $Team[%team].scoreLTGtotal);
	}
}

function endgame_screenscores1(%winning_team, %number_winners)
{
	if (%winning_team == 1)
	{
		%nom_winning_team = $Txt_Scores01;
	}
	else if (%winning_team == 2)
	{
		%nom_winning_team = $Txt_Scores02;
	}
	else if (%winning_team == 3)
	{
		%nom_winning_team = $Txt_Scores03;
	}
	else if (%winning_team == 4)
	{
		%nom_winning_team = $Txt_Scores04;
	}
	echo("STEAM & ACH - endgame_screenscores1");
	%full_team = 0;
	if ($Team[%winning_team].numPlayers == $players_per_team)
	{
		%full_team = 1;
	}
	echo("STEAM & ACH - %full_team = " @ %full_team);
	%duel = 0;
	if ($achivement_temp_duel == 1)
	{
		%duel = 1;
	}
	echo("STEAM & ACH - %duel = " @ %duel);
	%not_touched = 0;
	if ($Team[%winning_team].achivement_temp_not_touched == 1)
	{
		%not_touched = 1;
	}
	echo("STEAM & ACH - %not_touched = " @ %not_touched);
	for (%clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++)
	{
		%cl = ClientGroup.getObject(%clientIndex);
		commandToClient(%cl, 'GameEndScores1', %winning_team, %nom_winning_team, %number_winners);
		if ($pref::Server::AI_level >= 5)
		{
			if (%cl.team_id == %winning_team)
			{
				commandToClient(%cl, 'AchievementNewGamePlayed', 1, %duel, %full_team, %not_touched);
				continue;
			}
			commandToClient(%cl, 'AchievementNewGamePlayed', 0, %duel, %full_team, %not_touched);
		}
	}
}

function endgame_screenscores2(%winning_team)
{
	for (%clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++)
	{
		%cl = ClientGroup.getObject(%clientIndex);
		commandToClient(%cl, 'GameEndScores2', $team_count, %winning_team, $Team[1].playerName, $Team[2].playerName, $Team[3].playerName, $Team[4].playerName);
	}
}

