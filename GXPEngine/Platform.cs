using System;

namespace GXPEngine
{
	public class Platform : GameObject
	{
		Sprite sprite;

		public Platform ()
		{
			//TEMP
			SetSprite(new Sprite("../../Assets/IMG/platformplaceholder32.png"));
			//TEMPEND
		}

		public void SetSprite(Sprite sprite)
		{
			this.sprite = sprite;
			this.AddChild(this.sprite);
		}
	}
}

