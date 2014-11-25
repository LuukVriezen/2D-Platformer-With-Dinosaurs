using System;
using System.Drawing;

namespace GXPEngine
{
	public class TileObject : SpriteObject
	{
		public Point tileCoordinates;

		public TileObject(Point tileCoordinates)
		{
			this.tileCoordinates = tileCoordinates;
		}
	}
}

