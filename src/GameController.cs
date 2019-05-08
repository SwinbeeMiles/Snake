using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class GameController
	{
		private static Stack<GameState> _state = new Stack<GameState> ();

		public GameController ()
		{
		}

		public static GameState CurrentState 
		{
			get 
			{
				_state.Peek();
			}
		}
	}
}
