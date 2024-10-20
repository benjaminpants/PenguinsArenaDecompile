function clientCmdSetCounter(%count)
{
	echo("starting in " @ %count);
	alxStop($decompte_sound);
	if (!$firstPerson)
	{
		toggleFirstPerson(1);
	}
	if (%count == 5)
	{
		counter.setVisible(1);
		crosshair.setVisible(0);
	}
	if (%count == 0)
	{
		counter.setBitmap("starter.fps/client/ui/countdown_0.png");
		$decompte_sound = alxPlay(decompte0);
		counter.schedule(1000, setVisible, 0);
		crosshair.schedule(1000, setVisible, 1);
		$currentMusique = "MusiqueIngame";
		if ($pref::Audio::Music)
		{
			schedule(1200, 0, "lancerMusiqueIngame");
		}
	}
	else
	{
		counter.setBitmap("starter.fps/client/ui/countdown_" @ %count @ ".png");
		%sound = "decompte" @ %count;
		$decompte_sound = alxPlay(%sound);
	}
}

function lancerMusiqueIngame()
{
	alxStop($decompte_sound);
	alxStopAll();
	alxPlay("MusiqueIngame");
}

package GameTypeNoMovementDuringDecompte
{
	function clientCmdGameWillStart()
	{
		$clientCountDown = 1;
		$clientCountDownForward = 0;
		$clientCountDownBackward = 0;
		$clientCountDownLeft = 0;
		$clientCountDownRight = 0;
		$mvTriggerCount0 = 0;
	}

};
function clientCmdControlCameraObserver()
{
	moveMap.pop();
	moveMapObserver.push();
	crosshair.setVisible(0);
	clientCmdResetGUIBonus();
	CinemaGUI.setVisible(1);
}

function clientCmdGameStart()
{
	$clientCountDown = 0;
	if ($clientCountDownForward)
	{
		$mvForwardAction = $clientCountDownForward * $movementSpeed;
	}
	if ($clientCountDownBackward)
	{
		$mvBackwardAction = $clientCountDownBackward * $movementSpeed;
	}
	if ($clientCountDownLeft)
	{
		$mvLeftAction = $clientCountDownLeft * $movementSpeed;
	}
	if ($clientCountDownRight)
	{
		$mvRightAction = $clientCountDownRight * $movementSpeed;
	}
}

function clientCmdGameEnd(%__unused)
{
	alxStopAll();
	EndGameGuiList.clear();
	for (%i = 0; %i < PlayerListGuiList.rowCount(); %i++)
	{
		%text = PlayerListGuiList.getRowText(%i);
		%id = PlayerListGuiList.getRowId(%i);
		EndGameGuiList.addRow(%id, %text);
	}
	EndGameGuiList.sortNumerical(1, 0);
}

function clientCmdGameEndScores0()
{
	alxStopAll();
	$currentMusique = "victoire";
	if ($pref::Audio::Music)
	{
		alxPlay("victoire");
	}
	crosshair.setVisible(0);
	container_playgui.setVisible(0);
	DEMOmsgContainer.setVisible(0);
	DEMOmsgContainerFantome.setVisible(0);
	msgBulle.setVisible(0);
	CinemaGUI.setVisible(1);
	moveMap.pop();
	moveMapEndGame.push();
}

