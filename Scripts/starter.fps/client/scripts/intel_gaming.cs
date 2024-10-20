function initIntelGaming()
{
	if (!$pref::Frogames::intelGaming || !isLaptop())
	{
		return;
	}
	$savedPowerScheme = GetCurrentPowerScheme();
	$savedScreenBrightness = GetDisplayScreenBrightness();
	$intelGamingBatteryMode = 0;
	IntelUpdateBatterySaving();
	IntelUpdateWifi();
}

function exitIntelGaming()
{
	cancel($UpdateBatterySavingSchedule);
	cancel($UpdateWifiSchedule);
	if (!$pref::Frogames::intelGaming || !isLaptop())
	{
		return;
	}
	SetCurrentPowerScheme($savedPowerScheme);
	SetDisplayScreenBrightness($savedScreenBrightness);
}

function IntelUpdateBatterySaving()
{
	echo("INTELgaming : UpdateBatterySaving..." SPC getPowerSrc());
	if (isEventPending($UpdateBatterySavingSchedule))
	{
		cancel($UpdateBatterySavingSchedule);
	}
	if (getPowerSrc() $= "Battery_Power")
	{
		%batteryLevel = GetPercentBatteryLife();
		echo("INTELgaming :  I_ battery level = ", %batteryLevel);
		intelPower.setVisible(1);
		if ($intelGamingBatteryMode == 1)
		{
			IntelBatteryWarning();
		}
		if (%batteryLevel < 0.10000000149011612)
		{
			intelPower.setBitmap("starter.fps/client/ui/Battery_0.png");
			if ($intelGamingBatteryMode != 1)
			{
				$pref::timeManagerProcessInterval = 8;
				SetCurrentPowerScheme("Throttle_Degrade");
				if ($savedScreenBrightness > 40)
				{
					SetDisplayScreenBrightness(40);
				}
				setVerticalSync(1);
				echo("INTELgaming :    I_ timeManagerProcessInterval 8 / Throttle_Degrade / Minimum ScreenBrightness / Capping framerate to monitor frequency");
				$intelGamingBatteryMode = 1;
			}
		}
		else if (%batteryLevel < 0.30000001192092896)
		{
			intelPower.setBitmap("starter.fps/client/ui/Battery_2.png");
			if (%batteryLevel < 0.20000000298023224)
			{
				intelPower.setBitmap("starter.fps/client/ui/Battery_1.png");
			}
			if ($intelGamingBatteryMode != 2)
			{
				$pref::timeManagerProcessInterval = 4;
				SetCurrentPowerScheme("Throttle_Adaptive");
				if ($savedScreenBrightness > 70)
				{
					SetDisplayScreenBrightness($savedScreenBrightness - 30);
				}
				else if ($savedScreenBrightness > 50)
				{
					SetDisplayScreenBrightness(50);
				}
				setVerticalSync(1);
				echo("INTELgaming :    I_ timeManagerProcessInterval 4 / Low ScreenBrightness / Capping framerate to monitor frequency");
				$intelGamingBatteryMode = 2;
			}
		}
		else if (%batteryLevel < 0.5)
		{
			intelPower.setBitmap("starter.fps/client/ui/Battery_4.png");
			if (%batteryLevel < 0.4000000059604645)
			{
				intelPower.setBitmap("starter.fps/client/ui/Battery_3.png");
			}
			if ($intelGamingBatteryMode != 3)
			{
				$pref::timeManagerProcessInterval = 2;
				SetCurrentPowerScheme("Throttle_Adaptive");
				if ($savedScreenBrightness > 70)
				{
					SetDisplayScreenBrightness($savedScreenBrightness - 20);
				}
				setVerticalSync(0);
				echo("INTELgaming :    I_ timeManagerProcessInterval 2 / Medium ScreenBrightness / No framerate capping");
				$intelGamingBatteryMode = 3;
			}
		}
		else
		{
			if (%batteryLevel < 0.6000000238418579)
			{
				intelPower.setBitmap("starter.fps/client/ui/Battery_5.png");
			}
			else if (%batteryLevel < 0.699999988079071)
			{
				intelPower.setBitmap("starter.fps/client/ui/Battery_6.png");
			}
			else if (%batteryLevel < 0.800000011920929)
			{
				intelPower.setBitmap("starter.fps/client/ui/Battery_7.png");
			}
			else if (%batteryLevel < 0.8999999761581421)
			{
				intelPower.setBitmap("starter.fps/client/ui/Battery_8.png");
			}
			else
			{
				intelPower.setBitmap("starter.fps/client/ui/Battery_9.png");
			}
			if ($intelGamingBatteryMode != 4)
			{
				$pref::timeManagerProcessInterval = 0;
				SetCurrentPowerScheme("Throttle_Constant");
				if ($savedScreenBrightness != GetDisplayScreenBrightness())
				{
					SetDisplayScreenBrightness($savedScreenBrightness);
				}
				setVerticalSync(0);
				echo("INTELgaming :    I_ timeManagerProcessInterval 0 / Normal ScreenBrightness / No framerate capping");
				$intelGamingBatteryMode = 4;
			}
		}
	}
	else if (getPowerSrc() $= "AC_Power")
	{
		if ($intelGamingBatteryMode != 10)
		{
			$pref::timeManagerProcessInterval = 0;
			intelPower.setVisible(0);
			SetCurrentPowerScheme("Throttle_Constant");
			setVerticalSync(0);
			if ($savedScreenBrightness != GetDisplayScreenBrightness())
			{
				SetDisplayScreenBrightness($savedScreenBrightness);
			}
			echo("INTELgaming :  I_ on AC power !");
			$intelGamingBatteryMode = 10;
		}
	}
	else if (getPowerSrc() $= "Error")
	{
		error("ERROR: UpdateBatterySaving() - unknown power source");
		intelPower.setVisible(0);
	}
	$UpdateBatterySavingSchedule = schedule(15 * 1000, 0, IntelUpdateBatterySaving);
}

