function OpenALInit()
{
	OpenALShutdownDriver();
	echo("");
	echo("OpenAL Driver Init:");
	echo($pref::Audio::driver);
	if ($pref::Audio::driver $= "OpenAL")
	{
		if (!OpenALInitDriver())
		{
			error("   Failed to initialize driver.");
			$Audio::initFailed = 1;
		}
		else
		{
			echo("   Vendor: " @ alGetString("AL_VENDOR"));
			echo("   Version: " @ alGetString("AL_VERSION"));
			echo("   Renderer: " @ alGetString("AL_RENDERER"));
			echo("   Extensions: " @ alGetString("AL_EXTENSIONS"));
			alxListenerf(AL_GAIN_LINEAR, $pref::Audio::masterVolume);
			for (%channel = 1; %channel <= 8; %channel++)
			{
				alxSetChannelVolume(%channel, $pref::Audio::channelVolume[%channel]);
			}
			echo("");
		}
	}
}

function OpenALShutdown()
{
	OpenALShutdownDriver();
}