function clientCmdGameEndScores1(%equipe_gagnante, %nom_equipe_gagnante, %nb_gagnants)
{
	Scores1GUI.setVisible(1);
	EndGameGuiScores1Pingouin2.setVisible(0);
	EndGameGuiScores1Pingouin3.setVisible(0);
	EndGameGuiScores1Pingouin4.setVisible(0);
	EndGameGuiScores1Pingouin5.setVisible(0);
	EndGameGuiScores1Pingouin6.setVisible(0);
	scorespartie_equipenom.setText(%nom_equipe_gagnante SPC $Txt_Scores05);
	if (%equipe_gagnante == 1)
	{
		EndGameGuiScores1Pingouin1.setBitmap("starter.fps/client/ui/pingouinScoresBleu.png");
		EndGameGuiScores1Pingouin2.setBitmap("starter.fps/client/ui/pingouinScoresBleu.png");
		EndGameGuiScores1Pingouin3.setBitmap("starter.fps/client/ui/pingouinScoresBleu.png");
		EndGameGuiScores1Pingouin4.setBitmap("starter.fps/client/ui/pingouinScoresBleu.png");
		EndGameGuiScores1Pingouin5.setBitmap("starter.fps/client/ui/pingouinScoresBleu.png");
		EndGameGuiScores1Pingouin6.setBitmap("starter.fps/client/ui/pingouinScoresBleu.png");
	}
	else if (%equipe_gagnante == 2)
	{
		EndGameGuiScores1Pingouin1.setBitmap("starter.fps/client/ui/pingouinScoresRouge.png");
		EndGameGuiScores1Pingouin2.setBitmap("starter.fps/client/ui/pingouinScoresRouge.png");
		EndGameGuiScores1Pingouin3.setBitmap("starter.fps/client/ui/pingouinScoresRouge.png");
		EndGameGuiScores1Pingouin4.setBitmap("starter.fps/client/ui/pingouinScoresRouge.png");
		EndGameGuiScores1Pingouin5.setBitmap("starter.fps/client/ui/pingouinScoresRouge.png");
		EndGameGuiScores1Pingouin6.setBitmap("starter.fps/client/ui/pingouinScoresRouge.png");
	}
	else if (%equipe_gagnante == 3)
	{
		EndGameGuiScores1Pingouin1.setBitmap("starter.fps/client/ui/pingouinScoresJaune.png");
		EndGameGuiScores1Pingouin2.setBitmap("starter.fps/client/ui/pingouinScoresJaune.png");
		EndGameGuiScores1Pingouin4.setBitmap("starter.fps/client/ui/pingouinScoresJaune.png");
		EndGameGuiScores1Pingouin5.setBitmap("starter.fps/client/ui/pingouinScoresJaune.png");
		EndGameGuiScores1Pingouin6.setBitmap("starter.fps/client/ui/pingouinScoresJaune.png");
		EndGameGuiScores1Pingouin3.setBitmap("starter.fps/client/ui/pingouinScoresJaune.png");
	}
	else if (%equipe_gagnante == 4)
	{
		EndGameGuiScores1Pingouin1.setBitmap("starter.fps/client/ui/pingouinScoresVert.png");
		EndGameGuiScores1Pingouin2.setBitmap("starter.fps/client/ui/pingouinScoresVert.png");
		EndGameGuiScores1Pingouin3.setBitmap("starter.fps/client/ui/pingouinScoresVert.png");
		EndGameGuiScores1Pingouin4.setBitmap("starter.fps/client/ui/pingouinScoresVert.png");
		EndGameGuiScores1Pingouin5.setBitmap("starter.fps/client/ui/pingouinScoresVert.png");
		EndGameGuiScores1Pingouin6.setBitmap("starter.fps/client/ui/pingouinScoresVert.png");
	}
	scorespartie_nbgagnants.setText($Txt_Scores07);
	if (%nb_gagnants >= 2)
	{
		EndGameGuiScores1Pingouin2.setVisible(1);
	}
	if (%nb_gagnants >= 3)
	{
		EndGameGuiScores1Pingouin3.setVisible(1);
	}
	if (%nb_gagnants >= 4)
	{
		EndGameGuiScores1Pingouin4.setVisible(1);
	}
	if (%nb_gagnants >= 5)
	{
		EndGameGuiScores1Pingouin5.setVisible(1);
	}
	if (%nb_gagnants >= 6)
	{
		EndGameGuiScores1Pingouin6.setVisible(1);
	}
	scorespartie_points.setText(%nb_gagnants + 2 @ $Txt_Scores06);
	if (%nb_gagnants == 1)
	{
		ligne_calculscore.setPosition(132, 45);
	}
	else if (%nb_gagnants == 2)
	{
		ligne_calculscore.setPosition(118, 45);
	}
	else if (%nb_gagnants == 3)
	{
		ligne_calculscore.setPosition(104, 45);
	}
	else if (%nb_gagnants == 4)
	{
		ligne_calculscore.setPosition(90, 45);
	}
	else if (%nb_gagnants == 5)
	{
		ligne_calculscore.setPosition(70, 45);
	}
	else if (%nb_gagnants == 6)
	{
		ligne_calculscore.setPosition(54, 45);
	}
}

