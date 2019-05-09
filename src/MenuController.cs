using System;
using System.Collections.Generic;
using SwinGameSDK;

static class MenuController
{
	private readonly static string [] [] _menuStructure = new string [] [] {new string[] {"PLAY", "QUIT"},
			new string[] {"MAIN MENU", "QUIT"}};

	private const int MENU_TOP = 250;
	private const int MENU_LEFT = 300;
	private const int MENU_GAP = 10;
	private const int BUTTON_WIDTH = 424;
	private const int BUTTON_HEIGHT = 50;
	private const int BUTTON_SEP = BUTTON_WIDTH + MENU_GAP;
	private const int TEXT_OFFSET = 0;

	private const int MAIN_MENU = 0;
	private const int GAME_MENU = 1;

	private const int MAIN_MENU_PLAY_BUTTON = 0;
	private const int MAIN_MENU_QUIT_BUTTON = 1;

	private const int GAME_MENU_MAINMENU_BUTTON = 0;
	private const int GAME_MENU_QUIT_BUTTON = 1;

	private readonly static Color MENU_COLOR = SwinGame.RGBAColor (2, 167, 252, 255);

	/// <summary>
	/// Handles the processing of user input in main menu
	/// </summary>
	public static void HandleMainMenuInput ()
	{
		HandleMenuInput (MAIN_MENU, 0, 0);	}

	/// <summary>
	/// Game menu for when the user is playing
	/// </summary>
	/// <remarks>
	/// Player can return to main menu or quit
	/// </remarks>
	public static void HandleGameMenuInput ()
	{
		HandleMenuInput (GAME_MENU, 0, 0);	}

	/// <summary>
	/// Handles input for the specified menu.
	/// </summary>
	/// <param name="menu">the identifier of the menu being processed</param>
	/// <param name="level">the vertical level of the menu</param>
	/// <param name="xOffset">the xoffset of the menu</param>
	/// <returns>false if a clicked missed the buttons. This can be used to check prior menus.</returns>
	private static bool HandleMenuInput (int menu, int level, int xOffset)
	{
		if (SwinGame.KeyTyped (KeyCode.vk_ESCAPE)) {
			GameController.EndCurrentState ();
			return true;
		}

		if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
			int i = 0;
			for (i = 0; i <= _menuStructure [menu].Length - 1; i++) {
				//IsMouseOver the i'th button of the menu
				if (IsMouseOverMenu (i, level, xOffset)) {
					PerformMenuAction (menu, i);
					return true;
				}
			}

			if (level > 0) {
				//none clicked - so end this sub menu
				GameController.EndCurrentState ();
			}
		}

		//Press R to go back to main menu or play the game
		if (SwinGame.KeyTyped (KeyCode.vk_r)) {
			PerformMenuAction (menu, 0);
			return true;
		}

