$RSSFeed::serverName = "feeds.feedburner.com";
$RSSFeed::serverPort = 80;
$RSSFeed::serverURL = "/FrogamesNewsIngame";
$RSSFeed::userAgent = "Torque/FPS" SPC $platform;
function RSSFeedObject::onConnected(%this)
{
	echo("RSS Feed");
	echo("   - Requesting RSS data at URL: " @ $RSSFeed::serverURL);
	$RSSFeed::lineCount = 0;
	$RSSFeed::requestResults = "";
	%this.send("GET " @ $RSSFeed::serverURL @ " HTTP/1.0\nHost: " @ $RSSFeed::serverName @ "\nUser-Agent: " @ $RSSFeed::userAgent @ "\n\r\n\r\n");
}

function RSSFeedObject::onLine(%this, %line)
{
	$RSSFeed::lineCount++;
	$RSSFeed::requestResults = $RSSFeed::requestResults @ %line;
}

function RSSFeedObject::getTagContents(%this, %string, %tag, %startChar)
{
	%startTag = "<" @ %tag @ ">";
	%endTag = "</" @ %tag @ ">";
	%startTagOffset = strpos(%string, %startTag, %startChar);
	%startOffset = %startTagOffset + strlen(%startTag);
	%endTagOffset = strpos(%string, %endTag, %startOffset - 1);
	if (%endTagOffset < 0)
	{
		return "";
	}
	%this.lastOffset = %endTagOffset;
	%result = getSubStr(%string, %startOffset, %endTagOffset - %startOffset);
	%result = strreplace(%result, "<![CDATA[", "");
	%result = strreplace(%result, "]]>", "");
	%result = strreplace(%result, "&quot;", "\"");
	%result = strreplace(%result, "&#8217;", "'");
	%result = strreplace(%result, "&#8220;", "'");
	%result = strreplace(%result, "&#8221;", "'");
	%result = strreplace(%result, "&#160;", " ");
	%result = strreplace(%result, "&amp;", "&");
	%result = strreplace(%result, "&nbsp;", " ");
	%result = strreplace(%result, "\r", " \n");
	%result = strreplace(%result, "\n", " \n");
	%result = strreplace(%result, "&lt;br /&gt;", " \n");
	%result = strreplace(%result, "&lt;p&gt;", "");
	%result = strreplace(%result, "&lt;/p&gt;", " ");
	%result = strreplace(%result, "&lt;a href=\"http://", "<a:");
	%result = strreplace(%result, "\" hreflang=\"fr\"&gt;", ">");
	%result = strreplace(%result, "\" hreflang=\"en\"&gt;", ">");
	%result = strreplace(%result, "&lt;/a&gt;", "</a>");
	%result = strreplace(%result, "&lt;strong&gt;", "<font:" @ $font3 @ ":14>");
	%result = strreplace(%result, "&lt;/strong&gt;", "<font:" @ $font3 @ ":14>");
	%result = trim(%result);
	return %result;
}

function RSSFeedObject::onDisconnect(%this)
{
	echo("   - Got " @ $RSSFeed::lineCount @ " lines.");
	%title = %this.getTagContents($RSSFeed::requestResults, "title", 0);
	%titleLink = %this.getTagContents($RSSFeed::requestResults, "link", 0);
	echo("   - Feed title: '" @ %title @ "'");
	echo("   - Feed link:  '" @ %titleLink @ "'");
	for (%i = 0; %i < 3; %i++)
	{
		%headline[%i] = %this.getTagContents($RSSFeed::requestResults, "title", %this.lastOffset);
		%headlineLink[%i] = %this.getTagContents($RSSFeed::requestResults, "link", %this.lastOffset);
		%description[%i] = %this.getTagContents($RSSFeed::requestResults, "description", %this.lastOffset);
		echo("   - Headline      #" @ %i @ " : '" @ %headline[%i] @ "'");
		echo("   - Headline Link #" @ %i @ " : '" @ %headlineLink[%i] @ "'");
		echo("   - Description #" @ %i @ " : '" @ %description[%i] @ "'");
	}
	RSSFeedMLText.setText("<lmargin%:2><rmargin%:98><font:" @ $font3 @ ":14>");
	for (%i = 0; %i < 3; %i++)
	{
		if (getSubStr(%headline[%i], 0, 1) !$= ".")
		{
			RSSFeedMLText.addText("<a:" @ getSubStr(%headlineLink[%i], 7, 1000) @ ">" @ %headline[%i] @ "</a>\n", 0);
			if (strlen(%description[%i]) > 300)
			{
				RSSFeedMLText.addText("" @ getSubStr(%description[%i], 0, 200) @ " <a:" @ getSubStr(%headlineLink[%i], 7, 1000) @ ">(...)</a>\n\n", 0);
				continue;
			}
			RSSFeedMLText.addText("" @ %description[%i] @ "\n\n", 0);
		}
	}
	RSSFeedMLText.addText("<just:right><a:" @ getSubStr(%titleLink, 7, 1000) @ ">" @ "[ Read more... ]" @ "</a>", 1);
}

