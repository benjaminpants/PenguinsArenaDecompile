function optionsDlg::setPane(%this, %pane)
{
	OptAudioPane.setVisible(0);
	OptGraphicsPane.setVisible(0);
	OptNetworkPane.setVisible(0);
	OptControlsPane.setVisible(0);
	("Opt" @ %pane @ "Pane").setVisible(1);
	OptRemapList.fillList();
}

function optionsDlg::onWake(%this)
{
	$enableDirectInput = 1;
	activateDirectInput();
	OptMouseSensitivity.setValue($pref::Input::MouseSensitivity);
	initOptionSets();
	if ($BuildType == 40)
	{
		OptControlsChatToggle.setText(" Display Chat window (not available in the demo)");
		OptControlsChatToggle.setActive(0);
	}
	if (isLaptop())
	{
		IntelGamingToggle.setVisible(1);
	}
	OptGraphicsButton.performClick();
	%buffer = getDisplayDeviceList();
	%count = getFieldCount(%buffer);
	OptGraphicsDriverMenu.clear();
	for (%i = 0; %i < %count; %i++)
	{
		OptGraphicsDriverMenu.add(getField(%buffer, %i), %i);
	}
	%selId = OptGraphicsDriverMenu.findText($pref::Video::displayDevice);
	if (%selId == -1)
	{
		%selId = 0;
	}
	OptGraphicsDriverMenu.setSelected(%selId);
	OptGraphicsDriverMenu.onSelect(%selId, "");
	OptAudioUpdate();
	OptAudioVolumeMaster.setValue($pref::Audio::masterVolume);
	OptAudioVolumeShell.setValue($pref::Audio::channelVolume[$GuiAudioType]);
	OptAudioVolumeSim.setValue($pref::Audio::channelVolume[$SimAudioType]);
	OptAudioDriverList.clear();
	OptAudioDriverList.add("OpenAL", 1);
	OptAudioDriverList.add("none", 2);
	%selId = OptAudioDriverList.findText($pref::Audio::driver);
	if (%selId == -1)
	{
		%selId = 0;
	}
	OptAudioDriverList.setSelected(%selId);
	OptAudioDriverList.onSelect(%selId, "");
}

function optionsDlg::onSleep(%this)
{
	moveMap.save("./client/config.cs");
}

function OptGraphicsDriverMenu::onSelect(%this, %__unused, %text)
{
	if (OptGraphicsResolutionMenu.size() > 0)
	{
		%prevRes = OptGraphicsResolutionMenu.getText();
	}
	else
	{
		%prevRes = getWords($pref::Video::resolution, 0, 1);
	}
	if (isDeviceFullScreenOnly(%this.getText()))
	{
		OptGraphicsFullscreenToggle.setValue(1);
		OptGraphicsFullscreenToggle.setActive(0);
		OptGraphicsFullscreenToggle.onAction();
	}
	else
	{
		OptGraphicsFullscreenToggle.setActive(1);
	}
	if (OptGraphicsFullscreenToggle.getValue())
	{
		if (OptGraphicsBPPMenu.size() > 0)
		{
			%prevBPP = OptGraphicsBPPMenu.getText();
		}
		else
		{
			%prevBPP = getWord($pref::Video::resolution, 2);
		}
	}
	OptGraphicsResolutionMenu.init(%this.getText(), OptGraphicsFullscreenToggle.getValue());
	OptGraphicsBPPMenu.init(%this.getText());
	%selId = OptGraphicsResolutionMenu.findText(%prevRes);
	if (%selId == -1)
	{
		%selId = 0;
	}
	OptGraphicsResolutionMenu.setSelected(%selId);
	if (OptGraphicsFullscreenToggle.getValue())
	{
		%selId = OptGraphicsBPPMenu.findText(%prevBPP);
		if (%selId == -1)
		{
			%selId = 0;
		}
		OptGraphicsBPPMenu.setSelected(%selId);
		OptGraphicsBPPMenu.setText(OptGraphicsBPPMenu.getTextById(%selId));
	}
	else
	{
		OptGraphicsBPPMenu.setText("Default");
	}
}

