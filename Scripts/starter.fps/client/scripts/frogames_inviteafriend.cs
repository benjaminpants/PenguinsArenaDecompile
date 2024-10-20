$invite_server = $frogames_gpmserver;
$invite_script = "/tools/invite_a_friend.php";
$invite_project = $frogames_project;
$invite_hash_id = $frogames_hash_id;
function invite_a_friend(%pseudo, %email_from, %email_to)
{
	%query = "p=" @ $checkversion_project @ "\thash=" @ $checkversion_hash_id @ "\tcurrent_v=" @ $current_version @ "\tpseudo=" @ %pseudo @ "\temail_from=" @ %email_from @ "\temail_to=" @ %email_to @ "\r";
	%httpversion = new HTTPObject(InviteAFriend);
	%httpversion.get($invite_server, $invite_script, %query);
}

function InviteAFriend::onLine(%__unused, %line)
{
	if (%line $= "OK")
	{
		echo("Invite A Friend - Mail sent");
		schedule(1000, 0, "invite_a_friend_closeDialog");
		return;
	}
	if (strstr(%line, "PBC") != -1)
	{
		echo("Invite A Friend - PBC: " @ %line);
		schedule(1000, 0, "invite_a_friend_closeDialog");
		return;
	}
	error("Invite A Friend - Error:  ", %line);
	schedule(1000, 0, "invite_a_friend_closeDialog");
}

function InviteAFriend::onConnectionDied(%__unused)
{
	error("Invite A Friend - ConnectionDied");
	CheckingVersionText.setText("Connection error - can't check the version.");
	schedule(1000, 0, "invite_a_friend_closeDialog");
}

function InviteAFriend::onDNSFailed(%__unused)
{
	error("Invite A Friend - DNSFailed");
	CheckingVersionText.setText("Connection error - can't check the version.");
	schedule(1000, 0, "invite_a_friend_closeDialog");
}

function InviteAFriend::onConnectFailed(%__unused)
{
	error("Invite A Friend - ConnectFailed");
	CheckingVersionText.setText("Connection error - can't check the version.");
	schedule(1000, 0, "invite_a_friend_closeDialog");
}

function invite_a_friend_closeDialog()
{
	Canvas.popDialog(frogames_inviteafriend);
}

