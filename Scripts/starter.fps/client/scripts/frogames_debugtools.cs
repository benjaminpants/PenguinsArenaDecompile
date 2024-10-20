package GameTypeDebug
{
	function showDebug()
	{
		metrics("debug");
		if (!$showDebug::toggle)
		{
			$showDebug::toggle = 1;
			Canvas.getContent().add(panel_gestionAI);
			cursorOn();
		}
		else
		{
			$showDebug::toggle = 0;
			Canvas.getContent().remove(panel_gestionAI);
			cursorOff();
		}
	}

	function Debugshow()
	{
		if (!$showDebug)
		{
			$showDebug = 1;
			$fps::avg = $fps::real;
			$fps::low = $fps::real;
			$fps::high = $fps::real;
		}
		if ($showDebug::toggle)
		{
			$fps::avg = ($fps::avg + $fps::real) / 2;
			if ($fps::real > $fps::high)
			{
				$fps::high = $fps::real;
			}
			if ($fps::real < $fps::low)
			{
				$fps::low = $fps::real;
			}
			fpscurr.setText("FPS: " SPC $fps::real);
			fpslow.setText("Low: " SPC $fps::low);
			fpshigh.setText("High:" SPC $fps::high);
			fpsavg.setText("Aver:" SPC $fps::avg);
			schedule(500, 0, "Debugshow");
		}
		else
		{
			$showDebug = 0;
		}
	}

};
GlobalActionMap.bindCmd(keyboard, "F12", "", "showDebug();");