function OptGraphicsResolutionMenu::init(%this, %device, %fullScreen)
{
	%this.clear();
	%resList = getResolutionList(%device);
	%resCount = getFieldCount(%resList);
	%deskRes = getDesktopResolution();
	%count = 0;
	for (%i = 0; %i < %resCount; %i++)
	{
		%res = getWords(getField(%resList, %i), 0, 1);
		if (!%fullScreen)
		{
			if (firstWord(%res) >= firstWord(%deskRes))
			{
				continue;
			}
			if (getWord(%res, 1) >= getWord(%deskRes, 1))
			{
				continue;
			}
		}
		if (%this.findText(%res) == -1)
		{
			%this.add(%res, %count);
			%count++;
		}
	}
}

function OptGraphicsFullscreenToggle::onAction(%this)
{
	Parent::onAction();
	%prevRes = OptGraphicsResolutionMenu.getText();
	OptGraphicsResolutionMenu.init(OptGraphicsDriverMenu.getText(), %this.getValue());
	%selId = OptGraphicsResolutionMenu.findText(%prevRes);
	if (%selId == -1)
	{
		%selId = 0;
	}
	OptGraphicsResolutionMenu.setSelected(%selId);
}

function OptGraphicsBPPMenu::init(%this, %device)
{
	%this.clear();
	if (%device $= "Voodoo2")
	{
		%this.add(16, 0);
	}
	else
	{
		%resList = getResolutionList(%device);
		%resCount = getFieldCount(%resList);
		%count = 0;
		for (%i = 0; %i < %resCount; %i++)
		{
			%bpp = getWord(getField(%resList, %i), 2);
			if (%this.findText(%bpp) == -1)
			{
				%this.add(%bpp, %count);
				%count++;
			}
		}
	}
}

function OptScreenshotMenu::init(%this)
{
	if (%this.findText("PNG") == -1)
	{
		%this.add("PNG", 0);
	}
	if (%this.findText("JPEG") == -1)
	{
		%this.add("JPEG", 1);
	}
}

function optionsDlg::applyGraphics(%this)
{
	%newDriver = OptGraphicsDriverMenu.getText();
	%newRes = OptGraphicsResolutionMenu.getText();
	%newBpp = OptGraphicsBPPMenu.getText();
	%newFullScreen = OptGraphicsFullscreenToggle.getValue();
	if (%newDriver !$= $pref::Video::displayDevice)
	{
		setDisplayDevice(%newDriver, firstWord(%newRes), getWord(%newRes, 1), %newBpp, %newFullScreen);
	}
	else
	{
		setScreenMode(firstWord(%newRes), getWord(%newRes, 1), %newBpp, %newFullScreen);
	}
}

$RemapCount = 0;
$RemapName[$RemapCount] = "Forward";
$RemapCmd[$RemapCount] = "moveforward";
$RemapCount++;
$RemapName[$RemapCount] = "Backward";
$RemapCmd[$RemapCount] = "movebackward";
$RemapCount++;
$RemapName[$RemapCount] = "Strafe Left";
$RemapCmd[$RemapCount] = "moveleft";
$RemapCount++;
$RemapName[$RemapCount] = "Strafe Right";
$RemapCmd[$RemapCount] = "moveright";
$RemapCount++;
$RemapName[$RemapCount] = "Jump";
$RemapCmd[$RemapCount] = "jump";
$RemapCount++;
$RemapName[$RemapCount] = "Fire Weapon";
$RemapCmd[$RemapCount] = "mouseFire";
$RemapCount++;
$RemapName[$RemapCount] = "Punch";
$RemapCmd[$RemapCount] = "altTrigger";
$RemapCount++;
if (isLaptop())
{
	$RemapName[$RemapCount] = "Toggle IntelLaptop GUI";
	$RemapCmd[$RemapCount] = "toggleIntel";
	$RemapCount++;
}
function restoreDefaultMappings()
{
	moveMap.delete();
	exec("~/scripts/default.bind.cs");
	OptRemapList.fillList();
}