function IntelBatteryWarning()
{
	IntelBackground.setVisible(1);
	IntelBatteryWarning.setVisible(1);
	IntelWifiWarning.setVisible(0);
	IntelBackground.schedule(4000, setVisible, 0);
	IntelBatteryWarning.schedule(4000, setVisible, 0);
}

function IntelWifiWarning()
{
	IntelBackground.setVisible(1);
	IntelWifiWarning.setVisible(1);
	IntelBatteryWarning.setVisible(0);
	IntelBackground.schedule(4000, setVisible, 0);
	IntelWifiWarning.schedule(4000, setVisible, 0);
}

function IntelUpdateWifi()
{
	echo("INTELgaming : UpdateWifi...");
	if (isEventPending($UpdateWifiSchedule))
	{
		cancel($UpdateWifiSchedule);
	}
	if (IsWirelessAdapterEnabled())
	{
		intelConnectivity.setVisible(1);
		intelConnectivity.setBitmap("starter.fps/client/ui/WiFi_no.png");
		if (IsWirelessAdapterConnected())
		{
			intelConnectivity.setVisible(1);
			if (Get80211SignalStrength() <= 0.05000000074505806)
			{
				IntelWifiWarning();
				intelConnectivity.setBitmap("starter.fps/client/ui/WiFi_0.png");
			}
			else if (Get80211SignalStrength() <= 0.25)
			{
				intelConnectivity.setBitmap("starter.fps/client/ui/WiFi_1.png");
			}
			else if (Get80211SignalStrength() <= 0.5)
			{
				intelConnectivity.setBitmap("starter.fps/client/ui/WiFi_2.png");
			}
			else if (Get80211SignalStrength() <= 0.75)
			{
				intelConnectivity.setBitmap("starter.fps/client/ui/WiFi_3.png");
			}
			else
			{
				intelConnectivity.setBitmap("starter.fps/client/ui/WiFi_4.png");
			}
			$UpdateWifiSchedule = schedule(2 * 1000, 0, IntelUpdateWifi);
		}
		else
		{
			intelConnectivity.setVisible(0);
			echo("INTELgaming :   I_ Adapter not Connected");
			$UpdateWifiSchedule = schedule(20 * 1000, 0, IntelUpdateWifi);
		}
	}
	else
	{
		intelConnectivity.setVisible(0);
		echo("INTELgaming :   I_ Adapter not Enabled");
		$UpdateWifiSchedule = schedule(30 * 1000, 0, IntelUpdateWifi);
	}
}

function toggleIntelGUI()
{
	if (intel_GUI.isVisible())
	{
		intel_GUI.setVisible(0);
	}
	else
	{
		intel_GUI.setVisible(1);
	}
}

