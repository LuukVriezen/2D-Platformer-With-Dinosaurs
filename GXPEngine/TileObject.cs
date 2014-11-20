using System;
using System.Drawing;

namespace GXPEngine
{
	public class TileObject : GameObject
	{
		public Point tileCoordinates;
		public Sprite sprite;

		public TileObject(Point tileCoordinates)
		{
			this.tileCoordinates = tileCoordinates;
		}

		public void SetSprite(Sprite sprite)
		{
			this.sprite = sprite;
			this.AddChild(this.sprite);
		}
	}
}

