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
				_checkDirection = 'w';
			} else if (SwinGame.KeyTyped (KeyCode.vk_LEFT)) {
				_checkDirection = 'a';
			} else if (SwinGame.KeyTyped (KeyCode.vk_RIGHT)) {
				_checkDirection = 'd';
			} else if (SwinGame.KeyTyped (KeyCode.vk_DOWN)) {
				_checkDirection = 's';
			}
		}


		public static void SnakeMovement ()
		{
			for (int x = 0; x < SnakeBody.SnakeBodyParts.Count; x++) {
				if (_checkDirection == 'w') {
					SnakeBody.SnakeBodyParts [x].MoveSnakeYaxis -= _moveSpeed;
				} else if (_checkDirection == 'a') {
					SnakeBody.SnakeBodyParts [x].MoveSnakeXaxis -= _moveSpeed;
				} else if (_checkDirection == 'd') {
					SnakeBody.SnakeBodyParts [x].MoveSnakeXaxis += _moveSpeed;
				} else if (_checkDirection == 's') {
					SnakeBody.SnakeBodyParts [x].MoveSnakeYaxis += _moveSpeed;
				}
			}
		}



	}
}
