using System;
using System.Collections.Generic;
using SwinGameSDK;


/// <summary>
/// The GameController is responsible for controlling the game,
/// managing user input, and displaying the current state of the
/// game.
/// </summary>
public sealed class GameController
{
	public static Timer _gameTimer = SwinGame.CreateTimer ();

	private static Stack<GameState> _state = new Stack<GameState> ();

	private static bool muteFlag;

	public static Random rnd = new Random ();
	private static int _musicChoice = rnd.Next (1, 5);

	public static Timer GameTimer {
		get {
			return _gameTimer;
		}
	}

	/// <summary>
	/// Returns the current state of the game, indicating which screen is
	/// currently being used
	/// </summary>
	/// <value>The current state</value>
	/// <returns>The current state</returns>
	public static GameState CurrentState {
		get {
			return _state.Peek ();
		}
	}

	/// <summary>
	/// Initializes the state that the player is inhabiting in the main menu.
	/// </summary>
	static GameController ()
	{
		//bottom state will be quitting. If player exits main menu then the game is over
		_state.Push (GameState.Quitting);

		//at the start the player is viewing the main menu
		_state.Push (GameState.ViewingMainMenu);
	}

	/// <summary>
	/// Starts a new game.
	/// </summary>
	/// <remarks>
	/// Creates an AI player based upon the _aiSetting.
	/// </remarks>
	public static void StartGame ()
	{
		int randStart = rnd.Next (1, 10);
		if (_theGame != null) {
			EndGame ();
		}

		//Create the game
		_theGame = new BattleShipsGame ();

		//create the players
		if (_aiSetting == AIOption.Medium) {
			_ai = new AIMediumPlayer (_theGame);
		} else if (_aiSetting == AIOption.Hard) {
			_ai = new AIHardPlayer (_theGame);
		}
	}
	/// <summary>
	/// Stops listening to the old game once a new game is started
	/// </summary>

	private static void EndGame ()
	{
		//RemoveHandler _human.PlayerGrid.Changed, AddressOf GridChanged
		_ai.PlayerGrid.Changed -= GridChanged;
		_theGame.AttackCompleted -= AttackCompleted;
	}

	/// <summary>
	/// Listens to the game grids for any changes and redraws the screen
	/// when the grids change
	/// </summary>
	/// <param name="sender">the grid that changed</param>
	/// <param name="args">not used</param>
	private static void GridChanged (object sender, EventArgs args)
	{
		DrawScreen ();
		SwinGame.RefreshScreen ();
	}

	/// <summary>
	/// Plays the corresponding animation sequence and sound if an explosion animation was carried out.
	/// </summary>
	/// <param name="row">Row.</param>
	/// <param name="column">Column.</param>
	/// <param name="showAnimation">If set to <c>true</c> show animation.</param>
	private static void PlayHitSequence (int row, int column, bool showAnimation)
	{

		if (showAnimation) {
			UtilityFunctions.AddExplosion (row, column);
		}

		Audio.PlaySoundEffect (GameResources.GameSound ("Hit"));
		UtilityFunctions.DrawAnimationSequence ();
	}

	/// <summary>
	/// Plays the corresponding animation sequence and sound if a splash animation was carried out.
	/// </summary>
	/// <param name="row">Row.</param>
	/// <param name="column">Column.</param>
	/// <param name="showAnimation">If set to <c>true</c> show animation.</param>
	private static void PlayMissSequence (int row, int column, bool showAnimation)
	{
		if (showAnimation) {
			UtilityFunctions.AddSplash (row, column);
		}

		Audio.PlaySoundEffect (GameResources.GameSound ("Miss"));

		UtilityFunctions.DrawAnimationSequence ();
	}

	public static void HandleUserInput ()
	{
		//Read incoming input events
		SwinGame.ProcessEvents ();

		if (CurrentState == GameState.ViewingMainMenu) {
			MenuController.HandleMainMenuInput ();
		} else if (CurrentState == GameState.ViewingInstructions) {
			InstructionsController.HandleInstructionsInput ();
		}

		UtilityFunctions.UpdateAnimations ();
	}

	/// <summary>
	/// Draws the current state of the game to the screen.
	/// </summary>
	/// <remarks>
	/// What is drawn depends upon the state of the game.
	/// </remarks>
	public static void DrawScreen ()
	{
		UtilityFunctions.DrawBackground ();

		if (CurrentState == GameState.ViewingMainMenu) {
			SwinGame.StopTimer (GameTimer);
			MenuController.DrawMainMenu ();
		}

		UtilityFunctions.DrawAnimations ();

		SwinGame.RefreshScreen (120);
	}

	/// <summary>
	/// Move the game to a new state. The current state is maintained
	/// so that it can be returned to.
	/// </summary>
	/// <param name="state">the new game state</param>
	public static void AddNewState (GameState state)
	{
		_state.Push (state);
		UtilityFunctions.Message = "";
	}

	/// <summary>
	/// End the current state and add in the new state.
	/// </summary>
	/// <param name="newState">the new state of the game</param>
	public static void SwitchState (GameState newState)
	{
		EndCurrentState ();
		AddNewState (newState);
	}

	/// <summary>
	/// Ends the current state, returning to the prior state
	/// </summary>
	public static void EndCurrentState ()
	{
		_state.Pop ();
	}

	public static void Mute ()
	{
		if (muteFlag == false) {
			muteFlag = true;
			SwinGame.SetMusicVolume (0);
		} else if (muteFlag == true) {
			muteFlag = false;
			SwinGame.SetMusicVolume (50);
		}
	} 
}
