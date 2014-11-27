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
        Cutscenes cutscenes;
        LeaderBoard leaderBoard;

        Sound backgroundSound;

        bool isPressed = false;
        bool makeLevel = true;

        public bool isCutSene = true;

        static public bool restartLevel = false;
        public bool dead = false;
        public bool stilldead = false;

		public MyGame () : base(640, 480, false)
		{
            backgroundSound = new Sound("../../Assets/Sounds/NewBackground.mp3", true, true);
            backgroundSound.Play();
            background = new Background(game.width, game.height);
            this.AddChild(background);

            cutscenes = new Cutscenes(game.width, game.height);

            menuScreen = new MenuScreen();
            this.AddChild(menuScreen);

            leaderBoard = new LeaderBoard(game.width, game.height);


			//this.AddChild(new Collectable());
		}
		
		void Update () 
        {
            background.BackgroundAnimation();
            if (Input.GetKeyDown(Key.W))
            {
                leaderBoard.Destroy();
                MakeMenu();
            }
            if (Input.GetKeyDown(Key.S) || isPressed)
            {
                menuScreen.inGame = true;
                bool isLeaderBoard = menuScreen.LeaderBoard();
                leaderBoard.Destroy();
                if (makeLevel && isLeaderBoard == false)
                {
                    MakeLevel();
                    makeLevel = false;
                    stilldead = false;
                    isPressed = true;
                }
                if (isLeaderBoard)
                {
                    menuScreen.Destroy();
                    MakeScoreBoard();
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
                    //messageBox.Destroy();
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
                    //messageBox.Message();
                }
            }
        }

        public void AddCutScene()
        {
            this.AddChild(cutscenes); 
        }

        public void MakeScoreBoard()
        {
            leaderBoard = new LeaderBoard(game.width, game.height);
            this.AddChild(leaderBoard);
        }

        public void MakeMenu()
        {
            menuScreen = new MenuScreen();
            this.AddChild(menuScreen);
        }

        public void MakeLevel()
        {
            background = new Background(game.width, game.height);
            this.AddChild(background);

            //cutscenes.Destroy();

            HUDCanvas = new HUD(this.width, this.height);
            this.AddChild(HUDCanvas);
            //messageBox = new MessageBox(this.width, this.height);
            //this.AddChild(messageBox);

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