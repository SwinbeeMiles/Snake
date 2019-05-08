using System;
using System.Collections.Generic;
using SwinGameSDK;

/// <summary>
/// The GameController is responsible for managing user input and 
/// drawing the respective screen of state.
/// </summary>
public sealed class GameController
{
	private static Stack<GameState> _state = new Stack<GameState> ();

	/// <summary>
	/// Returns the current state of the game
	/// </summary>
	/// <value>The current state</value>
	/// <returns>The current state</returns>
	public static GameState State {
		get {
			return _state.Peek ();
		}	}

	/// <summary>
	/// Initializes the state, starts with main menu and ends with quitting
	/// </summary>
	static GameController ()
	{
		_state.Push (GameState.Quitting);

		_state.Push (GameState.ViewingMainMenu);	}

	/// <summary>
	/// Adds a new state into the stack
	/// </summary>
	/// <param name="state">the new game state</param>
	public static void AddNewState (GameState state)
	{
		_state.Push (state);	}

	/// <summary>
	/// Remove current state going to the previous one
	/// </summary>
	public static void EndCurrentState ()
	{
		_state.Pop ();	}

	/// <summary>
	/// Replace the current state with a new one.
	/// </summary>
	/// <param name="newState">the new state of the game</param>
	public static void SwitchState (GameState newState)
	{
		EndCurrentState ();
		AddNewState (newState);	}

	/// <summary>
	/// Starts a new game.
	/// </summary>
	public static void StartGame ()
	{
		AddNewState (GameState.Playing);
		SwinGame.ClearScreen(Color.White);	}

	/// <summary>
	/// Handles the user SwinGame.
	/// </summary>
	/// <remarks>
	/// Reads key and mouse input and
	/// react depending on the state
	/// </remarks>
	public static void HandleUserInput ()
	{
		//Read incoming input events
		SwinGame.ProcessEvents ();

		if (State == GameState.ViewingMainMenu) {
			MenuController.HandleMainMenuInput ();
		} else if (State == GameState.ViewingGameMenu)
		{
			MenuController.HandleGameMenuInput();
		} else if (State == GameState.Playing) {
			if (SwinGame.KeyTyped (KeyCode.vk_ESCAPE)) {
				AddNewState (GameState.ViewingGameMenu);
			}
		}	}

	/// <summary>
	/// Draws the current state of the game
	/// </summary>
	/// <remarks>
	/// Draw screen depending on the state of the game.
	/// </remarks>
	public static void DrawScreen ()	{
		if (State == GameState.ViewingMainMenu) {
			MenuController.DrawMainMenu ();
		} else if (State == GameState.ViewingGameMenu) {
			MenuController.DrawGameMenu ();
		} else if (State == GameState.Playing)
		{
			
		}

		SwinGame.RefreshScreen(120);
	}
}
