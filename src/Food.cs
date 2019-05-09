using System;
using SwinGameSDK;
namespace MyGame
{
	public class Food
	{
		private static Random rng = new Random ();
		private float _xFoodPos = rng.Next (4, 1020);
		private float _yFoodPos = rng.Next (8, 764);

		public float FoodXaxis {
			get {
				return _xFoodPos;
			}
		}

		public float FoodYaxis {
			get {
				return _yFoodPos;
			}
		}
		                                    
		public void DrawRect ()
		{
			SwinGame.FillRectangle (Color.Brown, _xFoodPos, _yFoodPos, 8, 8);
		}
	}
}
