datablock TriggerData(DefaultTrigger)
{
	tickPeriodMS = 100;
};
function DefaultTrigger::onEnterTrigger(%this, %trigger, %obj)
{
	Parent::onEnterTrigger(%this, %trigger, %obj);
}

function DefaultTrigger::onLeaveTrigger(%this, %trigger, %obj)
{
	Parent::onLeaveTrigger(%this, %trigger, %obj);
}

function DefaultTrigger::onTickTrigger(%this, %trigger)
{
	Parent::onTickTrigger(%this, %trigger);
}

datablock TriggerData(DeathTrigger)
{
	tickPeriodMS = 100;
};
function DeathTrigger::onEnterTrigger(%this, %trigger, %obj)
{
	Parent::onEnterTrigger(%this, %trigger, %obj);
	if (%obj.getType() & $TypeMasks::PlayerObjectType)
	{
		%orque = new StaticShape()
		{
			dataBlock = orque;
		};
		MissionCleanup.add(%orque);
		OrienteOrque(%orque, %obj);
		%orque.schedule(3000, "delete");
		if (%obj.teamResponsibleForDeath != 0)
		{
			if (%obj.teamResponsibleForDeath == %obj.team_id)
			{
				echo("sneaky player on team: " + %obj.team_id + " attempted suicide points!");
			}
			else
			{
				%current_team = $Team[%obj.teamResponsibleForDeath];
				%current_team.numPlayers++;
				messageAll('MsgMembersTeamChanged', "", %obj.teamResponsibleForDeath, %current_team.numPlayers, 1);
			}
		}
		/*if (%current_team.numPlayers == 0)
		{
			%controled_by_player = 0;
			%nomJoueur = "";
			if (%current_team.realPlayer >= 1)
			{
				%controled_by_player = 1;
				%nomJoueur = %current_team.client.getPlayerName();
			}
			for (%clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++)
			{
				%cl = ClientGroup.getObject(%clientIndex);
				messageClient(%cl, 'MsgUpdateTeamGUI', "", %cl.team_id, $nb_teams, %obj.team_id, %controled_by_player, 1, %nomJoueur);
			}
		}*/
		%obj.kill();
		echo("team " @ %obj.team_id);
		echo("real player " @ $Team[%obj.team_id].realPlayer);
		if ($Team[%obj.team_id].realPlayer < 1)
		{
			echo("spawning ai!");
			%aiPlayer = AIPlayer::spawn($Team[%obj.team_id].name @ "1", pickSpawnPoint($Team[%obj.team_id].name, 1), %obj.team_id, 1, 0);
			%aiPlayer.schedule(getRandom(50, 200), "doscan", %aiPlayer);
		}
		endgame_check();
	}
}

function DeathTrigger::onLeaveTrigger(%this, %trigger, %obj)
{
	Parent::onLeaveTrigger(%this, %trigger, %obj);
}

function DeathTrigger::onTickTrigger(%this, %trigger)
{
	Parent::onTickTrigger(%this, %trigger);
}

function OrienteOrque(%orque, %obj)
{
	%object_centreIceberg = nameToID("MissionGroup/points_chauds/centre");
	%position_centreIceberg = %object_centreIceberg.getTransform();
	%delta = 40;
	%temp = getWord(%position_centreIceberg, 0);
	%xp = getRandom(%temp - %delta, %temp + %delta);
	%temp = getWord(%position_centreIceberg, 1);
	%yp = getRandom(%temp - %delta, %temp + %delta);
	%p = %xp SPC %yp SPC getWord(%position_centreIceberg, 2);
	%vec = VectorNormalize(VectorSub(%p, %obj.getPosition()));
	%vecX = getWord(%vec, 0);
	%vecY = getWord(%vec, 1);
	%angleZ = mAtan(%vecX, %vecY);
	%object_water = nameToID("MissionGroup/water");
	%position_water = %object_water.getTransform();
	%scale_water = %object_water.getScale();
	%h = getWord(%position_water, 2) + getWord(%scale_water, 2);
	%orquePosition = getWord(%obj.getPosition(), 0) SPC getWord(%obj.getPosition(), 1) SPC %h;
	%orqueRotation = "0 0 1" SPC %angleZ;
	%orque.setTransform(%orquePosition SPC %orqueRotation);
	%ajustVec = -5 * %vecX SPC -5 * %vecY SPC "0";
	%ECLposition = VectorAdd(%orquePosition, %ajustVec);
	schedule(1500, 0, orqueEclaboussures, %ECLposition);
	schedule(2000, 0, DeadPenguin, %orquePosition, %orqueRotation);
}

function DeadPenguin(%pos, %rot)
{
	%deadPenguin = new StaticShape()
	{
		dataBlock = DeadPenguin;
	};
	MissionCleanup.add(%deadPenguin);
	%deadPenguin.setTransform(%pos SPC %rot);
	%deadPenguin.startFade(1500, 0, 0);
	%deadPenguin.startFade(2000, 1500, 1);
	%deadPenguin.schedule(3300, "delete");
}