function getMapDisplayName(%device, %action)
{
	if (%device $= "keyboard")
	{
		return %action;
	}
	else if (strstr(%device, "mouse") != -1)
	{
		%pos = strstr(%action, "button");
		if (%pos != -1)
		{
			%mods = getSubStr(%action, 0, %pos);
			%object = getSubStr(%action, %pos, 1000);
			%instance = getSubStr(%object, strlen("button"), 1000);
			return %mods @ "mouse" @ %instance + 1;
		}
		else
		{
			error("Mouse input object other than button passed to getDisplayMapName!");
		}
	}
	else if (strstr(%device, "joystick") != -1)
	{
		%pos = strstr(%action, "button");
		if (%pos != -1)
		{
			%mods = getSubStr(%action, 0, %pos);
			%object = getSubStr(%action, %pos, 1000);
			%instance = getSubStr(%object, strlen("button"), 1000);
			return %mods @ "joystick" @ %instance + 1;
		}
		else
		{
			%pos = strstr(%action, "pov");
			if (%pos != -1)
			{
				%wordCount = getWordCount(%action);
				%mods = %wordCount > 1 ? getWords(%action, 0, %wordCount - 2) @ " " : "";
				%object = getWord(%action, %wordCount - 1);
				if (%object $= "upov")
				{
					%object = "POV1 up";
				}
				else if (%object $= "dpov")
				{
					%object = "POV1 down";
				}
				else if (%object $= "lpov")
				{
					%object = "POV1 left";
				}
				else if (%object $= "rpov")
				{
					%object = "POV1 right";
				}
				else if (%object $= "upov2")
				{
					%object = "POV2 up";
				}
				else if (%object $= "dpov2")
				{
					%object = "POV2 down";
				}
				else if (%object $= "lpov2")
				{
					%object = "POV2 left";
				}
				else if (%object $= "rpov2")
				{
					%object = "POV2 right";
				}
				else
				{
					%object = "??";
				}
				return %mods @ %object;
			}
			else
			{
				error("Unsupported Joystick input object passed to getDisplayMapName!");
			}
		}
	}
	return "??";
}

function buildFullMapString(%index)
{
	%name = $RemapName[%index];
	%cmd = $RemapCmd[%index];
	%temp = moveMap.getBinding(%cmd);
	if (%temp $= "")
	{
		return %name TAB "";
	}
	%mapString = "";
	%count = getFieldCount(%temp);
	for (%i = 0; %i < %count; %i += 2)
	{
		if (%mapString !$= "")
		{
			%mapString = %mapString @ ", ";
		}
		%device = getField(%temp, %i + 0);
		%object = getField(%temp, %i + 1);
		%mapString = %mapString @ getMapDisplayName(%device, %object);
	}
	return %name TAB %mapString;
}

function OptRemapList::fillList(%this)
{
	%this.clear();
	for (%i = 0; %i < $RemapCount; %i++)
	{
		%this.addRow(%i, buildFullMapString(%i));
	}
}

function OptRemapList::doRemap(%this)
{
	%selId = %this.getSelectedId();
	%name = $RemapName[%selId];
	OptRemapText.setValue("REMAP \"" @ %name @ "\"");
	OptRemapInputCtrl.index = %selId;
	Canvas.pushDialog(RemapDlg);
}

function redoMapping(%device, %action, %cmd, %oldIndex, %newIndex)
{
	moveMap.bind(%device, %action, %cmd);
	OptRemapList.setRowById(%oldIndex, buildFullMapString(%oldIndex));
	OptRemapList.setRowById(%newIndex, buildFullMapString(%newIndex));
}

function findRemapCmdIndex(%command)
{
	for (%i = 0; %i < $RemapCount; %i++)
	{
		if (%command $= $RemapCmd[%i])
		{
			return %i;
		}
	}
	return -1;
}

