datablock AudioDescription(AudioLoud3d)
{
	volume = 1;
	isLooping = 0;
	is3D = 1;
	ReferenceDistance = 40;
	maxDistance = 200;
	type = $SimAudioType;
};
datablock AudioDescription(AudioDefault3d)
{
	volume = 1;
	isLooping = 0;
	is3D = 1;
	ReferenceDistance = 20;
	maxDistance = 100;
	type = $SimAudioType;
};
datablock AudioDescription(AudioClose3d)
{
	volume = 1;
	isLooping = 0;
	is3D = 1;
	ReferenceDistance = 10;
	maxDistance = 60;
	type = $SimAudioType;
};
datablock AudioDescription(AudioClosest3d)
{
	volume = 1;
	isLooping = 0;
	is3D = 1;
	ReferenceDistance = 5;
	maxDistance = 30;
	type = $SimAudioType;
};
datablock AudioDescription(AudioDefaultLooping3d)
{
	volume = 1;
	isLooping = 1;
	is3D = 1;
	ReferenceDistance = 20;
	maxDistance = 100;
	type = $SimAudioType;
};
datablock AudioDescription(AudioCloseLooping3d)
{
	volume = 1;
	isLooping = 1;
	is3D = 1;
	ReferenceDistance = 10;
	maxDistance = 50;
	type = $SimAudioType;
};
datablock AudioDescription(AudioClosestLooping3d)
{
	volume = 1;
	isLooping = 1;
	is3D = 1;
	ReferenceDistance = 5;
	maxDistance = 30;
	type = $SimAudioType;
};
datablock AudioDescription(Audio2D)
{
	volume = 1;
	isLooping = 0;
	is3D = 0;
	type = $SimAudioType;
};
datablock AudioDescription(AudioLooping2D)
{
	volume = 1;
	isLooping = 1;
	is3D = 0;
	type = $SimAudioType;
};
datablock AudioProfile(takeme)
{
	fileName = "~/data/sound/takeme.wav";
	description = "AudioDefaultLooping3d";
	preload = 0;
};
