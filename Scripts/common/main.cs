function initCommon()
{
	setRandomSeed();
	exec("./client/canvas.cs");
	exec("./client/audio.cs");
}

function initBaseClient()
{
	exec("./client/message.cs");
	exec("./client/mission.cs");
	exec("./client/missionDownload.cs");
	exec("./client/actionMap.cs");
}

function initBaseServer()
{
	exec("./server/audio.cs");
	exec("./server/server.cs");
	exec("./server/message.cs");
	exec("./server/commands.cs");
	exec("./server/missionInfo.cs");
	exec("./server/missionLoad.cs");
	exec("./server/missionDownload.cs");
	exec("./server/clientConnection.cs");
	exec("./server/kickban.cs");
	exec("./server/game.cs");
}

package common
{
	function displayHelp()
	{
		Parent::displayHelp();
		error("Common Mod options:\n" @ "  -fullscreen            Starts game in full screen mode\n" @ "  -windowed              Starts game in windowed mode\n" @ "  -autoVideo             Auto detect video, but prefers OpenGL\n" @ "  -openGL                Force OpenGL acceleration\n" @ "  -directX               Force DirectX acceleration\n" @ "  -voodoo2               Force Voodoo2 acceleration\n" @ "  -noSound               Starts game without sound\n" @ "  -prefs <configFile>    Exec the config file\n");
	}

	function parseArgs()
	{
		Parent::parseArgs();
		for (%i = 1; %i < $Game::argc; %i++)
		{
			%arg = $Game::argv[%i];
			%nextArg = $Game::argv[%i + 1];
			%hasNextArg = $Game::argc - %i > 1;
			if (%arg $= "-fullscreen")
			{
				$pref::Video::fullScreen = 1;
				$argUsed[%i]++;
			}
			else if (%arg $= "-windowed")
			{
				$pref::Video::fullScreen = 0;
				$argUsed[%i]++;
			}
			else if (%arg $= "-noSound")
			{
				error("no support yet");
				$argUsed[%i]++;
			}
			else if (%arg $= "-openGL")
			{
				$pref::Video::displayDevice = "OpenGL";
				$argUsed[%i]++;
			}
			else if (%arg $= "-directX")
			{
				$pref::Video::displayDevice = "D3D";
				$argUsed[%i]++;
			}
			else if (%arg $= "-voodoo2")
			{
				$pref::Video::displayDevice = "Voodoo2";
				$argUsed[%i]++;
			}
			else if (%arg $= "-autoVideo")
			{
				$pref::Video::displayDevice = "";
				$argUsed[%i]++;
			}
			else if (%arg $= "-prefs")
			{
				$argUsed[%i]++;
				if (%hasNextArg)
				{
					exec(%nextArg, 1, 1);
					$argUsed[%i + 1]++;
					%i++;
					continue;
				}
				error("Error: Missing Command Line argument. Usage: -prefs <path/script.cs>");
			}
		}
	}

	function onStart()
	{
		Parent::onStart();
		echo("\n--------- Initializing MOD: Common ---------");
		initCommon();
	}

	function onExit()
	{
		echo("Exporting client prefs");
		export("$pref::*", "./client/prefs.cs", False);
		echo("Exporting server prefs");
		export("$Pref::Server::*", "./server/prefs.cs", False);
		BanList::export("./server/banlist.cs");
		OpenALShutdown();
		Parent::onExit();
	}

};
activatePackage(common);
function onNeedRelight()
{
}

function generateRandomChunkery(%parent)
{
	$chunkTestLevel--;
	%count = getRandom(100);
	for (%i = 0; %i < %count; %i++)
	{
		$chunkCreateCount++;
		%obj = new TextChunk()
		{
			textData = "level= " @ $chunkTestLevel @ ", idx = " @ %i @ $buff;
		};
		if ($chunkTestLevel > 0)
		{
			generateRandomChunkery(%obj);
		}
		%parent.add(%obj);
		if ($chunkCreateCount > $chunkMaxCount)
		{
			break;
		}
	}
	$chunkTestLevel++;
}

function generateBigChunkTest(%buffSize, %chunkCount)
{
	$chunkStartTime = getRealTime();
	$chunkTestLevel = 10;
	$chunkCreateCount = 0;
	$chunkMaxCount = %chunkCount;
	$a = getRealTime();
	for ($buff = ""; strlen($buff) < %buffSize; $buff = $buff @ "klmadskldasjkadlkjsakjlsdjksldakjlkjdlaakjlsdkljaslkjslkjdaslkjd")
	{
	}
	$b = getRealTime();
	$root = new TextChunk()
	{
		textData = "ROOT";
	};
	$c = getRealTime();
	generateRandomChunkery($root);
	$d = getRealTime();
	echo("Created " @ $chunkCreateCount @ " chunks in " @ $chunkTestLevel @ " levels.");
	%file = "common/bigchunktest.chunk";
	echo("Saving to '" @ %file @ "'...");
	$e = getRealTime();
	saveChunkFile($root, %file);
	$f = getRealTime();
	echo("Done.");
	echo("Deleting object hierarchy...");
	$root.delete();
	echo("Done.");
	echo("Loading object hierarchy from '" @ %file @ "'...");
	$g = getRealTime();
	$newRoot = loadChunkFile(%file);
	$h = getRealTime();
	echo("Done.");
	echo("chunkCount = " @ $chunkCreateCount @ ", chunkSize=" @ %buffSize);
	echo("Generated data = " @ $chunkCreateCount * %buffSize);
	echo("Elapsed time = " @ (getRealTime() - $chunkStartTime) / 1000 @ " sec.");
	echo("Buffer init  = " @ ($b - $a) / 1000 @ " sec.");
	echo("chunk gen    = " @ ($d - $c) / 1000 @ " sec.");
	echo("save time    = " @ ($f - $e) / 1000 @ " sec.");
	echo("load time    = " @ ($h - $g) / 1000 @ " sec.");
	return $newRoot;
}

function testchunk()
{
	%foo = new TextChunk()
	{
		textData = "pony";

		new TextChunk()
		{
			textData = "child1";

			new TextChunk()
			{
				textData = "childQ";
			};
		};
		new TextChunk()
		{
			textData = "child2";
		};
		new TextChunk()
		{
			textData = "child3";

			new TextChunk()
			{
				textData = "childA";
			};
			new TextChunk()
			{
				textData = "childB";
			};
			new TextChunk()
			{
				textData = "childC";
			};
			new TextChunk()
			{
				textData = "childD";
			};
			new TextChunk()
			{
				textData = "childE";
			};
		};
	};
	saveChunkFile(%foo, "starter.fps/test.chunk");
	%foo.delete();
	$foo = loadChunkFile("starter.fps/test.chunk");
}

