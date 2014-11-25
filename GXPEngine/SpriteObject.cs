using System;

namespace GXPEngine
{
	public class SpriteObject : GameObject
	{
		public AnimSprite sprite;

		public SpriteObject ()
		{

		}

		public void SetSprite(AnimSprite sprite)
		{
			this.sprite = sprite;
			this.AddChild(this.sprite);
		}
	}
}

