using System;
using SwinGameSDK;
namespace MyGame
{
	public static class FoodGenerator
	{
		public static Random rnd = new Random ();
		public static float _x = rnd.Next (0, 1024);
		public static float _y = rnd.Next (0, 768);

		public static void Food ()
		{
			SwinGame.FillRectangle (Color.Yellow, _x, _y, 50, 50);
		}

		public static void LetThereBeFood (int y)
		{
			for (int x=0; x < y; x++) {
				_x = rnd.Next (0, 1024);
				_y = rnd.Next (0, 768);
				Food ();
			}
		}
	}

}
