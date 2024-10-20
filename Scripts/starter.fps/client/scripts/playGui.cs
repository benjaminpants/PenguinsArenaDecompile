function PlayGui::onWake(%__unused)
{
	$enableDirectInput = 1;
	activateDirectInput();
	$escapefromgameDLG = 0;
	if ($pref::Chat)
	{
		Canvas.pushDialog(MainChatHud);
		ChatHud.attach(HudMessageVector);
	}
	if ($pref::Video::vSync)
	{
		setVerticalSync(1);
	}
	else
	{
		setVerticalSync(0);
	}
	crosshair.setVisible(1);
	container_playgui.setVisible(1);
	CinemaGUI.setVisible(0);
	Scores2GUI.setVisible(0);
	msgContainer.setVisible(0);
	DEMOmsgContainer.setVisible(0);
	DEMOmsgContainerFantome.setVisible(0);
	msgBulle.setVisible(0);
	%obj = $pref::Player::TopObject;
	TopObject_Image_GUI.setBitmap("starter.fps/client/ui/objects/objectT" @ %obj @ ".png");
	%obj = $pref::Player::BottomObject;
	BottomObject_Image_GUI.setBitmap("starter.fps/client/ui/objects/objectB" @ %obj @ ".png");
	moveMapObserver.pop();
	moveMap.push();
	schedule(0, 0, "refreshCenterTextCtrl");
	schedule(0, 0, "refreshBottomTextCtrl");
	initIntelGaming();
}

function PlayGui::onSleep(%__unused)
{
	Canvas.popDialog(MainChatHud);
	moveMap.pop();
	exitIntelGaming();
}

function refreshBottomTextCtrl()
{
	BottomPrintText.position = "0 0";
}

function refreshCenterTextCtrl()
{
	CenterPrintText.position = "0 0";
}

addMessageCallback('MsgInitTeamGUI', handleInitTeamGUI);
function handleInitTeamGUI(%__unused, %__unused, %myTeam, %nbTeams, %teamCouronne)
{
	PlayGui.init_TeamGUI(%myTeam, %nbTeams, %teamCouronne);
}

addMessageCallback('MsgUpdateTeamGUI', handleUpdateTeamGUI);
function handleUpdateTeamGUI(%__unused, %__unused, %myTeam, %nbTeams, %current_team, %controled_by_player, %dead, %player_name)
{
	PlayGui.update_TeamGUI(%myTeam, %nbTeams, %current_team, %controled_by_player, %dead, %player_name);
}

addMessageCallback('MsgTeamScoreChanged', handleTeamScoreChanged);
function handleTeamScoreChanged(%__unused, %__unused, %team, %score)
{
	PlayGui.updateScore(%team, %score);
}

addMessageCallback('MsgMembersTeamChanged', handleMembersTeamChanged);
function handleMembersTeamChanged(%__unused, %__unused, %team, %members, %son)
{
	PlayGui.updateTeamMembers(%team, %members, %son);
}

addMessageCallback('MsgTeamScoreLTGChanged', handleTeamScoreLTGChanged);
function handleTeamScoreLTGChanged(%__unused, %__unused, %team, %members)
{
	PlayGui.updateScoreLTG(%team, %members);
}

addMessageCallback('MsgJoinMessage', handleJoinMessage);
function handleJoinMessage(%__unused, %__unused, %teamid, %name)
{
	PlayGui.schedule(1200, JoinMessage, %teamid, %name);
}

addMessageCallback('MsgLeaveMessage', handleLeaveMessage);
function handleLeaveMessage(%__unused, %__unused, %name)
{
	PlayGui.LeaveMessage(%name);
}

addMessageCallback('MsgDuel', handleDuel);
function handleDuel(%__unused, %__unused)
{
	PlayGui.Duel();
}

addMessageCallback('MsgResetScores', handleMsgResetScores);
function handleMsgResetScores(%__unused, %__unused)
{
	PlayGui.ResetScoresMessage();
}

