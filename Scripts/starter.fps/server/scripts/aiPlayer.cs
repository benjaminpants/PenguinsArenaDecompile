datablock PlayerData(DemoPlayer : PlayerBody)
{
	shootingDelay = 2000;
};
datablock PlayerData(DemoPlayer2 : PlayerBody2)
{
	shootingDelay = 2000;
};
datablock PlayerData(DemoPlayer3 : PlayerBody3)
{
	shootingDelay = 2000;
};
datablock PlayerData(DemoPlayer4 : PlayerBody4)
{
	shootingDelay = 2000;
};
function AIPlayer::onDeath(%this)
{
	if ($Server::MissionType $= "Duels" || $Server::MissionType $= "Unlimited")
	{
		cancel(%this.ailoop);
		if ($Team[%this.team_id].numPlayers != 0)
		{
			$Team[%this.team_id].Player[1] = AIPlayer::spawn($Team[%this.team_id].name @ "1", pickSpawnPoint($Team[%this.team_id].name, 1), %this.team_id, 1, 0);
			$Team[%this.team_id].Player[1].schedule(400, "doscan", $Team[%this.team_id].Player[1]);
			$Team[%this.team_id].Player[1].playReincarnation();
		}
		else
		{
			$Team[%this.team_id].Player[1] = 0;
		}
	}
	else
	{
		for (%i = 1; %i <= $nb_joueurs_par_team; %i++)
		{
			if ($Team[%this.team_id].Player[%i] == %this)
			{
				$Team[%this.team_id].Player[%i] = 0;
				echo("== AI death - $Team[" @ %this.team_id @ "].player[" @ %i @ "]");
			}
		}
		cancel(%this.ailoop);
	}
}

function AIPlayer::spawn(%name, %spawnPoint, %teamid, %id_in_team, %bonus_AI_level)
{
	if (%bonus_AI_level)
	{
		%AI_level_modifier = 2;
	}
	else
	{
		%AI_level_modifier = -1;
	}
	if (%teamid == 1)
	{
		%player = new AIPlayer()
		{
			dataBlock = DemoPlayer;
			Path = "";
			team_id = %teamid;
			id_in_team = %id_in_team;
			fov = $AI_PLAYER_FOV;
			AI_level_modifier = %AI_level_modifier;
		};
	}
	else if (%teamid == 2)
	{
		%player = new AIPlayer()
		{
			dataBlock = DemoPlayer2;
			Path = "";
			team_id = %teamid;
			id_in_team = %id_in_team;
			fov = $AI_PLAYER_FOV;
			AI_level_modifier = %AI_level_modifier;
		};
	}
	else if (%teamid == 3)
	{
		%player = new AIPlayer()
		{
			dataBlock = DemoPlayer3;
			Path = "";
			team_id = %teamid;
			id_in_team = %id_in_team;
			fov = $AI_PLAYER_FOV;
			AI_level_modifier = %AI_level_modifier;
		};
	}
	else if (%teamid == 4)
	{
		%player = new AIPlayer()
		{
			dataBlock = DemoPlayer4;
			Path = "";
			team_id = %teamid;
			id_in_team = %id_in_team;
			fov = $AI_PLAYER_FOV;
			AI_level_modifier = %AI_level_modifier;
		};
	}
	MissionCleanup.add(%player);
	%player.setShapeName(%name);
	%player.setTransform(%spawnPoint);
	%player.mountImage(CrossbowImage, 0);
	%player.setInventory(CrossbowAmmo, 1000);
	%player.mountImage(coup_de_poingImage, 1);
	if ($Team[%teamid].scoreLTG[10] >= 1)
	{
		%player.mountImage(CrownImage, 6);
	}
	if ($debugVisualDebug)
	{
		if (%teamid == 2)
		{
			%player.vdtTrackAIdestination();
		}
	}
	return %player;
}

