$checkversion_server = $frogames_gpmserver;
$checkversion_script = "/tools/check_version.php";
$checkversion_project = $frogames_project;
$checkversion_hash_id = $frogames_hash_id;
$checkversion_newversion_link = "http://www.frogames.com/penguins_arena/";
$checkversion_current_version = $frogames_current_version;
$version_already_checked = 0;
function checkVersion()
{
	%query = "p=" @ $checkversion_project @ "\thash=" @ $checkversion_hash_id @ "\tcurrent_v=" @ $checkversion_current_version @ "\tplatform=" @ $platform @ "\r";
	%httpversion = new HTTPObject(CheckCurrentVersion);
	%httpversion.get($checkversion_server, $checkversion_script, %query);
}

function CheckCurrentVersion::onLine(%__unused, %line)
{
	if (%line $= "OK" || $BuildType == 10)
	{
		echo("Check Version - Check OK");
		CheckingVersionText.setVisible(0);
		ButtonChooseGameGui.setActive(1);
		ButtonChooseGameGui.setVisible(1);
		$version_already_checked = 1;
		return;
	}
	if (strstr(%line, "PBC") != -1)
	{
		%line_nbchar = strlen(%line);
		%newversion_number = getSubStr(%line, 4, strstr(%line, " link") - 4);
		%newversion_link = getSubStr(%line, strstr(%line, "link") + 5, %line_nbchar - (strstr(%line, "link") + 5));
		CheckingVersionText.setPosition(162, 120);
		CheckingVersionText.setText("A new version is available! (" @ %newversion_number @ ")");
		if (strlen(%newversion_link) > 15 && strstr(%newversion_link, "http://") != -1)
		{
			$checkversion_newversion_link = %newversion_link;
		}
		ButtonDownloadLastVersion.setVisible(1);
		echo("Check Version - Check return: " @ %line);
		$version_already_checked = 1;
		return;
	}
	error("Check Version - Error: ", %line);
	CheckingVersionText.setText("Can't connect to server?");
}

function CheckCurrentVersion::onConnectionDied(%__unused)
{
	error("Check Version - ConnectionDied");
	CheckingVersionText.setPosition(140, 120);
	CheckingVersionText.setText("Connection error - can't check the version.");
	ButtonChooseGameGui.setActive(1);
	ButtonChooseGameGui.setVisible(1);
	$version_already_checked = 1;
}

function CheckCurrentVersion::onDNSFailed(%__unused)
{
	error("Check Version - DNSFailed");
	CheckingVersionText.setPosition(140, 120);
	CheckingVersionText.setText("Connection error - can't check the version.");
	ButtonChooseGameGui.setActive(1);
	ButtonChooseGameGui.setVisible(1);
	$version_already_checked = 1;
}

function CheckCurrentVersion::onConnectFailed(%__unused)
{
	error("Check Version - ConnectFailed");
	CheckingVersionText.setPosition(140, 120);
	CheckingVersionText.setText("Connection error - can't check the version.");
	ButtonChooseGameGui.setActive(1);
	ButtonChooseGameGui.setVisible(1);
	$version_already_checked = 1;
}

function downloadLastVersion()
{
	if ($pref::Video::fullScreen)
	{
		toggleFullScreen();
		%tempo = 1500;
	}
	%stats_query = "fromgame=true&p=" @ $checkversion_project @ "&v=" @ $checkversion_current_version;
	schedule(1000 + %tempo, 0, "gotoWebpage", $checkversion_newversion_link @ "?" @ %stats_query);
}

function stopCheckingVersion()
{
	if (!$version_already_checked)
	{
		error("Check Version - stopCheckingVersion...");
		CheckingVersionText.setPosition(140, 120);
		CheckingVersionText.setText("Connection error - can't reach the server");
		ButtonChooseGameGui.setActive(1);
		ButtonChooseGameGui.setVisible(1);
	}
}

