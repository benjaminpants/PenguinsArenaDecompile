function SAD(%password)
{
	if (%password !$= "")
	{
		commandToServer('SAD', %password);
	}
}

function SADSetPassword(%password)
{
	commandToServer('SADSetPassword', %password);
}

function clientCmdSyncClock(%__unused)
{
}

