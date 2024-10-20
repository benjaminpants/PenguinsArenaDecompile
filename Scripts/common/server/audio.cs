function ServerPlay2D(%profile)
{
	for (%idx = 0; %idx < ClientGroup.getCount(); %idx++)
	{
		ClientGroup.getObject(%idx).play2D(%profile);
	}
}

function ServerPlay3D(%profile, %transform)
{
	for (%idx = 0; %idx < ClientGroup.getCount(); %idx++)
	{
		ClientGroup.getObject(%idx).play3D(%profile, %transform);
	}
}