		return false;	}

	/// <summary>
	/// Draws the main menu to the screen.
	/// </summary>
	public static void DrawMainMenu ()
	{
		//Clears the Screen to Black
		//SwinGame.DrawText("Main Menu", Color.White, GameFont("ArialLarge"), 50, 50)

		DrawButtons (MAIN_MENU);
	}

	/// <summary>
	/// Draws the Game menu to the screen
	/// </summary>
	public static void DrawGameMenu ()
	{
		//Clears the Screen to Black
		//SwinGame.DrawText("Paused", Color.White, GameFont("ArialLarge"), 50, 50)

		DrawButtons (GAME_MENU);
	}

	/// <summary>
	/// Draws the settings menu to the screen.
	/// </summary>
	/// <remarks>
	/// Also shows the main menu
	/// </remarks>
	public static void DrawSettings ()
	{
		DrawButtons (MAIN_MENU);
	}

	/// <summary>
	/// Draw the buttons associated with a top level menu.
	/// </summary>
	/// <param name="menu">the index of the menu to draw</param>
	private static void DrawButtons (int menu)
	{
		DrawButtons (menu, 0, 0);
	}

	/// <summary>
	/// Draws the menu at the indicated level.
	/// </summary>
	/// <param name="menu">the menu to draw</param>
	/// <param name="level">the level (height) of the menu</param>
	/// <param name="xOffset">the offset of the menu</param>
	/// <remarks>
	/// The menu text comes from the _menuStructure field. The level indicates the height
	/// of the menu, to enable sub menus. The xOffset repositions the menu horizontally
	/// to allow the submenus to be positioned correctly.
	/// </remarks>
	private static void DrawButtons (int menu, int level, int xOffset)
	{
		int btnLeft = 0;

		btnLeft = MENU_LEFT + BUTTON_SEP * (xOffset);
		int i = 0;
		for (i = 0; i <= _menuStructure [menu].Length - 1; i++) {
			int btnTop = 0;
			//btnTop = MENU_TOP - (MENU_GAP + BUTTON_HEIGHT) * level;
			btnTop = (MENU_TOP + i * 100) - (MENU_GAP + BUTTON_HEIGHT) * level;
			//SwinGame.FillRectangle(Color.White, btnLeft, btnTop, BUTTON_WIDTH, BUTTON_HEIGHT)
			SwinGame.DrawTextLines (_menuStructure [menu] [i], MENU_COLOR, Color.Black, GameResources.GameFont ("Menu"), FontAlignment.AlignCenter, btnLeft + TEXT_OFFSET, btnTop + TEXT_OFFSET, BUTTON_WIDTH, BUTTON_HEIGHT);
		}
	}

	/// <summary>
	/// Determined if the mouse is over one of the button in the main menu.
	/// </summary>
	/// <param name="button">the index of the button to check</param>
	/// <returns>true if the mouse is over that button</returns>
	private static bool IsMouseOverButton (int button)
	{
		return IsMouseOverMenu (button, 0, 0);
	}

	/// <summary>
	/// Determines if the mouse is in a given rectangle.
	/// Can be moved to somewhere else.
	/// </summary>
	/// <param name="x">the x location to check</param>
	/// <param name="y">the y location to check</param>
	/// <param name="w">the width to check</param>
	/// <param name="h">the height to check</param>
	/// <returns>true if the mouse is in the area checked</returns>
	public static bool IsMouseInRectangle (int x, int y, int w, int h)
	{
		Point2D mouse = default (Point2D);
		bool result = false;

		mouse = SwinGame.MousePosition ();

		//if the mouse is inline with the button horizontally
		if (mouse.X >= x && mouse.X <= x + w) {
			//Check vertical position
			if (mouse.Y >= y && mouse.Y <= y + h) {
				result = true;
			}
		}

		return result;	}

	/// <summary>
	/// Checks if the mouse is over one of the buttons in a menu.
	/// </summary>
	/// <param name="button">the index of the button to check</param>
	/// <param name="level">the level of the menu</param>
	/// <param name="xOffset">the xOffset of the menu</param>
	/// <returns>true if the mouse is over the button</returns>
	private static bool IsMouseOverMenu (int button, int level, int xOffset)
	{
		int btnTop = (MENU_TOP + button * 100) - (MENU_GAP + BUTTON_HEIGHT) * level;
		int btnLeft = MENU_LEFT + BUTTON_SEP * (xOffset);

		return IsMouseInRectangle (btnLeft, btnTop, BUTTON_WIDTH, BUTTON_HEIGHT);
	}

	/// <summary>
	/// Switches menu depending on what is pressed
	/// </summary>
	/// <param name="menu">the menu that has been clicked</param>
	/// <param name="button">the index of the button that was clicked</param>
	private static void PerformMenuAction (int menu, int button)
	{
		switch (menu) {
		case MAIN_MENU:
			PerformMainMenuAction (button);
			break;
		case GAME_MENU:
			PerformGameMenuAction (button);
			break;
		}
	}

	/// <summary>
	/// Perform the button's action when it is clicked in main menu.
	/// </summary>
	/// <param name="button">the button pressed</param>
	private static void PerformMainMenuAction (int button)
	{
		switch (button) {
		case MAIN_MENU_PLAY_BUTTON:
			GameController.StartGame ();
			break;
		case MAIN_MENU_QUIT_BUTTON:
			GameController.EndCurrentState ();
			break;
		}
	}

	/// <summary>
	/// Perform the button's action when it is clicked in game menu.
	/// </summary>
	/// <param name="button">the button pressed</param>
	private static void PerformGameMenuAction (int button)
	{
		switch (button) {
		case GAME_MENU_MAINMENU_BUTTON:
			GameController.EndCurrentState ();
			GameController.EndCurrentState ();
			break;
		case GAME_MENU_QUIT_BUTTON:
			GameController.AddNewState (GameState.Quitting);
			break;
		}	}
}

