using System;

namespace GXPEngine
{
	public class SpriteObject : GameObject
	{
		public AnimSprite sprite;

		public SpriteObject ()
		{

		}

		public Level getParentLevel()
		{
			return parent as Level;
		}

		public void SetSprite(AnimSprite sprite)
		{
			this.sprite = sprite;
			this.AddChild(this.sprite);
		}
	}
}

