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
				HUDCanvas.graphics.DrawString("Score: " + level.player.score, new Font("Arial", 20), Brushes.White, new PointF(20, 20));
				HUDCanvas.graphics.DrawString("Lives: " + level.player.lives, new Font("Arial", 20), Brushes.White, new PointF(20, 60));
                isPressed = true;
            }
		}

        void MakeLevel()
        {
			//TEMP
			int tileSize = 32;
			LevelReader reader = new LevelReader(/*TEMP*/"level.tmx"/*TEMPEND*/);
			level = new Level(reader.GetWidth() * tileSize, reader.GetHeight() * tileSize, tileSize, reader);
            this.AddChild(level);
			//TEMPEND

            HUDCanvas = new Canvas(this.width, this.height);
            this.AddChild(HUDCanvas);
        }


		static void Main() {
			new MyGame().Start();
		}
	}

}