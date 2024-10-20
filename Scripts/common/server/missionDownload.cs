function GameConnection::loadMission(%this)
{
	%this.currentPhase = 0;
	if (%this.isAIControlled())
	{
		%this.onClientEnterGame();
	}
	else
	{
		commandToClient(%this, 'MissionStartPhase1', $missionSequence, $Server::MissionFile, MissionGroup.musicTrack);
		echo("*** Sending mission load to client: " @ $Server::MissionFile);
	}
}

function serverCmdMissionStartPhase1Ack(%client, %seq)
{
	if (%seq != $missionSequence || !$missionRunning)
	{
		return;
	}
	if (%client.currentPhase != 0)
	{
		return;
	}
	%client.currentPhase = 1;
	%client.setMissionCRC($missionCRC);
	%client.transmitDataBlocks($missionSequence);
}

function GameConnection::onDataBlocksDone(%this, %missionSequence)
{
	if (%missionSequence != $missionSequence)
	{
		return;
	}
	if (%this.currentPhase != 1)
	{
		return;
	}
	%this.currentPhase = 1.5;
	commandToClient(%this, 'MissionStartPhase2', $missionSequence, $Server::MissionFile);
}

function serverCmdMissionStartPhase2Ack(%client, %seq)
{
	if (%seq != $missionSequence || !$missionRunning)
	{
		return;
	}
	if (%client.currentPhase != 1.5)
	{
		return;
	}
	%client.currentPhase = 2;
	%client.transmitPaths();
	%client.activateGhosting();
}

function GameConnection::clientWantsGhostAlwaysRetry(%client)
{
	if ($missionRunning)
	{
		%client.activateGhosting();
	}
}

function GameConnection::onGhostAlwaysFailed(%client)
{
}

function GameConnection::onGhostAlwaysObjectsReceived(%client)
{
	commandToClient(%client, 'MissionStartPhase3', $missionSequence, $Server::MissionFile);
}

function serverCmdMissionStartPhase3Ack(%client, %seq)
{
	if (%seq != $missionSequence || !$missionRunning)
	{
		return;
	}
	if (%client.currentPhase != 2)
	{
		return;
	}
	%client.currentPhase = 3;
	%client.startMission();
	%client.onClientEnterGame();
}

