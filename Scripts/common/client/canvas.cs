function initCanvas(%windowName, %effectCanvas)
{
	videoSetGammaCorrection($pref::OpenGL::gammaCorrection);
	if (%effectCanvas)
	{
		%canvasCreate = createEffectCanvas(%windowName);
	}
	else
	{
		%canvasCreate = createCanvas(%windowName);
	}
	if (!%canvasCreate)
	{
		quitWithErrorMessage("Copy of Torque is already running; exiting.");
		return;
	}
	setOpenGLTextureCompressionHint($pref::OpenGL::compressionHint);
	setOpenGLAnisotropy($pref::OpenGL::textureAnisotropy);
	setOpenGLMipReduction($pref::OpenGL::mipReduction);
	setOpenGLInteriorMipReduction($pref::OpenGL::interiorMipReduction);
	setOpenGLSkyMipReduction($pref::OpenGL::skyMipReduction);
	exec("~/ui/defaultProfiles.cs");
	exec("~/ui/ConsoleDlg.gui");
	exec("~/ui/LoadFileDlg.gui");
	exec("~/ui/ColorPickerDlg.gui");
	exec("~/ui/SaveFileDlg.gui");
	exec("~/ui/MessageBoxOkDlg.gui");
	exec("~/ui/MessageBoxYesNoDlg.gui");
	exec("~/ui/MessageBoxOKCancelDlg.gui");
	exec("~/ui/MessagePopupDlg.gui");
	exec("~/ui/HelpDlg.gui");
	exec("~/ui/RecordingsDlg.gui");
	exec("~/ui/NetGraphGui.gui");
	exec("./metrics.cs");
	exec("./messageBox.cs");
	exec("./screenshot.cs");
	exec("./cursor.cs");
	exec("./help.cs");
	exec("./recordings.cs");
	OpenALInit();
}

function resetCanvas()
{
	if (isObject(Canvas))
	{
		Canvas.repaint();
	}
}