function clientCmdGameEndScores2(%nb_equipes, %equipe_gagnante, %nomEquipe1, %nomEquipe2, %nomEquipe3, %nomEquipe4)
{
	Scores1GUI.setVisible(0);
	Scores2GUI.setVisible(1);
	%scoreBleu = bluescore.getValue();
	%scoreRouge = redscore.getValue();
	%scoreJaune = yellowscore.getValue();
	%scoreVert = greenscore.getValue();
	EndGameGuiScores2Scores1.setText(%scoreBleu SPC $Txt_Scores06);
	EndGameGuiScores2Scores2.setText(%scoreRouge SPC $Txt_Scores06);
	EndGameGuiScores2Scores3.setText(%scoreJaune SPC $Txt_Scores06);
	EndGameGuiScores2Scores4.setText(%scoreVert SPC $Txt_Scores06);
	EndGameGuiScores2Name1.setText($Txt_Scores08);
	EndGameGuiScores2Surname1.setText(%nomEquipe1);
	if (%equipe_gagnante == 1)
	{
		EndGameGuiScores2Pingouin1.setBitmap("starter.fps/client/ui/pingouinScoresBleuC.png");
	}
	else
	{
		EndGameGuiScores2Pingouin1.setBitmap("starter.fps/client/ui/pingouinScoresBleu.png");
	}
	EndGameGuiScores2Name2.setText($Txt_Scores09);
	EndGameGuiScores2Surname2.setText(%nomEquipe2);
	if (%equipe_gagnante == 2)
	{
		EndGameGuiScores2Pingouin2.setBitmap("starter.fps/client/ui/pingouinScoresRougeC.png");
	}
	else
	{
		EndGameGuiScores2Pingouin2.setBitmap("starter.fps/client/ui/pingouinScoresRouge.png");
	}
	if (%nb_equipes >= 3)
	{
		EndGameGuiScores2Name3.setVisible(1);
		EndGameGuiScores2Surname3.setVisible(1);
		EndGameGuiScores2Scores3.setVisible(1);
		EndGameGuiScores2Pingouin3.setVisible(1);
		EndGameGuiScores2Name3.setText($Txt_Scores10);
		EndGameGuiScores2Surname3.setText(%nomEquipe3);
		if (%equipe_gagnante == 3)
		{
			EndGameGuiScores2Pingouin3.setBitmap("starter.fps/client/ui/pingouinScoresJauneC.png");
		}
		else
		{
			EndGameGuiScores2Pingouin3.setBitmap("starter.fps/client/ui/pingouinScoresJaune.png");
		}
	}
	else
	{
		EndGameGuiScores2Name3.setVisible(0);
		EndGameGuiScores2Surname3.setVisible(0);
		EndGameGuiScores2Scores3.setVisible(0);
		EndGameGuiScores2Pingouin3.setVisible(0);
	}
	if (%nb_equipes >= 4)
	{
		EndGameGuiScores2Name4.setVisible(1);
		EndGameGuiScores2Surname4.setVisible(1);
		EndGameGuiScores2Scores4.setVisible(1);
		EndGameGuiScores2Pingouin4.setVisible(1);
		EndGameGuiScores2Name4.setText($Txt_Scores11);
		EndGameGuiScores2Surname4.setText(%nomEquipe4);
		if (%equipe_gagnante == 4)
		{
			EndGameGuiScores2Pingouin4.setBitmap("starter.fps/client/ui/pingouinScoresVertC.png");
		}
		else
		{
			EndGameGuiScores2Pingouin4.setBitmap("starter.fps/client/ui/pingouinScoresVert.png");
		}
	}
	else
	{
		EndGameGuiScores2Name4.setVisible(0);
		EndGameGuiScores2Surname4.setVisible(0);
		EndGameGuiScores2Scores4.setVisible(0);
		EndGameGuiScores2Pingouin4.setVisible(0);
	}
}

