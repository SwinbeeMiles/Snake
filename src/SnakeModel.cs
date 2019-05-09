using System;
using SwinGameSDK;
namespace MyGame
{
	public class SnakeModel
	{
		private float _x = 512;
		private float _y = 384;

		public float MoveSnakeXaxis
		{
			get {
				return _x;
			}

			set{
				_x = value;
			}
		}

		public float MoveSnakeYaxis
		{
			get {
				return _y;
			}
			 
			set {
				_y = value;
			}
		}

		public void DrawSnakeHead ()
		{
			SwinGame.FillCircle (Color.Red, _x, _y, 10);
		}

		public void DrawSnake ()
		{
			SwinGame.FillCircle (Color.Black, _x, _y, 10);
		}
	}
}
