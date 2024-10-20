function debugTeams()
{
	for (%current_team_ID = 1; %current_team_ID <= $nb_teams; %current_team_ID++)
	{
		if (%current_team_ID == 1)
		{
			%current_team_name = "Blue";
		}
		else if (%current_team_ID == 2)
		{
			%current_team_name = "Red";
		}
		else if (%current_team_ID == 3)
		{
			%current_team_name = "Yellow";
		}
		else if (%current_team_ID == 4)
		{
			%current_team_name = "Green";
		}
		for (%current_player_ID = 1; %current_player_ID <= $nb_joueurs_par_team; %current_player_ID++)
		{
			echo(" " @ %current_team_name SPC "->" SPC $Team[%current_team_ID].Player[%current_player_ID]);
		}
	}
}

function debugPause()
{
	if (!$debugPauseAI)
	{
		$debugPauseAI = 1;
	}
	else
	{
		$debugPauseAI = 0;
	}
}

function debugPauseTires()
{
	if (!$debugPauseAITires)
	{
		$debugPauseAITires = 1;
	}
	else
	{
		$debugPauseAITires = 0;
	}
}

$debugPauseAITires = 0;
function visualDebug()
{
	if (!$debugVisualDebug)
	{
		$debugVisualDebug = 1;
	}
	else
	{
		$debugVisualDebug = 0;
	}
}

if ($dev_build == 1)
{
	$debugVisualDebug = 1;
}
else
{
	$debugVisualDebug = 0;
}
function serverCmdDebugPause()
{
	echo("xxxxxxxxxxxx debugPause xxxxxxxxxxxx");
	debugPause();
}

function serverCmdDebugPauseTires()
{
	echo("xxxxxxxxxxxx debugPause Tires xxxxxxxxxxxx");
	debugPauseTires();
}

function serverCmdDebugTeams()
{
	echo("xxxxxxxxxxxx DebugTeams xxxxxxxxxxxx");
	debugTeams();
	echo("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
}

function serverCmdVisualDebug()
{
	echo("xxxxxxxxxxxx Visual Debug xxxxxxxxxxxx");
	visualDebug();
}

