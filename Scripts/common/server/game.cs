function onServerCreated()
{
	$Server::GameType = "Test App";
	$Server::MissionType = "Deathmatch";
	createGame();
}

function onServerDestroyed()
{
	destroyGame();
}

function onMissionLoaded()
{
	startGame();
}

function onMissionEnded()
{
	endGame();
}

function onMissionReset()
{
}

function GameConnection::onClientEnterGame(%__unused)
{
}

function GameConnection::onClientLeaveGame(%__unused)
{
}

function createGame()
{
}

function destroyGame()
{
}

function startGame()
{
}

function endGame()
{
}

