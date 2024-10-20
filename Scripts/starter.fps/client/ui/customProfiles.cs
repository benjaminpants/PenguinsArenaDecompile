new GuiControlProfile(GuiDefaultProfile)
{
	tab = 0;
	canKeyFocus = 0;
	hasBitmapArray = 0;
	mouseOverSelected = 0;
	opaque = 0;
	fillColor = "5 78 66";
	fillColorHL = "11 94 80";
	fillColorNA = "11 94 80";
	border = 0;
	borderColor = "0 0 0";
	borderColorHL = "179 134 94";
	borderColorNA = "126 79 37";
	bevelColorHL = "255 255 255";
	bevelColorLL = "0 0 0";
	fontType = $font1;
	fontSize = 18;
	fontCharset = CHINESEBIG5;
	fontColor = "104 134 129";
	fontColorHL = "200 200 200";
	fontColorNA = "104 134 129";
	fontColorSEL = "5 39 33";
	bitmap = "./demoWindow";
	bitmapBase = "";
	textOffset = "0 0";
	Modal = 1;
	justify = "left";
	autoSizeWidth = 0;
	autoSizeHeight = 0;
	returnTab = 0;
	numbersOnly = 0;
	cursorColor = "0 0 0 255";
	soundButtonDown = "";
	soundButtonOver = "";
};
new GuiControlProfile(GuiWindowProfile)
{
	fontType = $font1;
	opaque = 1;
	border = 5;
	fillColor = "1 74 63 235";
	fillColorHL = "0 255 0 255";
	fillColorNA = "0 0 255 255";
	fontColor = "0 0 0";
	fontColorHL = "255 255 0";
	text = "GuiWindowCtrl test";
	bitmap = "./demoWindow";
	textOffset = "6 6";
	hasBitmapArray = 1;
	justify = "center";
};
new GuiControlProfile(GuiWindowProfile2)
{
	fontType = $font1;
	opaque = 1;
	border = 5;
	fillColor = "167 0 0 200";
	fillColorHL = "0 255 0 255";
	fillColorNA = "0 0 255 255";
	fontColor = "0 0 0";
	fontColorHL = "255 255 0";
	text = "GuiWindowCtrl test";
	bitmap = "./demoWindow";
	textOffset = "6 6";
	hasBitmapArray = 1;
	justify = "center";
};
new GuiControlProfile(GuiScrollProfile)
{
	fontType = $font1;
	opaque = 1;
	fillColor = "255 255 255 150";
	border = 3;
	borderThickness = 2;
	borderColor = "0 0 0";
	bitmap = "./demoScroll";
	hasBitmapArray = 1;
};
new GuiControlProfile(GuiCheckBoxProfile)
{
	fontType = $font1;
	opaque = 0;
	fillColor = "232 232 232";
	border = 0;
	borderColor = "0 0 0";
	fontSize = 18;
	fontColor = "104 134 129";
	fontColorHL = "32 100 100";
	fixedExtent = 1;
	justify = "left";
	bitmap = "./demoCheck";
	hasBitmapArray = 1;
};
new GuiControlProfile(GuiRadioProfile)
{
	fontType = $font1;
	fontSize = 18;
	fillColor = "232 232 232";
	fontColorHL = "32 100 100";
	fixedExtent = 1;
	bitmap = "./demoRadio";
	hasBitmapArray = 1;
};
