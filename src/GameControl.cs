using System;
using SwinGameSDK;
namespace MyGame
{
	public static class GameControl
	{
		private static char _checkDirection;
		private static float _moveSpeed = 10;
		public static void SnakeController ()
		{
			if (SwinGame.KeyTyped (KeyCode.vk_UP)) {
				SnakeModel.MoveSnake (0, -_moveSpeed);
				SnakeModel.DrawSnake ();
				_checkDirection = 'w';
			} else if (SwinGame.KeyTyped (KeyCode.vk_LEFT)) {
				SnakeModel.MoveSnake (-_moveSpeed, 0);
				SnakeModel.DrawSnake ();
				_checkDirection = 'a';
			} else if (SwinGame.KeyTyped (KeyCode.vk_RIGHT)) {
				SnakeModel.MoveSnake (_moveSpeed, 0);
				SnakeModel.DrawSnake ();
				_checkDirection = 'd';
			} else if (SwinGame.KeyTyped (KeyCode.vk_DOWN)) {
				SnakeModel.MoveSnake (0, _moveSpeed);
				SnakeModel.DrawSnake ();
				_checkDirection = 's';
			}
		}

		public static void SnakeMovement ()
		{
			if (_checkDirection == 'w') {
				SnakeModel.MoveSnake(0, -_moveSpeed + 10);
			}
		}
	}
}
