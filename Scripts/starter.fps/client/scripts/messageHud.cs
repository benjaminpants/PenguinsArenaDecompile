function MessageHud::open(%this)
{
	%offset = 6;
	if (%this.isVisible())
	{
		return;
	}
	if (%this.isTeamMsg)
	{
		%text = "TEAM:";
	}
	else
	{
		%text = "CHAT:";
	}
	MessageHud_Text.setValue(%text);
	%windowPos = "0 " @ getWord(OuterChatHud.position, 1) + getWord(OuterChatHud.Extent, 1) + 1;
	%windowExt = getWord(OuterChatHud.Extent, 0) @ " " @ getWord(MessageHud_Frame.Extent, 1);
	%textExtent = getWord(MessageHud_Text.position, 0) + getWord(MessageHud_Text.Extent, 0);
	%ctrlExtent = getWord(MessageHud_Frame.Extent, 0);
	Canvas.pushDialog(%this);
	MessageHud_Edit.position = setWord(MessageHud_Edit.position, 0, %textExtent + %offset);
	MessageHud_Edit.Extent = setWord(MessageHud_Edit.Extent, 0, (%ctrlExtent - %textExtent) - 2 * %offset);
	%this.setVisible(1);
	deactivateKeyboard();
	MessageHud_Edit.makeFirstResponder(1);
}

function MessageHud::close(%this)
{
	if (!%this.isVisible())
	{
		return;
	}
	Canvas.popDialog(%this);
	%this.setVisible(0);
	if ($enableDirectInput)
	{
		activateKeyboard();
	}
	MessageHud_Edit.setValue("");
}

function MessageHud::toggleState(%this)
{
	if (%this.isVisible())
	{
		%this.close();
	}
	else if ($pref::Chat)
	{
		%this.open();
	}
}

function MessageHud_Edit::onEscape(%this)
{
	MessageHud.close();
}

function MessageHud_Edit::eval(%this)
{
	%text = trim(%this.getValue());
	if (%text !$= "")
	{
		if (MessageHud.isTeamMsg)
		{
			commandToServer('teamMessageSent', %text);
		}
		else
		{
			if ($LocalMyTeamID == 1)
			{
				%text = "\c1" @ %text;
			}
			else if ($LocalMyTeamID == 2)
			{
				%text = "\c2" @ %text;
			}
			else if ($LocalMyTeamID == 3)
			{
				%text = "\c3" @ %text;
			}
			else if ($LocalMyTeamID == 4)
			{
				%text = "\c4" @ %text;
			}
			commandToServer('messageSent', %text);
		}
	}
	MessageHud.close();
}

function toggleMessageHud(%make)
{
	if (%make)
	{
		MessageHud.isTeamMsg = 0;
		MessageHud.toggleState();
	}
}

function teamMessageHud(%make)
{
	if (%make)
	{
		MessageHud.isTeamMsg = 1;
		MessageHud.toggleState();
	}
}

