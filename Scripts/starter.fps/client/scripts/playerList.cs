addMessageCallback('MsgClientJoin', handleClientJoin);
addMessageCallback('MsgClientDrop', handleClientDrop);
addMessageCallback('MsgClientScoreChanged', handleClientScoreChanged);
function handleClientJoin(%__unused, %__unused, %clientName, %clientId, %__unused, %score, %isAI, %isAdmin, %isSuperAdmin)
{
	PlayerListGui.update(%clientId, detag(%clientName), %isSuperAdmin, %isAdmin, %isAI, %score);
}

function handleClientDrop(%__unused, %__unused, %clientName, %clientId)
{
	PlayerListGui.remove(%clientId);
}

function handleClientScoreChanged(%__unused, %__unused, %score, %clientId)
{
	PlayerListGui.updateScore(%clientId, %score);
}

