using System;
using SwinGameSDK;
namespace MyGame
{
	public static class Edgy
	{
		public static void LineEdge ()
		{
			SwinGame.DrawThickLine (Color.Red, 0, 0, 1024, 0,3);
			SwinGame.DrawThickLine (Color.Red,0, 767, 1024,767,3);
			SwinGame.DrawThickLine(Color.Red, 0, 0, 0, 768,3);
			SwinGame.DrawThickLine(Color.Red, 1023, 0, 1023, 767,3);

		}
	}
}