function unbindExtraActions(%command, %count)
{
	%temp = moveMap.getBinding(%command);
	if (%temp $= "")
	{
		return;
	}
	%count = getFieldCount(%temp) - %count * 2;
	for (%i = 0; %i < %count; %i += 2)
	{
		%device = getField(%temp, %i + 0);
		%action = getField(%temp, %i + 1);
		moveMap.unbind(%device, %action);
	}
}

function OptRemapInputCtrl::onInputEvent(%this, %device, %action)
{
	Canvas.popDialog(RemapDlg);
	if (%device $= "keyboard")
	{
		if (%action $= "escape")
		{
			return;
		}
	}
	%cmd = $RemapCmd[%this.index];
	%name = $RemapName[%this.index];
	%mapName = getMapDisplayName(%device, %action);
	%prevMap = moveMap.getCommand(%device, %action);
	if (%prevMap $= "")
	{
		unbindExtraActions(%cmd, 1);
		moveMap.bind(%device, %action, %cmd);
		OptRemapList.setRowById(%this.index, buildFullMapString(%this.index));
		return;
	}
	if (%prevMap $= %cmd)
	{
		unbindExtraActions(%cmd, 0);
		moveMap.bind(%device, %action, %cmd);
		OptRemapList.setRowById(%this.index, buildFullMapString(%this.index));
		return;
	}
	%prevMapIndex = findRemapCmdIndex(%prevMap);
	if (%prevMapIndex == -1)
	{
		MessageBoxOK("Remap Failed", "\"" @ %mapName @ "\" is already bound to a non-remappable command!");
		return;
	}
	%callback = "redoMapping(" @ %device @ ", \"" @ %action @ "\", \"" @ %cmd @ "\", " @ %prevMapIndex @ ", " @ %this.index @ ");";
	%prevCmdName = $RemapName[%prevMapIndex];
	MessageBoxYesNo("Warning", "\"" @ %mapName @ "\" is already bound to \"" @ %prevCmdName @ "\"!\nDo you wish to replace this mapping?", %callback, "");
}

function OptAudioUpdate()
{
	%text = "Vendor: " @ alGetString("AL_VENDOR") @ "\nVersion: " @ alGetString("AL_VERSION") @ "\nRenderer: " @ alGetString("AL_RENDERER") @ "\nExtensions: " @ alGetString("AL_EXTENSIONS");
	OptAudioInfo.setText(%text);
}

new AudioDescription(AudioChannel0)
{
	volume = 1;
	isLooping = 0;
	is3D = 0;
	type = 0;
};
new AudioDescription(AudioChannel1)
{
	volume = 1;
	isLooping = 0;
	is3D = 0;
	type = 1;
};
new AudioDescription(AudioChannel2)
{
	volume = 1;
	isLooping = 0;
	is3D = 0;
	type = 2;
};
new AudioDescription(AudioChannel3)
{
	volume = 1;
	isLooping = 0;
	is3D = 0;
	type = 3;
};
new AudioDescription(AudioChannel4)
{
	volume = 1;
	isLooping = 0;
	is3D = 0;
	type = 4;
};
new AudioDescription(AudioChannel5)
{
	volume = 1;
	isLooping = 0;
	is3D = 0;
	type = 5;
};
new AudioDescription(AudioChannel6)
{
	volume = 1;
	isLooping = 0;
	is3D = 0;
	type = 6;
};
new AudioDescription(AudioChannel7)
{
	volume = 1;
	isLooping = 0;
	is3D = 0;
	type = 7;
};
new AudioDescription(AudioChannel8)
{
	volume = 1;
	isLooping = 0;
	is3D = 0;
	type = 8;
};
$AudioTestHandle = 0;
function OptAudioUpdateMasterVolume(%volume)
{
	if (%volume == $pref::Audio::masterVolume)
	{
		return;
	}
	alxListenerf(AL_GAIN_LINEAR, %volume);
	$pref::Audio::masterVolume = %volume;
	if (!alxIsPlaying($AudioTestHandle))
	{
		$AudioTestHandle = alxCreateSource("AudioChannel0", expandFilename("~/data/sound/testing.wav"));
		alxPlay($AudioTestHandle);
	}
}

