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
        Background background;

        bool isPressed = false;
        bool makeLevel = true;

        static public bool restartLevel = false;
        public bool dead = false;
        public bool stilldead = false;

		public MyGame () : base(640, 480, false)
		{
            
            background = new Background(game.width, game.height);
            this.AddChild(background);

            menuScreen = new MenuScreen();
            this.AddChild(menuScreen);

			//this.AddChild(new Collectable());
		}
		
		void Update () 
        {
            background.BackgroundAnimation();
            if (Input.GetKey(Key.S) || isPressed)
            {
                bool isLeaderBoard = menuScreen.LeaderBoard();
                if (makeLevel && isLeaderBoard == false)
                { 
                    MakeLevel();
                    makeLevel = false;
                    menuScreen.Destroy();
                    isPressed = true;
                }
                if (restartLevel)
                {
                    level.player.score = 0;
                    level.player.lives = 3;
                    if (dead == true)
                    {
                        makeLevel = false;
                        dead = false;
                    }
                    else
                    {
                        makeLevel = true;
                    }
                    restartLevel = false;
                    stilldead = false;
                }
                if (dead)
                {
                    HUDCanvas.Destroy();
                    messageBox.Destroy();
                    MakeMenu();
                    makeLevel = true;
                    dead = true;
                    stilldead = true;
                    isPressed = false;
                    restartLevel = true;
                }
                if (stilldead == false && isPressed)
                {
                    HUDCanvas.Score(level.player.score);
                    HUDCanvas.Lives(level.player.lives);
                    messageBox.Message();
                }
                if (isLeaderBoard)
                {
                    //leaderboard
                }
            }
		}

        public void MakeMenu()
        {
            menuScreen = new MenuScreen();
            this.AddChild(menuScreen);
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