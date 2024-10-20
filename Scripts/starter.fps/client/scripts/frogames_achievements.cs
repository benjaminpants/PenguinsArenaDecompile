function achievementNewGamePlayed(%win, %duel, %full_team, %not_touched)
{
	echo("--FROGach-- NewGamePlayed -> win =" SPC %win SPC " |Êduel =" SPC %duel SPC " |Êfull_team =" SPC %full_team SPC " |Ênot_touched =" SPC %not_touched);
	$pref::stats_TotalGamesPlayed++;
	if ($pref::stats_TotalGamesPlayed >= 40)
	{
		unlockAchievement("ACH_40_GAMES_PLAYED");
	}
	if ($pref::stats_TotalGamesPlayed >= 150)
	{
		unlockAchievement("ACH_150_GAMES_PLAYED");
	}
	if (%win)
	{
		$pref::stats_TotalNumWins++;
		if ($pref::stats_TotalNumWins >= 20)
		{
			unlockAchievement("ACH_WIN_20_GAMES");
		}
		if ($pref::stats_TotalNumWins >= 100)
		{
			unlockAchievement("ACH_WIN_100_GAMES");
		}
		$ach_winInThisRow++;
		if ($ach_winInThisRow == 5)
		{
			unlockAchievement("ACH_WIN_5_GAMES_ROW");
			$ach_winInThisRow = 0;
		}
		if (%duel)
		{
			$pref::stats_TotalDuelsNumWins++;
			if ($pref::stats_TotalDuelsNumWins >= 10)
			{
				unlockAchievement("ACH_WIN_10_DUELS");
			}
			if ($pref::stats_TotalDuelsNumWins >= 50)
			{
				unlockAchievement("ACH_WIN_50_DUELS");
			}
		}
		if (%full_team)
		{
			unlockAchievement("ACH_NO_TEAM_LOSS");
		}
		if (%not_touched)
		{
			unlockAchievement("ACH_NOT_TOUCHED");
		}
	}
	else
	{
		$ach_winInThisRow = 0;
	}
}

function clientCmdAchievementNewGamePlayed(%win, %duel, %full_team, %not_touched)
{
	achievementNewGamePlayed(%win, %duel, %full_team, %not_touched);
}

function achievementBonusPris()
{
	$pref::stats_TotalBonusTaken++;
	if ($pref::stats_TotalBonusTaken == 50)
	{
		unlockAchievement("ACH_50_BONUS_TAKEN");
	}
	if ($pref::stats_TotalBonusTaken == 200)
	{
		unlockAchievement("ACH_200_BONUS_TAKEN");
	}
}

function unlockAchievement(%the_achievement)
{
	eval("%current_value = $pref::" @ %the_achievement @ ";");
	if (%current_value !$= "1")
	{
		eval("$pref::" @ %the_achievement @ " = 1;");
		alxPlay("GongAchievement");
		achievementGUIPicture.setBitmap("starter.fps/client/ui/achievements/" @ %the_achievement @ "_on.jpg");
		achievementGUI.setVisible(1);
		achievementGUI.schedule(4000, setVisible, 0);
	}
}

function resetAchievement(%the_achievement)
{
	eval("$pref::" @ %the_achievement @ " = 0;");
}

function achResetAll()
{
	echo("--FROGach-- resetAll");
	$pref::stats_TotalGamesPlayed = 0;
	$pref::stats_TotalNumWins = 0;
	$pref::stats_TotalDuelsNumWins = 0;
	$pref::stats_TotalBonusTaken = 0;
	resetAchievement("ACH_WIN_5_GAMES_ROW");
	resetAchievement("ACH_FLYING_PENGUIN");
	resetAchievement("ACH_NO_TEAM_LOSS");
	resetAchievement("ACH_NOT_TOUCHED");
	resetAchievement("ACH_WIN_100_GAMES");
	resetAchievement("ACH_WIN_20_GAMES");
	resetAchievement("ACH_150_GAMES_PLAYED");
	resetAchievement("ACH_40_GAMES_PLAYED");
	resetAchievement("ACH_200_BONUS_TAKEN");
	resetAchievement("ACH_50_BONUS_TAKEN");
	resetAchievement("ACH_WIN_50_DUELS");
	resetAchievement("ACH_WIN_10_DUELS");
}

function achDebug()
{
	echo("--FROGach-- Debug");
	echo("prefs::stats_TotalGamesPlayed :" SPC $pref::stats_TotalGamesPlayed);
	echo("prefs::stats_TotalNumWins :" SPC $pref::stats_TotalNumWins);
	echo("prefs::stats_TotalDuelsNumWins :" SPC $pref::stats_TotalDuelsNumWins);
	echo("prefs::stats_TotalBonusTaken :" SPC $pref::stats_TotalBonusTaken);
}

