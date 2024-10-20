GuiButtonProfile.soundButtonOver = "AudioButtonOver";
GuiBTTextProfilePetit.soundButtonOver = "AudioButtonOver";
new GuiControlProfile(ChatHudEditProfile)
{
	opaque = 0;
	fillColor = "255 255 255";
	fillColorHL = "128 128 128";
	border = 0;
	borderThickness = 0;
	borderColor = "40 231 240";
	fontColor = "40 231 240";
	fontColorHL = "40 231 240";
	fontColorNA = "128 128 128";
	textOffset = "0 2";
	autoSizeWidth = 0;
	autoSizeHeight = 1;
	tab = 1;
	canKeyFocus = 1;
};
new GuiControlProfile(ChatHudTextProfile)
{
	opaque = 0;
	fillColor = "255 255 255";
	fillColorHL = "128 128 128";
	border = 0;
	borderThickness = 0;
	borderColor = "40 231 240";
	fontColor = "40 231 240";
	fontColorHL = "40 231 240";
	fontColorNA = "128 128 128";
	textOffset = "0 0";
	autoSizeWidth = 1;
	autoSizeHeight = 1;
	tab = 1;
	canKeyFocus = 1;
};
new GuiControlProfile("ChatHudMessageProfile")
{
	fontType = $font3;
	fontSize = 16;
	fontColor = "44 172 181";
	fontColors[1] = "45 145 188";
	fontColors[2] = "188 45 45";
	fontColors[3] = "165 105 0";
	fontColors[4] = "57 136 38";
	fontColors[5] = "200 200 50 200";
	autoSizeWidth = 1;
	autoSizeHeight = 1;
};
new GuiControlProfile("ChatHudScrollProfile")
{
	opaque = 0;
	border = 0;
	borderColor = "0 255 0";
	bitmap = "common/ui/darkScroll";
	hasBitmapArray = 1;
};
new GuiControlProfile("HudScrollProfile")
{
	opaque = 0;
	border = 1;
	borderColor = "0 255 0";
	bitmap = "common/ui/darkScroll";
	hasBitmapArray = 1;
};
new GuiControlProfile("HudTextProfile")
{
	opaque = 0;
	fillColor = "128 128 128";
	fontColor = "0 255 0";
	border = 1;
	borderColor = "0 255 0";
};
new GuiControlProfile("ChatHudBorderProfile")
{
	bitmap = "./chatHudBorderArray";
	hasBitmapArray = 1;
	opaque = 0;
};
new GuiControlProfile("CenterPrintProfile")
{
	opaque = 0;
	fillColor = "128 128 128";
	fontColor = "0 255 0";
	border = 1;
	borderColor = "0 255 0";
};
new GuiControlProfile("CenterPrintTextProfile")
{
	opaque = 0;
	fontType = $font3;
	fontSize = 12;
	fontColor = "0 255 0";
};
