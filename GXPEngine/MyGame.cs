using System;
using GXPEngine;
using System.Drawing;

namespace GXPEngine
{

	public class MyGame : Game
	{	
		HUD HUDCanvas;
        Level level;
        MenuScreen menuScreen;
        MessageBox messageBox;

        bool isPressed = false;
        bool makeLevel = true;

        public bool restartLevel = false;

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
                isPressed = true;
                if (restartLevel)
                {
                    level.player.score = 0;
                    level.player.lives = 3;
                }
                HUDCanvas.Score(level.player.score);
                HUDCanvas.Lives(level.player.lives);
                messageBox.Message();
            }
		}

        public void MakeLevel()
        {
            HUDCanvas = new HUD(this.width, this.height);
            this.AddChild(HUDCanvas);
            messageBox = new MessageBox(this.width, this.height);
            this.AddChild(messageBox);

			//TEMP
			int tileSize = 32;
			LevelReader reader = new LevelReader(/*TEMP*/"level.tmx"/*TEMPEND*/);
			level = new Level(reader.GetWidth() * tileSize, reader.GetHeight() * tileSize, tileSize, reader);
            this.AddChild(level);
			//TEMPEND
        }

		static void Main() {
			new MyGame().Start();
		}
	}

}