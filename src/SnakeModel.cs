using System;
using SwinGameSDK;
namespace MyGame
{
	public static class SnakeModel
	{
		private static float _x = 800;
		private static float _y = 600;

		public static void MoveSnake (float x, float y)
		{
			_x += x;
			_y += y;
		}
		public static void DrawSnake ()
		{
			SwinGame.FillCircle (Color.Black, _x, _y, 10);
		}
	}
}
