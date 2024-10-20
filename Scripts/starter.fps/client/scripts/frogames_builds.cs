function checkPlimusLicense(%key)
{
	%server = "glm.frogames.com:80";
	%script = "/check_license.php";
	%query = "product=penguinsarena\tkey=" @ %key @ "\tplatform=" @ $platform;
	%httplicense = new HTTPObject(checkLicense);
	%httplicense.get(%server, %script, %query);
}

function checkLicense::onLine(%__unused, %line)
{
	if (%line $= "<!--" || %line $= "-->" || %line $= "")
	{
		return;
	}
	echo("Check License - Return :" SPC %line);
	%licenseOk = 0;
	if ($frogames_licensetype $= "plimus")
	{
		if ($key_to_check !$= "")
		{
			%modified_key = getStringMD5($key_to_check @ $frogames_graindesel);
		}
		else if ($pref::Frogames::license_key !$= "")
		{
			%modified_key = getStringMD5($pref::Frogames::license_key @ $frogames_graindesel);
		}
		if (%line $= %modified_key && %modified_key !$= "")
		{
			%licenseOk = 1;
		}
		else if (%line $= "Sorry our hosting company encounters problems. Please come back later." && $pref::Frogames::license_key !$= "" && strlen($pref::Frogames::license_key) == 18 && strpos($pref::Frogames::license_key, "-") == 3 && strstr($pref::Player::Name, "DemoPenguin") != 0)
		{
			%licenseOk = 1;
		}
	}
	if (%licenseOk)
	{
		if ($BuildType == 40 && $pref::Frogames::license_key $= "")
		{
			echo("Bravo !");
		}
		echo("Check License - OK");
		$BuildType = 30;
		$Game_session_licensecheckdone = 1;
		if (strstr($pref::Player::Name, "DemoPenguin") == 0)
		{
			$pref::Player::Name = "Penguin";
		}
		checkSerialOK();
	}
	else
	{
		echo("Check License - License key not valid");
		checkSerialError();
	}
	packageActivation();
}

function checkLicense::onConnectionDied(%__unused)
{
	error("Check License - ConnectionDied");
	checkSerialProblem();
	if ($frogames_licensetype $= "plimus" && $pref::Frogames::license_key !$= "" && strlen($pref::Frogames::license_key) == 18 && strpos($pref::Frogames::license_key, "-") == 3 && strstr($pref::Player::Name, "DemoPenguin") != 0)
	{
		$BuildType = 30;
	}
	packageActivation();
}

function checkLicense::onDNSFailed(%__unused)
{
	error("Check License - DNSFailed");
	checkSerialProblem();
	if ($frogames_licensetype $= "plimus" && $pref::Frogames::license_key !$= "" && strlen($pref::Frogames::license_key) == 18 && strpos($pref::Frogames::license_key, "-") == 3 && strstr($pref::Player::Name, "DemoPenguin") != 0)
	{
		$BuildType = 30;
	}
	packageActivation();
}

function checkLicense::onConnectFailed(%__unused)
{
	error("Check License - ConnectFailed");
	checkSerialProblem();
	if ($frogames_licensetype $= "plimus" && $pref::Frogames::license_key !$= "" && strlen($pref::Frogames::license_key) == 18 && strpos($pref::Frogames::license_key, "-") == 3 && strstr($pref::Player::Name, "DemoPenguin") != 0)
	{
		$BuildType = 30;
	}
	packageActivation();
}

function checkLicense(%key)
{
	echo("Check License - Checking" SPC %key);
	if ($frogames_licensetype $= "plimus")
	{
		checkPlimusLicense(%key);
	}
}

function packageActivation()
{
	deactivatePackage(GameTypeDebug);
	deactivatePackage(GameTypeDebugControls);
	deactivatePackage(GameTypeNoMovementDuringDecompte);
	deactivatePackage(GameTypeCheckVersion);
	if ($BuildType == 10)
	{
		activatePackage(GameTypeDebug);
		activatePackage(GameTypeDebugControls);
		activatePackage(GameTypeNoMovementDuringDecompte);
	}
	else if ($BuildType == 20)
	{
		activatePackage(GameTypeNoMovementDuringDecompte);
	}
	else if ($BuildType == 22)
	{
		activatePackage(GameTypeNoMovementDuringDecompte);
	}
	else if ($BuildType == 25)
	{
		activatePackage(GameTypeNoMovementDuringDecompte);
	}
	else if ($BuildType == 30)
	{
		activatePackage(GameTypeNoMovementDuringDecompte);
		activatePackage(GameTypeCheckVersion);
	}
	else if ($BuildType == 40)
	{
		activatePackage(GameTypeNoMovementDuringDecompte);
		activatePackage(GameTypeCheckVersion);
	}
	echo("Build type: " @ $BuildType);
}

packageActivation();
