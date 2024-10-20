$GuiAudioType = 1;
$SimAudioType = 2;
$MessageAudioType = 3;
new AudioDescription(AudioGui)
{
	volume = 1;
	isLooping = 0;
	is3D = 0;
	type = $GuiAudioType;
};
new AudioDescription(AudioGuiLooping)
{
	volume = 1;
	isLooping = 1;
	is3D = 0;
	type = $GuiAudioType;
};
new AudioDescription(AudioMessage)
{
	volume = 1;
	isLooping = 0;
	is3D = 0;
	type = $MessageAudioType;
};
new AudioProfile(AudioButtonOver)
{
	fileName = "~/data/sound/Beep.wav";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(decompte0)
{
	fileName = "~/data/sound/zero.wav";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(decompte1)
{
	fileName = "~/data/sound/one.wav";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(decompte2)
{
	fileName = "~/data/sound/two.wav";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(decompte3)
{
	fileName = "~/data/sound/three.wav";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(decompte4)
{
	fileName = "~/data/sound/four.wav";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(decompte5)
{
	fileName = "~/data/sound/five.wav";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(GongAchievement)
{
	fileName = "~/data/sound/Gong_do.wav";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(victoire)
{
	fileName = "~/data/sound/vic_beach.ogg";
	description = "AudioGuiLooping";
	preload = 1;
};
new AudioProfile(MusiqueIntro)
{
	fileName = "~/data/sound/Remembered.ogg";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(MusiqueMenu)
{
	fileName = "~/data/sound/SurfDude.ogg";
	description = "AudioGuiLooping";
	preload = 1;
};
new AudioProfile(MusiqueIngame)
{
	fileName = "~/data/sound/MadHour.ogg";
	description = "AudioGuiLooping";
	preload = 1;
};
new AudioProfile(son_invincibilite)
{
	fileName = "~/data/sound/invincible_sound.wav";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(son_bonus)
{
	fileName = "~/data/sound/bonus.wav";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(son_duel)
{
	fileName = "~/data/sound/endgame_duel.ogg";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(son_PenguinDeath)
{
	fileName = "~/data/sound/GuiPenguinDeath.wav";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(son_clientjoin)
{
	fileName = "~/data/sound/join_game.wav";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(son_clientleave)
{
	fileName = "~/data/sound/leave_game.wav";
	description = "AudioGui";
	preload = 1;
};
new AudioProfile(son_fullgameonly)
{
	fileName = "~/data/sound/FullGameOnly.wav";
	description = "AudioGui";
	preload = 1;
};