function AIPlayer::movealittle(%this, %obj, %chance1, %chance2)
{
	if (%obj.ancienneDestination)
	{
		%obj.setMoveDestination(%obj.ancienneDestination);
		%obj.ancienneDestination = "";
	}
	if (getRandom(1, %chance2) <= %chance1)
	{
		%eviteDestination = "";
		%eviteDestination = %obj.evitePointsFroids();
		if (%eviteDestination != 0 && %eviteDestination != 0)
		{
			%obj.ancienneDestination = %obj.getMoveDestination();
			%obj.setMoveDestination(%eviteDestination);
		}
		else
		{
			if (%obj.monpointchaudDestination)
			{
				%obj.setMoveDestination(%obj.monpointchaudDestination);
				%nouvelleDestination = %obj.choisiPointChaud(0);
			}
			else
			{
				%nouvelleDestination = %obj.choisiPointChaud(1);
			}
			if (%nouvelleDestination)
			{
				%obj.setMoveDestination(%nouvelleDestination);
				%obj.monpointchaudDestination = %nouvelleDestination;
			}
		}
	}
	else
	{
		%obj.stop();
	}
}

function AIPlayer::getAimPoint(%this, %pos, %vel, %AttackDelay)
{
	%AimProjectileSpeed = 25;
	%AimRotErr = 0.12999999523162842;
	%posAim1 = %this.calculerAimPoint(%pos, %vel, %AimProjectileSpeed, %AttackDelay, %AimRotErr);
	return %posAim1;
}

$AI_PLAYER_FIREDELAY = 500;
$AI_PLAYER_DETECT_DISTANCE = 250;
$AI_PLAYER_IGNORE_DISTANCE = 100;
$AI_PLAYER_CC_DISTANCE = 3.5;
$AI_PLAYER_SCANTIME = 500;
$AI_PLAYER_CREATION_DELAY = 5000;
$AI_PLAYER_TRIGGER_DOWN = 150;
$AI_PLAYER_RESPAWN_DELAY = 20000;
$AI_PLAYER_MAX_ATTENTION = 10;
function AIPlayer::openfire(%this, %obj, %playerVise)
{
	if (!%obj || !%playerVise)
	{
		return;
	}
	if (%obj && %obj.getState() !$= "Move" || %playerVise && %playerVise.getState() !$= "Move")
	{
		%firing = 0;
		%obj.clearAim();
	}
	else
	{
		if ($Team[%this.team_id].Player[%this.id_in_team].client && $Team[%this.team_id].Player[%this.id_in_team].client.isAIControlled())
		{
			%ai_controlled = 1;
		}
		if (!%firing)
		{
			%rtt = VectorDist(%obj.getPosition(), %playerVise.getPosition());
			if (%rtt < $AI_PLAYER_IGNORE_DISTANCE)
			{
				if (%ai_controlled)
				{
					%posAim = %obj.getAimPoint(VectorAdd(%playerVise.getPosition(), "0 0 2.0"), %playerVise.getVelocity(), 20);
				}
				else
				{
					%posAim = %obj.getAimPoint(VectorAdd(%playerVise.getPosition(), "0 0 2.0"), %playerVise.getVelocity(), 40 - $pref::Server::AI_level);
				}
				%obj.setAimLocation(%posAim);
				if (%rtt < $AI_PLAYER_CC_DISTANCE)
				{
					if (getRandom(1, 8) <= $pref::Server::AI_level + %obj.AI_level_modifier)
					{
						%obj.setImageTrigger(1, 1);
						if (%ai_controlled)
						{
							%obj.setImageTrigger(0, 1);
						}
					}
				}
				else
				{
					%firing = 1;
					if ($debugVisualDebug)
					{
						if (%obj.team_id == 1)
						{
							vdtPoint(%posAim, 8, 3000, "0.0 0.0 1.0 1.0", 0);
						}
						else if (%obj.team_id == 2)
						{
							vdtPoint(%posAim, 8, 3000, "1.0 0.0 0.0 1.0", 0);
						}
						else if (%obj.team_id == 3)
						{
							vdtPoint(%posAim, 8, 3000, "1.0 1.0 0.0 1.0", 0);
						}
						else if (%obj.team_id == 4)
						{
							vdtPoint(%posAim, 8, 3000, "0.0 1.0 0.0 1.0", 0);
						}
					}
					if (!$debugPauseAITires)
					{
						%obj.setImageTrigger(0, 1);
					}
				}
				if (VectorDist(%playerVise.getPosition(), %obj.getPosition()) >= 30)
				{
					%obj.setMoveDestination(%playerVise.getPosition());
				}
				else
				{
					%this.movealittle(%obj, $pref::Server::AI_level + %obj.AI_level_modifier, 11);
				}
			}
			else
			{
				%obj.clearAim();
			}
		}
	}
	%this.Trigger = %this.schedule($AI_PLAYER_TRIGGER_DOWN - ($pref::Server::AI_level + %obj.AI_level_modifier) * 10, "ceasefire", %obj);
}

