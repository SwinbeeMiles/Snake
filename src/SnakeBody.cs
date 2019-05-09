using System;
using SwinGameSDK;
using System.Collections.Generic;
using System.Linq;
namespace MyGame
{
	public static class SnakeBody
	{
		private static List<SnakeModel> _snakeBodyParts = new List<SnakeModel> ();
		public static void CreateFirstSnake ()
		{
			SnakeModel snake = new SnakeModel ();
			_snakeBodyParts.Add (snake);
		}

		public static void CreateSnakeBody ()
		{
			SnakeModel snake = new SnakeModel ();
			var lastBody = _snakeBodyParts.Last ();
			snake.MoveSnakeXaxis = lastBody.MoveSnakeXaxis;
			snake.MoveSnakeYaxis = lastBody.MoveSnakeYaxis;
			snake.MoveSnakeXaxis += 20;
			_snakeBodyParts.Add (snake);
		}

		public static void Draw()
		{
			for (int x = 1; x < _snakeBodyParts.Count; x++) {
				_snakeBodyParts [0].DrawSnakeHead ();
				_snakeBodyParts [x].DrawSnake ();
			}
		}

		public static List<SnakeModel> SnakeBodyParts {
			get { return _snakeBodyParts; }
		}
	}
}
