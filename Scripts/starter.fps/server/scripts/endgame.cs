function endgame_check()
{
	if (!$Game::Sessionfinished)
	{
		for (%i = 1; %i <= $nb_teams; %i++)
		{
			if ($Team[%i].numPlayers >= 5)
			{
				$Game::WiningTeam = %i;
				endgame_ok(%i, $Team[%i].numPlayers);
				break;
			}
		}
	}
	else
	{
		endgame_cameras($Game::WiningTeam, 1);
	}
}

function endgame_ok(%equipe_gagnante, %nb_gagnants)
{
	if (!$Game::Sessionfinished)
	{
		$Game::Sessionfinished = 1;
		endgame_danser(%equipe_gagnante);
		endgame_cameras(%equipe_gagnante, 0);
		endgame_scores(%equipe_gagnante, %nb_gagnants);
		schedule(3000, 0, endgame_screenscores1, %equipe_gagnante, %nb_gagnants);
		schedule(6000, 0, endgame_screenscores2, %equipe_gagnante);
		cycleGame();
	}
}

function endgame_danser(%equipe_gagnante)
{
	for (%current_player_ID = 1; %current_player_ID <= $nb_joueurs_par_team; %current_player_ID++)
	{
		if ($Team[%equipe_gagnante].Player[%current_player_ID])
		{
			if (!%first_winning_player)
			{
				%first_winning_player = $Team[%equipe_gagnante].Player[%current_player_ID];
				$Team[%equipe_gagnante].Player[%current_player_ID].schedule(2000, setSkinName, "base");
			}
			$Team[%equipe_gagnante].Player[%current_player_ID].setImageTrigger(0, 0);
			$Team[%equipe_gagnante].Player[%current_player_ID].setImageTrigger(1, 0);
			cancel($Team[%equipe_gagnante].Player[%current_player_ID].ailoop);
			$Team[%equipe_gagnante].Player[%current_player_ID].stop();
			$Team[%equipe_gagnante].Player[%current_player_ID].setSkinName("happy");
			$Team[%equipe_gagnante].Player[%current_player_ID].setActionThread("danse");
		}
	}
}

function endgame_cameras(%equipe_gagnante, %alreadyPlaying)
{
	for (%current_player_ID = 1; %current_player_ID <= $nb_joueurs_par_team; %current_player_ID++)
	{
		if ($Team[%equipe_gagnante].Player[%current_player_ID])
		{
			if (!%first_winning_player)
			{
				%first_winning_player = $Team[%equipe_gagnante].Player[%current_player_ID];
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

function endgame_scores(%equipe_gagnante, %nb_vivants)
{
	$Team[%equipe_gagnante].score += 2;
	for (%team = 1; %team <= $nb_teams; %team++)
	{
		$Team[%team].score += $Team[%team].numPlayers;
		messageAll('MsgTeamScoreChanged', "", %team, $Team[%team].score);
		messageAll('MsgTeamScoreLTGChanged', "", %team, $Team[%team].score);
	}
}

function endgame_screenscores1(%equipe_gagnante, %nb_gagnants)
{
	if (%equipe_gagnante == 1)
	{
		%nom_equipe_gagnante = $Txt_Scores01;
	}
	else if (%equipe_gagnante == 2)
	{
		%nom_equipe_gagnante = $Txt_Scores02;
	}
	else if (%equipe_gagnante == 3)
	{
		%nom_equipe_gagnante = $Txt_Scores03;
	}
	else if (%equipe_gagnante == 4)
	{
		%nom_equipe_gagnante = $Txt_Scores04;
	}
	echo("STEAM & ACH - endgame_screenscores1");
	%full_team = 0;
	if ($Team[%equipe_gagnante].numPlayers == $nb_joueurs_par_team)
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
	if ($Team[%equipe_gagnante].achivement_temp_not_touched == 1)
	{
		%not_touched = 1;
	}
	echo("STEAM & ACH - %not_touched = " @ %not_touched);
	for (%clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++)
	{
		%cl = ClientGroup.getObject(%clientIndex);
		commandToClient(%cl, 'GameEndScores1', %equipe_gagnante, %nom_equipe_gagnante, %nb_gagnants);
		if ($pref::Server::AI_level >= 5)
		{
			if (%cl.team_id == %equipe_gagnante)
			{
				commandToClient(%cl, 'AchievementNewGamePlayed', 1, %duel, %full_team, %not_touched);
				continue;
			}
			commandToClient(%cl, 'AchievementNewGamePlayed', 0, %duel, %full_team, %not_touched);
		}
	}
}

function endgame_screenscores2(%equipe_gagnante)
{
	for (%clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++)
	{
		%cl = ClientGroup.getObject(%clientIndex);
		commandToClient(%cl, 'GameEndScores2', $nb_teams, %equipe_gagnante, $Team[1].playerName, $Team[2].playerName, $Team[3].playerName, $Team[4].playerName);
	}
}

