using System;
using GXPEngine;
using System.Drawing;

namespace GXPEngine
{

	public class MyGame : Game
	{	
		Canvas HUDCanvas;
		Level level;

        bool isPressed = false;
        bool makeLevel = true;
        MenuScreen menuScreen;

		public MyGame () : base(640, 480, false)
		{

            menuScreen = new MenuScreen();
            this.AddChild(menuScreen);

			//this.AddChild(new Collectable());
		}
		
		void Update () {
            if (Input.GetKeyDown(Key.SPACE) || isPressed)
            {
                if (makeLevel)
                { 
                    MakeLevel();
                    makeLevel = false;
                    menuScreen.Destroy();
                }
                HUDCanvas.graphics.Clear(Color.Transparent);
                HUDCanvas.graphics.DrawString("Score: " + level.score, new Font("Arial", 20), Brushes.White, new PointF(20, 20));
                isPressed = true;
            }
		}

        void MakeLevel()
        {
            level = new Level(640, 448);
            this.AddChild(level);

            HUDCanvas = new Canvas(this.width, this.height);
            this.AddChild(HUDCanvas);
        }


		static void Main() {
			new MyGame().Start();
		}
	}

}