using SwinGameSDK;
using System.Collections.Generic;

/// <summary>
/// The Resources Class stores all of the Games Media Resources, such as Images, Fonts
/// Sounds, Music.
/// </summary>
public static class GameResources
{
	private static Dictionary<string, Font> _Fonts = new Dictionary<string, Font> ();

	/// <summary>
	/// Loads the fonts.
	/// </summary>
	private static void LoadFonts ()
	{
		NewFont ("Menu", "arial.ttf", 50);	}

	/// <summary>
	/// Gets a Font Loaded in the Resources
	/// </summary>
	/// <param name="font">Name of Font</param>
	/// <returns>The Font Loaded with this Name</returns>

	public static Font GameFont (string font)
	{
		return _Fonts [font];	}

	/// <summary>
	/// Loads the resources.
	/// </summary>
	public static void LoadResources ()
	{
		LoadFonts ();
	}

	/// <summary>
	/// Loads custom font from the resource folder.
	/// </summary>
	/// <param name="fontName">Font name.</param>
	/// <param name="filename">Filename.</param>
	/// <param name="size">Size.</param>
	private static void NewFont (string fontName, string filename, int size)
	{
		_Fonts.Add (fontName, SwinGame.LoadFont (SwinGame.PathToResource (filename, ResourceKind.FontResource), size));	}

	/// <summary>
	/// Frees up the font from the process.
	/// </summary>
	private static void FreeFonts ()
	{
		Font obj = default (Font);
		foreach (Font tempLoopVar_obj in _Fonts.Values) {
			obj = tempLoopVar_obj;
			SwinGame.FreeFont (obj);
		}	}

	/// <summary>
	/// Frees up the loaded assets from the process.
	/// </summary>
	public static void FreeResources ()
	{
		FreeFonts ();	}
}

