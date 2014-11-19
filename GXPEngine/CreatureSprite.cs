using System;
using System.Drawing;
using System.Collections.Generic;

namespace GXPEngine
{
	public class CreatureSprite : AnimSprite
	{
		Dictionary<CreatureState, int[]> FramesByState;

		public CreatureSprite(string filename, int cols, int rows, int frames = -1) : base(filename, cols, rows, frames)
		{

		}
	}
}

