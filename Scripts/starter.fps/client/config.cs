if (isObject(moveMap))
{
	moveMap.delete();
}
new ActionMap(moveMap);
moveMap.bindCmd(keyboard, "escape", "", "escapeFromGame();");
moveMap.bind(keyboard, "f2", showPlayerList);
moveMap.bind(keyboard, "f5", toggleParticleEditor);
moveMap.bind(keyboard, "a", moveleft);
moveMap.bind(keyboard, "d", moveright);
moveMap.bind(keyboard, "w", moveForward);
moveMap.bind(keyboard, "s", movebackward);
moveMap.bind(keyboard, "left", moveleft);
moveMap.bind(keyboard, "right", moveright);
moveMap.bind(keyboard, "down", movebackward);
moveMap.bind(keyboard, "up", moveForward);
moveMap.bind(keyboard, "space", jump);
moveMap.bind(keyboard, "numpad0", jump);
moveMap.bind(keyboard, "r", setZoomFOV);
moveMap.bind(keyboard, "tab", toggleFirstPerson);
moveMap.bind(keyboard, "alt c", toggleCamera);
moveMap.bind(keyboard, "u", toggleMessageHud);
moveMap.bind(keyboard, "pageup", pageMessageHudUp);
moveMap.bind(keyboard, "pagedown", pageMessageHudDown);
moveMap.bind(keyboard, "i", toggleIntel);
moveMap.bind(keyboard, "f3", startRecordingDemo);
moveMap.bind(keyboard, "f4", stopRecordingDemo);
moveMap.bind(keyboard, "f8", dropCameraAtPlayer);
moveMap.bind(keyboard, "f7", dropPlayerAtCamera);
moveMap.bindCmd(keyboard, "n", "NetGraph::toggleNetGraph();", "");
moveMap.bind(mouse0, "xaxis", yaw);
moveMap.bind(mouse0, "yaxis", pitch);
moveMap.bind(mouse0, "button0", mouseFire);
moveMap.bind(mouse0, "button1", altTrigger);
