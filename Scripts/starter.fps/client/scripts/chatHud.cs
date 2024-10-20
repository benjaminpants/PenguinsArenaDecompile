$outerChatLenY[1] = 72;
$outerChatLenY[2] = 140;
$outerChatLenY[3] = 200;
$MaxMessageWavLength = 5000;
function playMessageSound(%message, %voice, %pitch)
{
	%wavStart = strstr(%message, "~w");
	if (%wavStart == -1)
	{
		return -1;
	}
	%wav = getSubStr(%message, %wavStart + 2, 1000);
	if (%voice !$= "")
	{
		%wavFile = "~/data/sound/voice/" @ %voice @ "/" @ %wav;
	}
	else
	{
		%wavFile = "~/data/sound/" @ %wav;
	}
	if (strstr(%wavFile, ".wav") != strlen(%wavFile) - 4)
	{
		%wavFile = %wavFile @ ".wav";
	}
	%wavFile = expandFilename(%wavFile);
	if (%pitch < 0.5 || %pitch > 2)
	{
		%pitch = 1;
	}
	%wavLengthMS = alxGetWaveLen(%wavFile) * %pitch;
	if (%wavLengthMS == 0)
	{
		error("** WAV file \"" @ %wavFile @ "\" is nonexistent or sound is zero-length **");
	}
	else if (%wavLengthMS <= $MaxMessageWavLength)
	{
		if ($ClientChatHandle[%sender] != 0)
		{
			alxStop($ClientChatHandle[%sender]);
		}
		$ClientChatHandle[%sender] = alxCreateSource(AudioMessage, %wavFile);
		if (%pitch != 1)
		{
			alxSourcef($ClientChatHandle[%sender], "AL_PITCH", %pitch);
		}
		alxPlay($ClientChatHandle[%sender]);
	}
	else
	{
		error("** WAV file \"" @ %wavFile @ "\" is too long **");
	}
	return %wavStart;
}

new MessageVector(HudMessageVector);
$LastHudTarget = 0;
function onChatMessage(%message, %voice, %pitch)
{
	if (%voice $= "")
	{
		%voice = "default";
	}
	if ((%wavStart = playMessageSound(%message, %voice, %pitch)) != -1)
	{
		%message = getSubStr(%message, 0, %wavStart);
	}
	if (getWordCount(%message))
	{
		ChatHud.addLine(%message);
	}
}

function onServerMessage(%message)
{
	if ((%wavStart = playMessageSound(%message)) != -1)
	{
		%message = getSubStr(%message, 0, %wavStart);
	}
	if (getWordCount(%message))
	{
		ChatHud.addLine(%message);
	}
}

function MainChatHud::onWake(%this)
{
	%this.setChatHudLength($pref::ChatHudLength);
}

function MainChatHud::setChatHudLength(%this, %length)
{
	OuterChatHud.resize(firstWord(OuterChatHud.position), getWord(OuterChatHud.position, 1), firstWord(OuterChatHud.Extent), $outerChatLenY[%length]);
	ChatScrollHud.scrollToBottom();
	chatPageDown.setVisible(0);
}

function MainChatHud::nextChatHudLen(%this)
{
	%len = $pref::ChatHudLength++;
	if ($pref::ChatHudLength == 4)
	{
		$pref::ChatHudLength = 1;
	}
	%this.setChatHudLength($pref::ChatHudLength);
}

function ChatHud::addLine(%this, %text)
{
	%textHeight = %this.Profile.fontSize;
	if (%textHeight <= 0)
	{
		%textHeight = 12;
	}
	%chatScrollHeight = getWord(%this.getGroup().getGroup().Extent, 1);
	%chatPosition = (getWord(%this.Extent, 1) - %chatScrollHeight) + getWord(%this.position, 1);
	%linesToScroll = mFloor(%chatPosition / %textHeight + 0.5);
	if (%linesToScroll > 0)
	{
		%origPosition = %this.position;
	}
	while (!chatPageDown.isVisible() && HudMessageVector.getNumLines() && HudMessageVector.getNumLines() >= $pref::HudMessageLogSize)
	{
		%tag = HudMessageVector.getLineTag(0);
		if (%tag != 0)
		{
			%tag.delete();
		}
		HudMessageVector.popFrontLine();
	}
	HudMessageVector.pushBackLine(%text, $LastHudTarget);
	$LastHudTarget = 0;
	if (%linesToScroll > 0)
	{
		chatPageDown.setVisible(1);
		%this.position = %origPosition;
	}
	else
	{
		chatPageDown.setVisible(0);
	}
}

function ChatHud::pageUp(%this)
{
	%textHeight = %this.Profile.fontSize;
	if (%textHeight <= 0)
	{
		%textHeight = 12;
	}
	%chatScrollHeight = getWord(%this.getGroup().getGroup().Extent, 1);
	if (%chatScrollHeight <= 0)
	{
		return;
	}
	%pageLines = mFloor(%chatScrollHeight / %textHeight) - 1;
	if (%pageLines <= 0)
	{
		%pageLines = 1;
	}
	%chatPosition = -1 * getWord(%this.position, 1);
	%linesToScroll = mFloor(%chatPosition / %textHeight + 0.5);
	if (%linesToScroll <= 0)
	{
		return;
	}
	if (%linesToScroll > %pageLines)
	{
		%scrollLines = %pageLines;
	}
	else
	{
		%scrollLines = %linesToScroll;
	}
	%this.position = firstWord(%this.position) SPC getWord(%this.position, 1) + %scrollLines * %textHeight;
	chatPageDown.setVisible(1);
}

function ChatHud::pageDown(%this)
{
	%textHeight = %this.Profile.fontSize;
	if (%textHeight <= 0)
	{
		%textHeight = 12;
	}
	%chatScrollHeight = getWord(%this.getGroup().getGroup().Extent, 1);
	if (%chatScrollHeight <= 0)
	{
		return;
	}
	%pageLines = mFloor(%chatScrollHeight / %textHeight) - 1;
	if (%pageLines <= 0)
	{
		%pageLines = 1;
	}
	%chatPosition = (getWord(%this.Extent, 1) - %chatScrollHeight) + getWord(%this.position, 1);
	%linesToScroll = mFloor(%chatPosition / %textHeight + 0.5);
	if (%linesToScroll <= 0)
	{
		return;
	}
	if (%linesToScroll > %pageLines)
	{
		%scrollLines = %pageLines;
	}
	else
	{
		%scrollLines = %linesToScroll;
	}
	%this.position = firstWord(%this.position) SPC getWord(%this.position, 1) - %scrollLines * %textHeight;
	if (%scrollLines < %linesToScroll)
	{
		chatPageDown.setVisible(1);
	}
	else
	{
		chatPageDown.setVisible(0);
	}
}

function pageUpMessageHud()
{
	ChatHud.pageUp();
}

function pageDownMessageHud()
{
	ChatHud.pageDown();
}

function cycleMessageHudSize()
{
	MainChatHud.nextChatHudLen();
}

