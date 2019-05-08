using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameMain
	{
		public static void Main ()
		{
			//Open the game window
			SwinGame.OpenGraphicsWindow ("Super Snake by Team Delta", 1024, 768);
			//SwinGame.ShowSwinGameSplashScreen();

			//Run the game loop
			while (!(SwinGame.WindowCloseRequested () == true))
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0,757);
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}