if (isObject(moveMap))
{
	moveMap.delete();
}
new ActionMap(moveMap);
function escapeFromGame()
{
	if (!$escapefromgameDLG)
	{
		Canvas.pushDialog(QuitDialog);
		$escapefromgameDLG = 1;
	}
	else
	{
		Canvas.popDialog(optionsDlg);
		Canvas.popDialog(QuitDialog);
		$escapefromgameDLG = 0;
	}
}

moveMap.bindCmd(keyboard, "escape", "", "escapeFromGame();");
function showPlayerList(%val)
{
	if (%val)
	{
		PlayerListGui.toggle();
	}
}

moveMap.bind(keyboard, F2, showPlayerList);
moveMap.bind(keyboard, F5, toggleParticleEditor);
$movementSpeed = 1;
function setSpeed(%speed)
{
	if (%speed)
	{
		$movementSpeed = %speed;
	}
}

function moveleft(%val)
{
	if (!$clientCountDown)
	{
		$mvLeftAction = %val * $movementSpeed;
	}
	else
	{
		$clientCountDownLeft = %val;
	}
}

function moveright(%val)
{
	if (!$clientCountDown)
	{
		$mvRightAction = %val * $movementSpeed;
	}
	else
	{
		$clientCountDownRight = %val;
	}
}

function moveForward(%val)
{
	if (!$clientCountDown)
	{
		$mvForwardAction = %val * $movementSpeed;
	}
	else
	{
		$clientCountDownForward = %val;
	}
}

function movebackward(%val)
{
	if (!$clientCountDown)
	{
		$mvBackwardAction = %val * $movementSpeed;
	}
	else
	{
		$clientCountDownBackward = %val;
	}
}

function moveup(%val)
{
	$mvUpAction = %val * $movementSpeed;
}

function movedown(%val)
{
	$mvDownAction = %val * $movementSpeed;
}

function turnLeft(%val)
{
	$mvYawRightSpeed = %val ? $pref::Input::KeyboardTurnSpeed : "0";
}

function turnRight(%val)
{
	$mvYawLeftSpeed = %val ? $pref::Input::KeyboardTurnSpeed : "0";
}

function panUp(%val)
{
	$mvPitchDownSpeed = %val ? $pref::Input::KeyboardTurnSpeed : "0";
}

function panDown(%val)
{
	$mvPitchUpSpeed = %val ? $pref::Input::KeyboardTurnSpeed : "0";
}

function getMouseAdjustAmount(%val)
{
	return %val * ($cameraFov / 90) * 0.009999999776482582 * $pref::Input::MouseSensitivity;
}

function yaw(%val)
{
	$mvYaw += getMouseAdjustAmount(%val);
}

function pitch(%val)
{
	if ($pref::Input::MouseInverted == 1)
	{
		$mvPitch -= getMouseAdjustAmount(%val);
	}
	else
	{
		$mvPitch += getMouseAdjustAmount(%val);
	}
}

function jump(%val)
{
	$mvTriggerCount2++;
}

moveMap.bind(keyboard, a, moveleft);
moveMap.bind(keyboard, d, moveright);
moveMap.bind(keyboard, w, moveForward);
moveMap.bind(keyboard, s, movebackward);
moveMap.bind(keyboard, "left", moveleft);
moveMap.bind(keyboard, "right", moveright);
moveMap.bind(keyboard, "down", movebackward);
moveMap.bind(keyboard, "up", moveForward);
moveMap.bind(keyboard, space, jump);
moveMap.bind(keyboard, numpad0, jump);
moveMap.bind(mouse, xaxis, yaw);
moveMap.bind(mouse, yaxis, pitch);
function mouseFire(%val)
{
	if (!$clientCountDown)
	{
		if (%val > 0)
		{
			$mvTriggerCount0 = 1;
		}
		else
		{
			$mvTriggerCount0 = 0;
		}
	}
}

function altTrigger(%val)
{
	$mvTriggerCount1++;
}

moveMap.bind(mouse, button0, mouseFire);
moveMap.bind(mouse, button1, altTrigger);
if ($Pref::player::CurrentFOV $= "")
{
	$Pref::player::CurrentFOV = 45;
}
function setZoomFOV(%val)
{
	if (%val)
	{
		toggleZoomFOV();
	}
}

function toggleZoom(%val)
{
	if (%val)
	{
		$ZoomOn = 1;
		setFov($Pref::player::CurrentFOV);
	}
	else
	{
		$ZoomOn = 0;
		setFov($pref::Player::defaultFov);
	}
}

