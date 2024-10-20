function ShapeBase::Damage(%this, %sourceObject, %position, %damage, %damageType)
{
	%this.getDataBlock().Damage(%this, %sourceObject, %position, %damage, %damageType);
}

function ShapeBase::setDamageDt(%this, %damageAmount, %damageType)
{
	if (%obj.getState() !$= "Dead")
	{
		%this.Damage(0, "0 0 0", %damageAmount, %damageType);
		%obj.damageSchedule = %obj.schedule(50, "setDamageDt", %damageAmount, %damageType);
	}
	else
	{
		%obj.damageSchedule = "";
	}
}

function ShapeBase::clearDamageDt(%this)
{
	if (%obj.damageSchedule !$= "")
	{
		cancel(%obj.damageSchedule);
		%obj.damageSchedule = "";
	}
}

function ShapeBaseData::Damage(%this, %obj, %position, %__unused, %__unused, %damageType)
{
}

