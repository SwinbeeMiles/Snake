using System;
using SwinGameSDK;
namespace MyGame
{
	public static class GameControl
	{
		private static char _checkDirection;
		private static float _moveSpeed = 2;
		public static void SnakeController ()
		{
			if (SwinGame.KeyTyped (KeyCode.vk_UP)) {
				SnakeModel.DrawSnake ();
				_checkDirection = 'w';
			} else if (SwinGame.KeyTyped (KeyCode.vk_LEFT)) {
				SnakeModel.DrawSnake ();
				_checkDirection = 'a';
			} else if (SwinGame.KeyTyped (KeyCode.vk_RIGHT)) {
				SnakeModel.DrawSnake ();
				_checkDirection = 'd';
			} else if (SwinGame.KeyTyped (KeyCode.vk_DOWN)) {
				SnakeModel.DrawSnake ();
				_checkDirection = 's';
			}
		}

		public static void SnakeMovement ()
		{
			if (_checkDirection == 'w') {
				SnakeModel.MoveSnake(0, -_moveSpeed);
			}
			else if (_checkDirection == 'a') {
				SnakeModel.MoveSnake (-_moveSpeed,0);
			}
			else if (_checkDirection == 'd') {
				SnakeModel.MoveSnake (_moveSpeed,0);
			}
			else if (_checkDirection == 's') {
				SnakeModel.MoveSnake (0,_moveSpeed);
			}
		}



	}
}
