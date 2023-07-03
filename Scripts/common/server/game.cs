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

function GameConnection::onClientEnterGame(%unused_var_0)
{
}

function GameConnection::onClientLeaveGame(%unused_var_0)
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

