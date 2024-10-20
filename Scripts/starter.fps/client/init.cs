function initClient()
{
	echo("\n--------- Initializing MOD: FPS Starter Kit: Client ---------");
	$Server::Dedicated = 0;
	$Client::MissionTypeQuery = "Any";
	exec("./ui/customProfiles.cs");
	initBaseClient();
	initCanvas("Penguins Arena", 1);
	if (!isObject(Canvas))
	{
		return;
	}
	exec("./scripts/audioProfiles.cs");
	exec("./ui/defaultGameProfiles.cs");
	exec("./ui/PlayGui.gui");
	exec("./ui/ChatHud.gui");
	exec("./ui/playerList.gui");
	exec("./ui/mainMenuGui.gui");
	exec("./ui/aboutDlg.gui");
	exec("./ui/loadingGui.gui");
	exec("./ui/loadingGuiOthers.gui");
	exec("./ui/endGameGui.gui");
	exec("./ui/optionsDlg.gui");
	exec("./ui/remapDlg.gui");
	exec("./ui/StartupGui.gui");
	exec("./ui/StartupGui1.gui");
	exec("./ui/chooseGame.gui");
	exec("./ui/CustomPenguin.gui");
	exec("./ui/chooseSoloGame.gui");
	exec("./ui/QuitDlg.gui");
	exec("./ui/EndScreenGUI.gui");
	exec("./ui/chooseGameGuiPub.gui");
	exec("./ui/frogames_register.gui");
	exec("./scripts/client.cs");
	exec("./scripts/game.cs");
	exec("./scripts/missionDownload.cs");
	exec("./scripts/serverConnection.cs");
	exec("./scripts/playerList.cs");
	exec("./scripts/loadingGui.cs");
	exec("./scripts/loadingGuiOthers.cs");
	exec("./scripts/optionsDlg.cs");
	exec("./scripts/chatHud.cs");
	exec("./scripts/messageHud.cs");
	exec("./scripts/playGui.cs");
	exec("./scripts/centerPrint.cs");
	exec("./scripts/default.bind.cs");
	exec("./config.cs");
	exec("./frogames_init.cs");
	setNetPort(0);
	setShadowDetailLevel($pref::shadows);
	setDefaultFov($pref::Player::defaultFov);
	setZoomSpeed($pref::Player::zoomSpeed);
	if ($JoinGameAddress !$= "")
	{
		loadMainMenu();
		connect($JoinGameAddress, "", $pref::Player::Name);
	}
	else
	{
		Canvas.setCursor("DefaultCursor");
		loadStartup();
	}
}

function loadMainMenu()
{
	Canvas.setContent(MainMenuGui);
	if ($Audio::initFailed)
	{
		MessageBoxOK("Audio Initialization Failed", "The OpenAL audio system failed to initialize.  " @ "You can get the most recent OpenAL drivers <a:www.garagegames.com/docs/torque/gstarted/openal.html>here</a>.");
	}
	Canvas.setCursor("DefaultCursor");
}