function AIPlayer::ceasefire(%this, %obj)
{
	%obj.setImageTrigger(0, 0);
	%obj.setImageTrigger(1, 0);
	%this.Trigger = %this.schedule($AI_PLAYER_FIREDELAY - ($pref::Server::AI_level + %obj.AI_level_modifier) * 30, "delayfire", %obj);
}

function AIPlayer::delayfire(%this, %obj)
{
	%firing = 0;
}

function AIPlayer::DoScan(%this, %obj)
{
	cancel(%this.ailoop);
	if (!%obj || %this.getControllingClient() && !%this.getControllingClient().isAIControlled())
	{
		return;
	}
	if ($Team[%this.team_id].Player[%this.id_in_team].client && $Team[%this.team_id].Player[%this.id_in_team].client.isAIControlled())
	{
		%ai_controlled = 1;
	}
	%playerid = %this.GetClosestHumanInSightandRange(%obj);
	if (%playerid && %playerid.getState() !$= "Dead")
	{
		%tgt = %playerid;
		if (%obj.getAimObject() != %tgt || %ai_controlled)
		{
			%this.openfire(%obj, %tgt);
		}
		if (%ai_controlled && getRandom(1, 4) == 1)
		{
			%this.movealittle(%obj, $pref::Server::AI_level + %obj.AI_level_modifier + 4, 11);
			%is_moving = 1;
		}
	}
	else
	{
		%obj.setImageTrigger(0, 0);
		%obj.setImageTrigger(1, 0);
		%obj.clearAim();
		%this.stop();
		%this.movealittle(%obj, $pref::Server::AI_level + %obj.AI_level_modifier + 4, 11);
	}
	if (%ai_controlled)
	{
		if (%is_moving && getRandom(1, 3) == 1)
		{
			%next_doscan_timer = getRandom(150, 1300);
		}
		else
		{
			%next_doscan_timer = getRandom(120, 260);
		}
	}
	else
	{
		%rand_factor = getRandom(100, 200);
		%next_doscan_timer = $AI_PLAYER_SCANTIME * (%rand_factor / 100) - ($pref::Server::AI_level + %obj.AI_level_modifier) * 35;
	}
	if (!$debugPauseAI)
	{
		%this.ailoop = %this.schedule(%next_doscan_timer, "DoScan", %obj);
	}
}

function AIPlayer::CheckLOS(%this, %obj, %playerVise)
{
	%eyeTrans = %obj.getEyeTransform();
	%eyeEnd = %playerVise.getEyeTransform();
	%searchResult = containerRayCast(%eyeTrans, %eyeEnd, $TypeMasks::PlayerObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType, %obj);
	%foundObject = getWord(%searchResult, 0);
	if (%foundObject.getType() & $TypeMasks::PlayerObjectType)
	{
		return 1;
	}
	else
	{
		return 0;
	}
}

function AIPlayer::GetClosestHumanInSightandRange(%this, %obj)
{
	%found_id_player = -1;
	%found_dist = $AI_PLAYER_DETECT_DISTANCE;
	%botpos = %this.getPosition();
	for (%j = 1; %j <= $nb_teams; %j++)
	{
		if (%this.team_id != %j)
		{
			%current_team = $Team[%j];
			for (%i = 1; %i <= $nb_joueurs_par_team; %i++)
			{
				%current_ai = %current_team.Player[%i];
				if (%current_ai && %current_ai != %this && %current_ai.getState() $= "Move")
				{
					%playpos = %current_ai.getPosition();
					%tempdist = VectorDist(%playpos, %botpos);
					if (%tempdist < %found_dist)
					{
						if (%this.CheckLOS(%obj, %current_ai))
						{
							%found_dist = %tempdist;
							%found_id_player = %i;
							%found_id_team = %j;
						}
					}
				}
			}
		}
	}
	if (%found_id_player > 0)
	{
		%id_player = $Team[%found_id_team].Player[%found_id_player];
	}
	return %id_player;
}