function clientCmdGameEndTakeScreenshot()
{
	screenShot("./starter.fps/client/ui/lastgame.png", "PNG");
	$endgamescreenshot = 1;
	echo(" ===>>> screenshotloading" SPC $endgamescreenshot);
}

function clientCmdRejoindreEquipe(%teamid)
{
	echo("   ==== My team : " @ %teamid);
	$LocalMyTeamID = %teamid;
}

function clientCmdDeath()
{
	ServerConnection.setBlackOut(1, 50);
	ServerConnection.schedule(900, setBlackOut, 0, 450);
}

function clientCmdCaChit()
{
	ServerConnection.setBlackOut(1, 50);
	ServerConnection.schedule(150, setBlackOut, 0, 300);
}

function clientCmdReincarnationMessage()
{
	PlayGui.ReincarnationMessage();
}

function clientCmdRespawnMessage()
{
	PlayGui.RespawnMessage();
}

function clientCmdWaitingForPlayers()
{
	PlayGui.WaitingMessage();
}

function clientCmdDisconnectIn2minutes()
{
	PlayGui.DisconnectIn2minutes();
}

function clientCmdFullGameOnly(%customText)
{
	cancel($DEMOmsgContainerSchedule);
	cancel($msgBulleSchedule);
	if (%customText !$= "")
	{
		DEMOmsgContainer.setText(%customText);
	}
	else
	{
		DEMOmsgContainer.setText("<just:center>FULL GAME ONLY!");
	}
	alxPlay("son_fullgameonly");
	DEMOmsgContainer.setVisible(1);
	msgBulle.setVisible(1);
	$DEMOmsgContainerSchedule = DEMOmsgContainer.schedule(1000, setVisible, 0);
	$msgBulleSchedule = msgBulle.schedule(1000, setVisible, 0);
}

function clientCmdFullGameOnlyFantome()
{
	alxPlay("son_fullgameonly");
	DEMOmsgContainerFantome.setVisible(1);
	msgBulle.setVisible(1);
}

function clientCmdGotBonus(%bonus, %time)
{
	if (%bonus $= "invincibilite")
	{
		fond_invincibilite.setVisible(1);
		bonus_invincibilite.setVisible(1);
		alxPlay("son_invincibilite");
		fond_invincibilite.schedule(%time, setVisible, 0);
		bonus_invincibilite.schedule(%time, setVisible, 0);
	}
	else if (%bonus $= "griffes")
	{
		bonus_griffes.setVisible(1);
		alxPlay("son_bonus");
		bonus_griffes.schedule(%time, setVisible, 0);
	}
	else
	{
		alxPlay("son_bonus");
	}
	achievementBonusPris();
}

function clientCmdMountDecoObjects()
{
	if ($pref::Player::TopObject != 0)
	{
		commandToServer('MountDecoObjects', "top", $pref::Player::TopObject);
	}
	if ($pref::Player::BottomObject != 0)
	{
		commandToServer('MountDecoObjects', "bottom", $pref::Player::BottomObject);
	}
}

function clientCmdResetGUIBonus()
{
	fond_invincibilite.setVisible(0);
	bonus_invincibilite.setVisible(0);
	bonus_griffes.setVisible(0);
}

function clientCmdCaCtouche(%time)
{
	fond_cactouche.setVisible(1);
	fond_cactouche.schedule(%time, setVisible, 0);
}

function clientCmdSoloGameMapIntro()
{
	Canvas.pushDialog(SoloGameMapIntroHud);
}