moveMap.bind(keyboard, r, setZoomFOV);
$firstPerson = 1;
package GameTypeDebugControls
{
	function toggleFreeLook(%val)
	{
		if (%val)
		{
			$mvFreeLook = 1;
		}
		else
		{
			$mvFreeLook = 0;
		}
	}

	function toggleCamera(%val)
	{
		if (%val)
		{
			commandToServer('ToggleCamera');
		}
	}

};
function toggleFirstPerson(%val)
{
	if (%val)
	{
		$firstPerson = !$firstPerson;
		ServerConnection.setFirstPerson($firstPerson);
	}
}

moveMap.bind(keyboard, tab, toggleFirstPerson);
moveMap.bind(keyboard, "alt c", toggleCamera);
function pageMessageHudUp(%val)
{
	if (%val)
	{
		pageUpMessageHud();
	}
}

function pageMessageHudDown(%val)
{
	if (%val)
	{
		pageDownMessageHud();
	}
}

function resizeMessageHud(%val)
{
	if (%val)
	{
		cycleMessageHudSize();
	}
}

moveMap.bind(keyboard, "u", toggleMessageHud);
moveMap.bind(keyboard, "pageUp", pageMessageHudUp);
moveMap.bind(keyboard, "pageDown", pageMessageHudDown);
function toggleIntel(%val)
{
	if (%val)
	{
		toggleIntelGUI();
	}
}

moveMap.bind(keyboard, "i", toggleIntel);
function startRecordingDemo(%val)
{
	if (%val)
	{
		startDemoRecord();
	}
}

function stopRecordingDemo(%val)
{
	if (%val)
	{
		stopDemoRecord();
	}
}

moveMap.bind(keyboard, F3, startRecordingDemo);
moveMap.bind(keyboard, F4, stopRecordingDemo);
package GameTypeDebugControls
{
	function dropCameraAtPlayer(%val)
	{
		if (%val)
		{
			commandToServer('dropCameraAtPlayer');
		}
	}

	function dropPlayerAtCamera(%val)
	{
		if (%val)
		{
			commandToServer('DropPlayerAtCamera');
		}
	}

};
moveMap.bind(keyboard, "F8", dropCameraAtPlayer);
moveMap.bind(keyboard, "F7", dropPlayerAtCamera);
function bringUpOptions(%val)
{
	if (%val)
	{
		Canvas.pushDialog(optionsDlg);
	}
}

$MFDebugRenderMode = 0;
package GameTypeDebugControls
{
	function cycleDebugRenderMode(%val)
	{
		if (!%val)
		{
			return;
		}
		if (getBuildString() $= "Debug")
		{
			if ($MFDebugRenderMode == 0)
			{
				$MFDebugRenderMode = 1;
				GLEnableOutline(1);
			}
			else if ($MFDebugRenderMode == 1)
			{
				$MFDebugRenderMode = 2;
				GLEnableOutline(0);
				setInteriorRenderMode(7);
				showInterior();
			}
			else if ($MFDebugRenderMode == 2)
			{
				$MFDebugRenderMode = 0;
				setInteriorRenderMode(0);
				GLEnableOutline(0);
				show();
			}
		}
		else
		{
			echo("Debug render modes only available when running a Debug build.");
		}
	}

};
GlobalActionMap.bind(keyboard, "F9", cycleDebugRenderMode);
package GameTypeDebugControls
{
	function demandeToggleConsole(%val)
	{
		ToggleConsole(%val);
	}

};
GlobalActionMap.bind(keyboard, "tilde", demandeToggleConsole);
GlobalActionMap.bindCmd(keyboard, "alt k", "cls();", "");
GlobalActionMap.bindCmd(keyboard, "alt enter", "", "toggleFullScreen();");
moveMap.bindCmd(keyboard, "n", "NetGraph::toggleNetGraph();", "");
if (isObject(moveMapObserver))
{
	moveMapObserver.delete();
}
new ActionMap(moveMapObserver);
moveMapObserver.bindCmd(keyboard, "escape", "", "escapeFromGame();");
moveMapObserver.bind(mouse0, "xaxis", yaw);
moveMapObserver.bind(mouse0, "yaxis", pitch);
moveMapObserver.bind(mouse, button0, mouseFire);
moveMapObserver.bind(keyboard, "u", toggleMessageHud);
if (isObject(moveMapEndGame))
{
	moveMapEndGame.delete();
}
new ActionMap(moveMapEndGame);
moveMapEndGame.bindCmd(keyboard, "escape", "", "escapeFromGame();");
moveMapEndGame.bind(mouse0, "xaxis", yaw);
moveMapEndGame.bind(mouse0, "yaxis", pitch);
moveMapEndGame.bind(keyboard, "u", toggleMessageHud);
