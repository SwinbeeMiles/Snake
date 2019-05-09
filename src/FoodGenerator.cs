using System;
using SwinGameSDK;
using System.Collections.Generic;
using System.Linq;
namespace MyGame
{
	public static class FoodGenerator
	{
		private static List<Food> _foodList = new List<Food> ();
		public static void CreateFood ()
		{
			Food _createFood = new Food ();
			_foodList.Add (_createFood);
		}

		public static void LetThereBeFood ()
		{
			for (int x = 0; x < 20; x++) 
			{
				CreateFood ();
			}
		}

		public static void DrawFood ()
		{
			for (int x = 0; x < _foodList.Count; x++)
			{
				_foodList [x].DrawRect ();
			}
		}

		public static void RespawnFood ()
		{
			
		}
	}
}
