function onMissionDownloadPhase1(%__unused, %__unused)
{
	MessageHud.close();
	LoadingProgress.setValue(0);
	LoadingProgressTxt.setValue("LOADING DATABLOCKS");
}

function onPhase1Progress(%progress)
{
	LoadingProgress.setValue(%progress);
	Canvas.repaint();
}

function onPhase1Complete()
{
}

function onMissionDownloadPhase2()
{
	LoadingProgress.setValue(0);
	LoadingProgressTxt.setValue("LOADING OBJECTS");
	Canvas.repaint();
}

function onPhase2Progress(%progress)
{
	LoadingProgress.setValue(%progress);
	Canvas.repaint();
}

function onPhase2Complete()
{
}

function onFileChunkReceived(%fileName, %ofs, %size)
{
	LoadingProgress.setValue(%ofs / %size);
	LoadingProgressTxt.setValue("Downloading " @ %fileName @ "...");
}

function onMissionDownloadPhase3()
{
	LoadingProgress.setValue(0);
	LoadingProgressTxt.setValue("LIGHTING MISSION");
	Canvas.repaint();
}

function onPhase3Progress(%progress)
{
	LoadingProgress.setValue(%progress);
}

function onPhase3Complete()
{
	LoadingProgress.setValue(1);
	$lightingMission = 0;
}

function onMissionDownloadComplete()
{
}

addMessageCallback('MsgLoadInfo', handleLoadInfoMessage);
addMessageCallback('MsgLoadDescripition', handleLoadDescriptionMessage);
addMessageCallback('MsgLoadInfoDone', handleLoadInfoDoneMessage);
function handleLoadInfoMessage(%__unused, %__unused, %mapName)
{
	if ($endgamescreenshot)
	{
		$endgamescreenshot = 0;
		echo(" ======= LoadingGuiOthers");
		exec("~/client/ui/loadingGuiOthers.gui");
		Canvas.setContent("LoadingGuiOthers");
	}
	else
	{
		echo(" ======= LoadingGui");
		exec("~/client/ui/loadingGui.gui");
		Canvas.setContent("LoadingGui");
	}
	for (%line = 0; %line < LoadingGui.qLineCount; %line++)
	{
		LoadingGui.qLine[%line] = "";
	}
	LoadingGui.qLineCount = 0;
	LOAD_MapName.setText(%mapName);
}

function handleLoadDescriptionMessage(%__unused, %__unused, %line)
{
	LoadingGui.qLine[LoadingGui.qLineCount] = %line;
	LoadingGui.qLineCount++;
	%text = "<spush><font:" @ $font3 @ ":16>";
	for (%line = 0; %line < LoadingGui.qLineCount - 1; %line++)
	{
		%text = %text @ LoadingGui.qLine[%line] @ " ";
	}
	%text = %text @ LoadingGui.qLine[%line] @ "<spop>";
	LOAD_MapDescription.setText(%text);
}

function handleLoadInfoDoneMessage(%__unused, %__unused)
{
}

