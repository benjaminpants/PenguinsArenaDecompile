$Gui::fontCacheDirectory = expandFilename("./cache");
$Gui::clipboardFile = expandFilename("./cache/clipboard.gui");
if (!isObject(GuiDefaultProfile))
{
	new GuiControlProfile(GuiDefaultProfile)
	{
		tab = 0;
		canKeyFocus = 0;
		hasBitmapArray = 0;
		mouseOverSelected = 0;
		opaque = 0;
		fillColor = $platform $= "macos" ? "211 211 211" : "192 192 192";
		fillColorHL = $platform $= "macos" ? "244 244 244" : "220 220 220";
		fillColorNA = $platform $= "macos" ? "244 244 244" : "220 220 220";
		border = 0;
		borderColor = "0 0 0";
		borderColorHL = "128 128 128";
		borderColorNA = "64 64 64";
		bevelColorHL = "255 255 255";
		bevelColorLL = "0 0 0";
		fontType = $font1;
		fontSize = 18;
		fontCharset = CHINESEBIG5;
		fontColor = "104 134 129";
		fontColorHL = "143 199 90";
		fontColorNA = "0 0 0";
		bitmap = $platform $= "macos" ? "./osxWindow" : "./darkWindow";
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
}
if (!isObject(GuiInputCtrlProfile))
{
	new GuiControlProfile(GuiInputCtrlProfile)
	{
		tab = 1;
		canKeyFocus = 1;
	};
}
if (!isObject(GuiDialogProfile))
{
	new GuiControlProfile(GuiDialogProfile);
}
if (!isObject(GuiSolidDefaultProfile))
{
	new GuiControlProfile(GuiSolidDefaultProfile)
	{
		opaque = 1;
		border = 1;
	};
}
if (!isObject(GuiWindowProfile))
{
	new GuiControlProfile(GuiWindowProfile)
	{
		opaque = 1;
		border = 2;
		fillColor = $platform $= "macos" ? "211 211 211" : "192 192 192";
		fillColorHL = $platform $= "macos" ? "190 255 255" : "64 150 150";
		fillColorNA = $platform $= "macos" ? "255 255 255" : "150 150 150";
		fontColor = $platform $= "macos" ? "0 0 0" : "255 255 255";
		fontColorHL = $platform $= "macos" ? "200 200 200" : "0 0 0";
		text = "GuiWindowCtrl test";
		bitmap = $platform $= "macos" ? "./osxWindow" : "./darkWindow";
		textOffset = $platform $= "macos" ? "5 5" : "6 6";
		hasBitmapArray = 1;
		justify = $platform $= "macos" ? "center" : "left";
	};
}
if (!isObject(GuiToolWindowProfile))
{
	new GuiControlProfile(GuiToolWindowProfile)
	{
		opaque = 1;
		border = 2;
		fillColor = "192 192 192";
		fillColorHL = "64 150 150";
		fillColorNA = "150 150 150";
		fontColor = "255 255 255";
		fontColorHL = "0 0 0";
		bitmap = "./torqueToolWindow";
		textOffset = "6 6";
	};
}
if (!isObject(GuiTabBookProfile))
{
	new GuiControlProfile(GuiTabBookProfile)
	{
		fillColor = "255 255 255";
		fillColorHL = "64 150 150";
		fillColorNA = "150 150 150";
		justify = "center";
		bitmap = "./darkTab";
		tabWidth = 64;
		TabHeight = 24;
		TabPosition = "Top";
		tabRotation = "Horizontal";
		tab = 1;
		canKeyFocus = 1;
	};
}
if (!isObject(GuiTabPageProfile))
{
	new GuiControlProfile(GuiTabPageProfile)
	{
		bitmap = "./darkTabPage";
		tab = 1;
	};
}
if (!isObject(GuiContentProfile))
{
	new GuiControlProfile(GuiContentProfile)
	{
		opaque = 1;
		fillColor = "255 255 255";
	};
}
if (!isObject(GuiModelessDialogProfile))
{
	new GuiControlProfile("GuiModelessDialogProfile")
	{
		Modal = 0;
	};
}
if (!isObject(GuiButtonProfile))
{
	new GuiControlProfile(GuiButtonProfile)
	{
		opaque = 1;
		border = 1;
		fontColor = "7 165 141";
		fontColorHL = "104 134 129";
		fixedExtent = 1;
		justify = "center";
		canKeyFocus = 0;
	};
}
if (!isObject(GuiBorderButtonProfile))
{
	new GuiControlProfile(GuiBorderButtonProfile)
	{
		fontColorHL = "0 0 0";
	};
}
if (!isObject(GuiMenuBarProfile))
{
	new GuiControlProfile(GuiMenuBarProfile)
	{
		fontType = $font1;
		fontSize = 20;
		opaque = 1;
		fillColor = $platform $= "macos" ? "211 211 211" : "192 192 192";
		fillColorHL = "0 0 96";
		border = 4;
		fixedExtent = 1;
		justify = "center";
		canKeyFocus = 0;
		mouseOverSelected = 1;
		bitmap = $platform $= "macos" ? "./osxMenu" : "./torqueMenu";
		hasBitmapArray = 1;
	};
}
if (!isObject(GuiButtonSmProfile))
{
	new GuiControlProfile(GuiButtonSmProfile : GuiButtonProfile)
	{
		fontSize = 18;
	};
}
if (!isObject(GuiRadioProfile))
{
	new GuiControlProfile(GuiRadioProfile)
	{
		fontSize = 18;
		fillColor = "232 232 232";
		fontColorHL = "32 100 100";
		fixedExtent = 1;
		bitmap = $platform $= "macos" ? "./osxRadio" : "./torqueRadio";
		hasBitmapArray = 1;
	};
}
if (!isObject(GuiScrollProfile))
{
	new GuiControlProfile(GuiScrollProfile)
	{
		opaque = 1;
		fillColor = "255 255 255";
		border = 3;
		borderThickness = 2;
		borderColor = "0 0 0";
		bitmap = $platform $= "macos" ? "./osxScroll" : "./darkScroll";
		hasBitmapArray = 1;
	};
}
if (!isObject(VirtualScrollProfile))
{
	new GuiControlProfile(VirtualScrollProfile : GuiScrollProfile);
}
if (!isObject(GuiSliderProfile))
{
	new GuiControlProfile(GuiSliderProfile)
	{
		bitmap = "./darkSlider";
	};
}
if (!isObject(GuiTextProfile))
{
	new GuiControlProfile(GuiTextProfile)
	{
		fontColorLinkHL = "0 0 255";
		autoSizeWidth = 1;
		autoSizeHeight = 1;
	};
}
if (!isObject(GuiScoresTextProfile))
{
	new GuiControlProfile(GuiScoresTextProfile : GuiTextProfile)
	{
		fontColor = "0 0 0";
		fontSize = 30;
	};
}
if (!isObject(GuiScoresTextBlancProfile))
{
	new GuiControlProfile(GuiScoresTextBlancProfile : GuiTextProfile)
	{
		fontColor = "255 255 255";
		fontSize = 30;
	};
}
if (!isObject(GuiScoresTextBlancGrosProfile))
{
	new GuiControlProfile(GuiScoresTextBlancGrosProfile : GuiTextProfile)
	{
		fontColor = "255 255 255";
		fontSize = 50;
	};
}
if (!isObject(GuiScoresTextNameProfile))
{
	new GuiControlProfile(GuiScoresTextNameProfile : GuiTextProfile)
	{
		fontColor = "255 255 255";
		fontSize = 40;
	};
}
if (!isObject(GuiScoresTextSurnameProfile))
{
	new GuiControlProfile(GuiScoresTextSurnameProfile : GuiTextProfile)
	{
		fontColor = "180 180 180";
		fontSize = 17;
	};
}
if (!isObject(GuiMessagesTextProfile))
{
	new GuiControlProfile(GuiMessagesTextProfile : GuiTextProfile)
	{
		fontColor = "52 135 125 200";
		fontSize = 50;
		opaque = 0;
	};
}
if (!isObject(GuiPetitMessagesTextProfile))
{
	new GuiControlProfile(GuiPetitMessagesTextProfile : GuiTextProfile)
	{
		fontColor = "52 135 125 200";
		fontSize = 30;
		opaque = 0;
	};
}
if (!isObject(GuiMessagesTextProfileBleu))
{
	new GuiControlProfile(GuiMessagesTextProfileBleu : GuiTextProfile)
	{
		fontColor = "45 145 188 200";
		fontSize = 50;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileBleu100))
{
	new GuiControlProfile(GuiChatTextProfileBleu100 : GuiTextProfile)
	{
		fontColor = "45 145 188 200";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileBleu75))
{
	new GuiControlProfile(GuiChatTextProfileBleu75 : GuiTextProfile)
	{
		fontColor = "45 145 188 150";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileBleu50))
{
	new GuiControlProfile(GuiChatTextProfileBleu50 : GuiTextProfile)
	{
		fontColor = "45 145 188 100";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileBleu25))
{
	new GuiControlProfile(GuiChatTextProfileBleu25 : GuiTextProfile)
	{
		fontColor = "45 145 188 50";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiMessagesTextProfileJaune))
{
	new GuiControlProfile(GuiMessagesTextProfileJaune : GuiTextProfile)
	{
		fontColor = "165 105 0 200";
		fontSize = 50;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileJaune100))
{
	new GuiControlProfile(GuiChatTextProfileJaune100 : GuiTextProfile)
	{
		fontColor = "165 105 0 200";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileJaune75))
{
	new GuiControlProfile(GuiChatTextProfileJaune75 : GuiTextProfile)
	{
		fontColor = "165 105 0 150";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileJaune50))
{
	new GuiControlProfile(GuiChatTextProfileJaune50 : GuiTextProfile)
	{
		fontColor = "165 105 0 100";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileJaune25))
{
	new GuiControlProfile(GuiChatTextProfileJaune25 : GuiTextProfile)
	{
		fontColor = "165 105 0 50";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiMessagesTextProfileVert))
{
	new GuiControlProfile(GuiMessagesTextProfileVert : GuiTextProfile)
	{
		fontColor = "57 136 38 200";
		fontSize = 50;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileVert100))
{
	new GuiControlProfile(GuiChatTextProfileVert100 : GuiTextProfile)
	{
		fontColor = "57 136 38 200";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileVert75))
{
	new GuiControlProfile(GuiChatTextProfileVert75 : GuiTextProfile)
	{
		fontColor = "57 136 38 150";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileVert50))
{
	new GuiControlProfile(GuiChatTextProfileVert50 : GuiTextProfile)
	{
		fontColor = "57 136 38 100";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileVert25))
{
	new GuiControlProfile(GuiChatTextProfileVert25 : GuiTextProfile)
	{
		fontColor = "57 136 38 50";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiMessagesTextProfileRouge))
{
	new GuiControlProfile(GuiMessagesTextProfileRouge : GuiTextProfile)
	{
		fontColor = "188 45 45 200";
		fontSize = 50;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileRouge100))
{
	new GuiControlProfile(GuiChatTextProfileRouge100 : GuiTextProfile)
	{
		fontColor = "188 45 45 200";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileRouge75))
{
	new GuiControlProfile(GuiChatTextProfileRouge75 : GuiTextProfile)
	{
		fontColor = "188 45 45 150";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileRouge50))
{
	new GuiControlProfile(GuiChatTextProfileRouge50 : GuiTextProfile)
	{
		fontColor = "188 45 45 100";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiChatTextProfileRouge25))
{
	new GuiControlProfile(GuiChatTextProfileRouge25 : GuiTextProfile)
	{
		fontColor = "188 45 45 50";
		fontSize = 22;
		opaque = 0;
	};
}
if (!isObject(GuiIntroTextProfile))
{
	new GuiControlProfile(GuiIntroTextProfile : GuiTextProfile)
	{
		fontType = $font1;
		fontColor = "255 255 255 255";
		fontSize = 25;
	};
}
if (!isObject(GuiBTTextProfilePetit))
{
	new GuiControlProfile(GuiBTTextProfilePetit : GuiTextProfile)
	{
		fontColor = "5 39 33 255";
		fontColorHL = "255 255 255 255";
		fontSize = 25;
		justify = "center";
	};
}
if (!isObject(GuiBTTextProfileGrand))
{
	new GuiControlProfile(GuiBTTextProfileGrand : GuiTextProfile)
	{
		fontColor = "5 39 33 255";
		fontColorHL = "255 255 255 255";
		fontColorNA = "0 0 0";
		fontSize = 40;
		justify = "center";
	};
}
if (!isObject(GuiNamesTextProfile))
{
	new GuiControlProfile(GuiNamesTextProfile : GuiTextProfile)
	{
		fontColor = "100 100 100";
		fontSize = 20;
		justify = "center";
		autoSizeWidth = 0;
		autoSizeHeight = 1;
	};
}
if (!isObject(GuiMediumTextProfile))
{
	new GuiControlProfile(GuiMediumTextProfile : GuiTextProfile)
	{
		fontSize = 24;
	};
}
if (!isObject(GuiBigTextProfile))
{
	new GuiControlProfile(GuiBigTextProfile : GuiTextProfile)
	{
		fontSize = 36;
	};
}
if (!isObject(GuiCenterTextProfile))
{
	new GuiControlProfile(GuiCenterTextProfile : GuiTextProfile)
	{
		justify = "center";
	};
}
if (!isObject(GuiTextEditProfile))
{
	new GuiControlProfile(GuiTextEditProfile)
	{
		opaque = 1;
		fillColor = "255 255 255";
		fillColorHL = "128 128 128";
		border = 0;
		borderThickness = 0;
		borderColor = "0 0 0";
		textOffset = "0 2";
		autoSizeWidth = 0;
		autoSizeHeight = 1;
		tab = 1;
		canKeyFocus = 1;
	};
}
if (!isObject(GuiControlListPopupProfile))
{
	new GuiControlProfile(GuiControlListPopupProfile)
	{
		opaque = 1;
		fillColor = "255 255 255";
		fillColorHL = "128 128 128";
		border = 1;
		borderColor = "0 0 0";
		textOffset = "0 2";
		autoSizeWidth = 0;
		autoSizeHeight = 1;
		tab = 1;
		canKeyFocus = 1;
		bitmap = $platform $= "macos" ? "./osxScroll" : "./darkScroll";
		hasBitmapArray = 1;
	};
}
if (!isObject(GuiTextArrayProfile))
{
	new GuiControlProfile(GuiTextArrayProfile : GuiTextProfile)
	{
		fontColorHL = "32 100 100";
		fillColorHL = "200 200 200";
	};
}
if (!isObject(GuiTextListProfile))
{
	new GuiControlProfile(GuiTextListProfile : GuiTextProfile)
	{
		tab = 1;
		canKeyFocus = 1;
	};
}
if (!isObject(GuiBaseTreeViewProfile))
{
	new GuiControlProfile(GuiBaseTreeViewProfile)
	{
		fontSize = 17;
		canKeyFocus = 1;
		autoSizeHeight = 1;
	};
}
if (!isObject(GuiChatMenuTreeProfile))
{
	new GuiControlProfile(GuiChatMenuTreeProfile : GuiBaseTreeViewProfile);
}
if (!isObject(GuiTreeViewProfile))
{
	new GuiControlProfile(GuiTreeViewProfile : GuiBaseTreeViewProfile)
	{
		fontColorSEL = "250 250 250";
		fillColorHL = "0 60 150";
		fontColorNA = "240 240 240";
		bitmap = "./shll_treeView";
	};
}
if (!isObject(GuiDirectoryTreeProfile))
{
	new GuiControlProfile(GuiDirectoryTreeProfile : GuiTreeViewProfile)
	{
		fontColor = "40 40 40";
		fontColorSEL = "250 250 250 175";
		fillColorHL = "0 60 150";
		fontColorNA = "240 240 240";
		bitmap = "./shll_treeView";
		fontType = $font1;
		fontSize = 18;
	};
}
if (!isObject(GuiDirectoryFileListProfile))
{
	new GuiControlProfile(GuiDirectoryFileListProfile)
	{
		fontColor = "40 40 40";
		fontColorSEL = "250 250 250 175";
		fillColorHL = "0 60 150";
		fontColorNA = "240 240 240";
		fontType = $font1;
		fontSize = 18;
	};
}
if (!isObject(GuiCheckBoxProfile))
{
	new GuiControlProfile(GuiCheckBoxProfile)
	{
		opaque = 0;
		fillColor = "232 232 232";
		border = 0;
		borderColor = "0 0 0";
		fontSize = 18;
		fixedExtent = 1;
		justify = "left";
		bitmap = $platform $= "macos" ? "./osxCheck" : "./torqueCheck";
		hasBitmapArray = 1;
	};
}
if (!isObject(GuiCheckBoxProfile2))
{
	new GuiControlProfile(GuiCheckBoxProfile2)
	{
		opaque = 0;
		fillColor = "255 255 255";
		border = 0;
		borderColor = "0 0 0";
		fontSize = 20;
		fixedExtent = 1;
		justify = "left";
		bitmap = $platform $= "macos" ? "./osxCheck" : "./torqueCheck";
		hasBitmapArray = 1;
	};
}
if (!isObject(GuiPopUpMenuProfile))
{
	new GuiControlProfile(GuiPopUpMenuProfile)
	{
		opaque = 1;
		mouseOverSelected = 0;
		border = 1;
		borderThickness = 1;
		borderColor = "1 139 118";
		fontSize = 20;
		fontColor = "255 255 255";
		fixedExtent = 1;
		justify = "center";
		fillColor = "1 139 118 220";
	};
}
if (!isObject(LoadTextProfile))
{
	new GuiControlProfile("LoadTextProfile")
	{
		fontColor = "66 219 234";
		autoSizeWidth = 1;
		autoSizeHeight = 1;
	};
}
if (!isObject(GuiMLTextProfile))
{
	new GuiControlProfile("GuiMLTextProfile")
	{
		fontColor = "104 134 129";
		fontColorLink = "200 200 200";
		fontColorLinkHL = "255 255 255";
		opaque = 1;
		fillColor = "255 255 255 20";
		fontType = $font1;
	};
}
if (!isObject(GuiMLMenuProfile))
{
	new GuiControlProfile(GuiMLMenuProfile : GuiMLTextProfile)
	{
		opaque = 0;
	};
}
if (!isObject(GuiMLTextProfileDEMO))
{
	new GuiControlProfile("GuiMLTextProfileDEMO")
	{
		fontColor = "0 0 0 150";
		opaque = 1;
		fillColor = "0 0 0 0";
		fontType = $font1;
		fontSize = 170;
	};
}
if (!isObject(GuiMLTextProfileDEMO2))
{
	new GuiControlProfile("GuiMLTextProfileDEMO2")
	{
		fontColor = "150 0 0 150";
		opaque = 1;
		fillColor = "255 255 255 200";
		fontType = $font1;
		fontSize = 60;
	};
}
if (!isObject(GuiMLTextProfileWarning))
{
	new GuiControlProfile("GuiMLTextProfileWarning")
	{
		fontColor = "255 0 0";
	};
}
if (!isObject(GuiMLTextProfile2))
{
	new GuiControlProfile("GuiMLTextProfile2")
	{
		fontColor = "255 255 255";
		fontColorLink = "200 255 200";
		fontColorLinkHL = "255 255 255";
		opaque = 1;
		fillColor = "0 0 0 0";
		fontType = $font1;
		fontSize = 20;
		textOffset = "10 10";
	};
}
if (!isObject(GuiMLTextProfile3))
{
	new GuiControlProfile("GuiMLTextProfile3")
	{
		fontColor = "104 134 129";
		fontColorLink = "200 200 200";
		fontColorLinkHL = "255 255 255";
		opaque = 1;
		fillColor = "0 0 0 0";
		fontType = $font2;
		fontSize = 15;
	};
}
if (!isObject(GuiMLTextProfile4))
{
	new GuiControlProfile("GuiMLTextProfile4")
	{
		fontColor = "104 134 189";
		fontColorLink = "200 200 200";
		fontColorLinkHL = "255 255 255";
		opaque = 1;
		fillColor = "0 0 0 0";
		fontType = $font3;
		fontSize = 24;
	};
}
if (!isObject(GuiMLTextNoSelectProfile))
{
	new GuiControlProfile("GuiMLTextNoSelectProfile")
	{
		fontColorLink = "255 96 96";
		fontColorLinkHL = "0 0 255";
		Modal = 0;
	};
}
if (!isObject(GuiMLTextEditProfile))
{
	new GuiControlProfile(GuiMLTextEditProfile)
	{
		fontColorLink = "255 96 96";
		fontColorLinkHL = "0 0 255";
		fillColor = "255 255 255";
		fillColorHL = "128 128 128";
		autoSizeWidth = 1;
		autoSizeHeight = 1;
		tab = 1;
		canKeyFocus = 1;
	};
}
if (!isObject(GuiToolTipProfile))
{
	new GuiControlProfile(GuiToolTipProfile)
	{
		tab = 0;
		canKeyFocus = 0;
		hasBitmapArray = 0;
		mouseOverSelected = 0;
		opaque = 1;
		fillColor = "255 255 225";
		border = 1;
		borderColor = "0 0 0";
		Modal = 1;
		justify = "left";
		autoSizeWidth = 0;
		autoSizeHeight = 0;
		returnTab = 0;
		numbersOnly = 0;
		cursorColor = "0 0 0 255";
	};
}
if (!isObject(GuiConsoleProfile))
{
	new GuiControlProfile("GuiConsoleProfile")
	{
		fontType = $platform $= "macos" ? "Monaco" : "Lucida Console";
		fontSize = $platform $= "macos" ? "13" : "12";
		fontColor = "0 0 0";
		fontColorHL = "130 130 130";
		fontColorNA = "255 0 0";
		fontColors[6] = "50 50 50";
		fontColors[7] = "50 50 0";
		fontColors[8] = "0 0 50";
		fontColors[9] = "0 50 0";
	};
}
if (!isObject(GuiProgressProfile))
{
	new GuiControlProfile("GuiProgressProfile")
	{
		opaque = 0;
		fillColor = "44 152 162 100";
		border = 1;
		borderColor = "78 88 120";
	};
}
if (!isObject(GuiProgressTextProfile))
{
	new GuiControlProfile("GuiProgressTextProfile")
	{
		justify = "center";
	};
}
if (!isObject(GuiBitmapBorderProfile))
{
	new GuiControlProfile(GuiBitmapBorderProfile)
	{
		bitmap = "./darkBorder";
		hasBitmapArray = 1;
	};
}
if (!isObject(GuiPaneProfile))
{
	new GuiControlProfile(GuiPaneProfile)
	{
		bitmap = "./torquePane";
		hasBitmapArray = 1;
	};
}
if (!isObject(GuiInspectorFieldProfile))
{
	new GuiControlProfile(GuiInspectorFieldProfile)
	{
		opaque = 0;
		fillColor = "255 255 255";
		fillColorHL = "128 128 128";
		fillColorNA = "244 244 244";
		border = 0;
		borderColor = "190 190 190";
		borderColorHL = "156 156 156";
		borderColorNA = "64 64 64";
		bevelColorHL = "255 255 255";
		bevelColorLL = "0 0 0";
		fontType = $font1;
		fontSize = 20;
		fontColor = "32 32 32";
		fontColorHL = "32 100 100";
		fontColorNA = "0 0 0";
		tab = 1;
		canKeyFocus = 1;
	};
}
if (!isObject(GuiInspectorBackgroundProfile))
{
	new GuiControlProfile(GuiInspectorBackgroundProfile : GuiInspectorFieldProfile)
	{
		border = 5;
	};
}
if (!isObject(GuiInspectorDynamicFieldProfile))
{
	new GuiControlProfile(GuiInspectorDynamicFieldProfile : GuiInspectorFieldProfile);
}
if (!isObject(GuiInspectorTextEditProfile))
{
	new GuiControlProfile("GuiInspectorTextEditProfile")
	{
		opaque = 0;
		border = 0;
		tab = 1;
		canKeyFocus = 1;
		fontType = $font1;
		fontSize = 20;
		fontColor = "32 32 32";
		fontColorHL = "32 100 100";
		fontColorNA = "0 0 0";
	};
}
if (!isObject(InspectorTypeEnumProfile))
{
	new GuiControlProfile(InspectorTypeEnumProfile : GuiInspectorFieldProfile)
	{
		mouseOverSelected = 1;
		bitmap = $platform $= "macos" ? "./osxScroll" : "./darkScroll";
		hasBitmapArray = 1;
		opaque = 1;
		border = 1;
	};
}
if (!isObject(InspectorTypeCheckboxProfile))
{
	new GuiControlProfile(InspectorTypeCheckboxProfile : GuiInspectorFieldProfile)
	{
		bitmap = $platform $= "macos" ? "./osxCheck" : "./torqueCheck";
		hasBitmapArray = 1;
		opaque = 0;
		border = 0;
	};
}
if (!isObject(GuiInspectorTypeFileNameProfile))
{
	new GuiControlProfile(GuiInspectorTypeFileNameProfile)
	{
		opaque = 0;
		border = 5;
		tab = 1;
		canKeyFocus = 1;
		fontType = $font1;
		fontSize = 20;
		justify = "center";
		fontColor = "32 32 32";
		fontColorHL = "32 100 100";
		fontColorNA = "0 0 0";
		fillColor = "255 255 255";
		fillColorHL = "128 128 128";
		fillColorNA = "244 244 244";
		borderColor = "190 190 190";
		borderColorHL = "156 156 156";
		borderColorNA = "64 64 64";
	};
}
new GuiCursor(DefaultCursor)
{
	hotSpot = "15 3";
	renderOffset = "0 0";
	bitmapName = "./FishCursor";
};
new GuiCursor(LeftRightCursor)
{
	hotSpot = "1 1";
	renderOffset = "0.5 0.1";
	bitmapName = "./CUR_leftright";
};
new GuiCursor(UpDownCursor)
{
	hotSpot = "1 1";
	renderOffset = "0.5 1";
	bitmapName = "./CUR_updown";
};
new GuiCursor(NWSECursor)
{
	hotSpot = "1 1";
	renderOffset = "0.5 0.5";
	bitmapName = "./CUR_nwse";
};
new GuiCursor(NESWCursor)
{
	hotSpot = "1 1";
	renderOffset = "0.5 0.5";
	bitmapName = "./CUR_nesw";
};
new GuiCursor(MoveCursor)
{
	hotSpot = "1 1";
	renderOffset = "0.5 0.5";
	bitmapName = "./CUR_move";
};
new GuiCursor(TextEditCursor)
{
	hotSpot = "1 1";
	renderOffset = "0.5 0.5";
	bitmapName = "./CUR_textedit";
};
