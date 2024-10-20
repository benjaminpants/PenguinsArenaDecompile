function clearLoadInfo()
{
	if (isObject(MissionInfo))
	{
		MissionInfo.delete();
	}
}

function buildLoadInfo(%mission)
{
	clearLoadInfo();
	%infoObject = "";
	%file = new FileObject();
	if (%file.openForRead(%mission))
	{
		%inInfoBlock = 0;
		while (!%file.isEOF())
		{
			%line = %file.readLine();
			%line = trim(%line);
			if (%line $= "new ScriptObject(MissionInfo) {")
			{
				%inInfoBlock = 1;
			}
			else if (%inInfoBlock && %line $= "};")
			{
				%inInfoBlock = 0;
				%infoObject = %infoObject @ %line;
				break;
			}
			if (%inInfoBlock)
			{
				%infoObject = %infoObject @ %line @ " ";
			}
		}
		%file.close();
	}
	eval(%infoObject);
	%file.delete();
}

function dumpLoadInfo()
{
	echo("Mission Name: " @ MissionInfo.name);
	echo("Mission Description:");
	for (%i = 0; MissionInfo.desc[%i] !$= ""; %i++)
	{
		echo("   " @ MissionInfo.desc[%i]);
	}
}

function sendLoadInfoToClient(%client)
{
	messageClient(%client, 'MsgLoadInfo', "", MissionInfo.name);
	for (%i = 0; MissionInfo.desc[%i] !$= ""; %i++)
	{
		messageClient(%client, 'MsgLoadDescripition', "", MissionInfo.desc[%i]);
	}
	messageClient(%client, 'MsgLoadInfoDone');
}