function OptAudioUpdateChannelVolume(%channel, %volume)
{
	if (%channel < 1 || %channel > 8)
	{
		return;
	}
	if (%volume == $pref::Audio::channelVolume[%channel])
	{
		return;
	}
	alxSetChannelVolume(%channel, %volume);
	$pref::Audio::channelVolume[%channel] = %volume;
	if (!alxIsPlaying($AudioTestHandle))
	{
		$AudioTestHandle = alxCreateSource("AudioChannel" @ %channel, expandFilename("~/data/sound/testing.wav"));
		alxPlay($AudioTestHandle);
	}
}

function OptAudioDriverList::onSelect(%this, %__unused, %text)
{
	if (%text $= "")
	{
		return;
	}
	if ($pref::Audio::driver $= %text)
	{
		return;
	}
	$pref::Audio::driver = %text;
	OpenALInit();
}

function OptMouseSetSensitivity(%value)
{
	$pref::Input::MouseSensitivity = %value;
}

function optionsDlg::applyGraphicsSet(%this)
{
	%newDriver = OptGraphicsDriverMenu.getText();
	%newRes = getWords($pref::Video::resolution, 0, 1);
	%newBpp = getWord($pref::Video::resolution, 2);
	%newFullScreen = OptGraphicsFullscreenToggle.getValue();
	if (%newBpp != 32 && %newBpp != 16)
	{
		%newBpp = 32;
	}
	if (%newDriver !$= $pref::Video::displayDevice)
	{
		setDisplayDevice(%newDriver, firstWord(%newRes), getWord(%newRes, 1), %newBpp, %newFullScreen);
	}
	else
	{
		setScreenMode(firstWord(%newRes), getWord(%newRes, 1), %newBpp, %newFullScreen);
	}
}

function optionsDlg::selectGraphicOptionsSet(%this, %set)
{
	if (%set == 1)
	{
		exec("~/client/defaults_low.cs");
	}
	else if (%set == 2)
	{
		exec("~/client/defaults_medium.cs");
	}
	else if (%set == 3)
	{
		exec("~/client/defaults_heavy.cs");
	}
	echo(" option set selected : " @ %set);
	initOptionSets();
	MessageBoxOK("Changed option set", "New graphic set selected.\n\n On some machines you'll need to restart the game after changing graphics options to get full optimizations.");
}

function optionsDlg::chatToggle(%this, %value)
{
	if (Canvas.getContent() == PlayGui.getId() && %value)
	{
		Canvas.pushDialog(MainChatHud);
		ChatHud.attach(HudMessageVector);
	}
	else
	{
		Canvas.popDialog(MainChatHud);
	}
}

function optionsDlg::vSyncToggle(%this, %value)
{
	if (%value)
	{
		setVerticalSync(1);
	}
	else
	{
		setVerticalSync(0);
	}
}

function optionsDlg::vSyncToggle(%this, %value)
{
	if (%value)
	{
		setVerticalSync(1);
	}
	else
	{
		setVerticalSync(0);
	}
}

function optionsDlg::musicToggle(%this, %value)
{
	if (%value)
	{
		if ($currentMusique $= "MusiqueMenu")
		{
			$MusiqueMenu = alxPlay("MusiqueMenu");
		}
		else if ($currentMusique $= "victoire")
		{
			alxPlay("victoire");
		}
		else if ($currentMusique $= "MusiqueIngame")
		{
			alxPlay("MusiqueIngame");
		}
	}
	else
	{
		alxStopAll();
	}
}

function initOptionSets()
{
	OptSet1Button.setText("LOW");
	OptSet2Button.setText("MEDIUM");
	OptSet3Button.setText("HIGH");
	if ($pref::Frogames::optionsSet == 1)
	{
		OptSet1Button.setText("->LOW<-");
	}
	else if ($pref::Frogames::optionsSet == 2)
	{
		OptSet2Button.setText("->MEDIUM<-");
	}
	else if ($pref::Frogames::optionsSet == 3)
	{
		OptSet3Button.setText("->HIGH<-");
	}
}

