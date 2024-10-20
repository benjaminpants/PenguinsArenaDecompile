$centerPrintActive = 0;
$bottomPrintActive = 0;
$CenterPrintSizes[1] = 20;
$CenterPrintSizes[2] = 36;
$CenterPrintSizes[3] = 56;
function clientCmdCenterPrint(%message, %time, %size)
{
	if ($centerPrintActive)
	{
		if (centerPrintDlg.removePrint !$= "")
		{
			cancel(centerPrintDlg.removePrint);
		}
	}
	else
	{
		centerPrintDlg.Visible = 1;
		$centerPrintActive = 1;
	}
	CenterPrintText.setText("<just:center>" @ %message);
	centerPrintDlg.Extent = firstWord(centerPrintDlg.Extent) @ " " @ $CenterPrintSizes[%size];
	if (%time > 0)
	{
		centerPrintDlg.removePrint = schedule(%time * 1000, 0, "clientCmdClearCenterPrint");
	}
}

function clientCmdBottomPrint(%message, %time, %size)
{
	if ($bottomPrintActive)
	{
		if (bottomPrintDlg.removePrint !$= "")
		{
			cancel(bottomPrintDlg.removePrint);
		}
	}
	else
	{
		bottomPrintDlg.setVisible(1);
		$bottomPrintActive = 1;
	}
	BottomPrintText.setText("<just:center>" @ %message);
	bottomPrintDlg.Extent = firstWord(bottomPrintDlg.Extent) @ " " @ $CenterPrintSizes[%size];
	if (%time > 0)
	{
		bottomPrintDlg.removePrint = schedule(%time * 1000, 0, "clientCmdClearbottomPrint");
	}
}

function BottomPrintText::onResize(%this, %__unused, %__unused)
{
	%this.position = "0 0";
}

function CenterPrintText::onResize(%this, %__unused, %__unused)
{
	%this.position = "0 0";
}

function clientCmdClearCenterPrint()
{
	$centerPrintActive = 0;
	centerPrintDlg.Visible = 0;
	centerPrintDlg.removePrint = "";
}

function clientCmdclearBottomPrint()
{
	$bottomPrintActive = 0;
	bottomPrintDlg.Visible = 0;
	bottomPrintDlg.removePrint = "";
}

