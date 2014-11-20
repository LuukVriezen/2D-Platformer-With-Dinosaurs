using System;
using System.Drawing;

namespace GXPEngine
{
	public class Platform : TileObject
	{
		public Platform(Point tileCoordinates) : base(tileCoordinates)
		{
			//TEMP
			SetSprite(new Sprite("../../Assets/IMG/empty.png"));
			//TEMPEND
		}
	}
}

