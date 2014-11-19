using System;
using System.Drawing;

namespace GXPEngine
{
	public class CreatureSprite : AnimSprite
	{
		public CreatureSprite(string filename, int cols, int rows, int frames = -1) : base(filename, cols, rows, frames)
		{

		}

		public CreatureSprite(Bitmap bitmap, int cols, int rows, int frames = -1) : base(bitmap, cols, rows, frames)
		{

		}
	}
}

