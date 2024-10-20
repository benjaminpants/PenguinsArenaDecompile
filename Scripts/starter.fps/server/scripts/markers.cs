datablock MissionMarkerData(WayPointMarker)
{
	category = "Misc";
	shapeFile = "~/data/shapes/markers/octahedron.dts";
};
datablock MissionMarkerData(SpawnSphereMarker)
{
	category = "Misc";
	shapeFile = "~/data/shapes/markers/octahedron.dts";
};
datablock MissionMarkerData(AIMarkerMarker)
{
	category = "Misc";
	shapeFile = "~/data/shapes/markers/octahedron.dts";
};
function MissionMarkerData::Create(%block)
{
	if (%block $= "WayPointMarker")
	{
		%obj = new WayPoint()
		{
			dataBlock = %block;
		};
		return %obj;
	}
	else if (%block $= "SpawnSphereMarker")
	{
		%obj = new SpawnSphere()
		{
			dataBlock = %block;
		};
		return %obj;
	}
	else if (%block $= "AIMarkerMarker")
	{
		%obj = new AIMarker()
		{
			dataBlock = %block;
		};
		return %obj;
	}
	return -1;
}

