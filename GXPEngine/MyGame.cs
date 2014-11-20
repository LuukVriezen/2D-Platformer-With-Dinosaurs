using System;
using GXPEngine;
using System.Drawing;

namespace GXPEngine
{

	public class MyGame : Game
	{	
		Canvas HUDCanvas;
		Level level;

		public MyGame () : base(640, 480, false)
		{
			level = new Level(640, 448);
			this.AddChild(level);

			HUDCanvas = new Canvas(this.width, this.height);
			this.AddChild(HUDCanvas);

			//this.AddChild(new Collectable());
		}
		
		void Update () {
			HUDCanvas.graphics.Clear(Color.Transparent);
			HUDCanvas.graphics.DrawString("Score: " + level.score, new Font("Arial", 20), Brushes.White, new PointF(20, 20));
		}

		static void Main() {
			new MyGame().Start();
		}
	}

}