$reporting_server = $frogames_gpmwebserver;
$reporting_script = "/tools/reporting.php";
$reporting_project = $frogames_project;
$reporting_hash_id = $frogames_hash_id;
$reporting_current_version = $frogames_current_version;
function beta_test_report()
{
	if ($pref::Video::fullScreen)
	{
		toggleFullScreen();
		%tempo = 1500;
	}
	%query = "id_project=" @ $reporting_project @ "&hash_id=" @ $reporting_hash_id @ "&v=" @ $reporting_current_version;
	schedule(1000 + %tempo, 0, "gotoWebpage", $reporting_server @ $reporting_script @ "?" @ %query);
}

