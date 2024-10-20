function array_echo(%array)
{
	echo("-- array_echo --");
	for (%i = 0; %i < %array.count; %i++)
	{
		echo("array_echo" SPC %array[%i]);
	}
}

function array_tozero(%array)
{
	for (%i = 0; %i < %array.count; %i++)
	{
		%array[%i] = 0;
	}
}

function array_shift(%array)
{
	for (%i = 0; %i < %array.count - 1; %i++)
	{
		%array[%i] = %array[%i + 1];
	}
	%array[%array.count - 1] = 0;
	return %array;
}

