function StaticShapeData::Create(%data)
{
	%obj = new StaticShape()
	{
		dataBlock = %data;
	};
	return %obj;
}

