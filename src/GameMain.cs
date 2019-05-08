using SwinGameSDK;

namespace MyGame
{
	public class GameMain
	{
		public static void Main ()
		{
			//Open the game window
			SwinGame.OpenGraphicsWindow ("Super Snake by Team Delta", 1024, 768);

			GameResources.LoadResources ();

			//Run the game loop
			while(!(true == SwinGame.WindowCloseRequested() || GameController.State == GameState.Quitting))
			{

				GameController.HandleUserInput ();
				GameController.DrawScreen ();
            }

			GameResources.FreeResources ();
        }
    }
}