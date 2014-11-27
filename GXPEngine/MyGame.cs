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

<<<<<<< Upstream, based on origin/master
            leaderBoard = new LeaderBoard(game.width, game.height);

            //cutscenes = new Cutscenes(game.width, game.height);
            //this.AddChild(cutscenes);
=======

>>>>>>> ed223ec Some final shit

			//this.AddChild(new Collectable());
		}
		
<<<<<<< Upstream, based on origin/master
		void Update () 
        {
            //cutscenes.OpeningScene();
=======
		void Update () {
>>>>>>> ed223ec Some final shit
            background.BackgroundAnimation();
<<<<<<< Upstream, based on origin/master
            if (Input.GetKeyDown(Key.W))
            {
                leaderBoard.Destroy();
                MakeMenu();
            }
            if (Input.GetKey(Key.S) || isPressed)
=======
            if (Input.GetKey(Key.SPACE) || isPressed)
>>>>>>> ed223ec Some final shit
            {
<<<<<<< Upstream, based on origin/master
                bool isLeaderBoard = menuScreen.LeaderBoard();
                leaderBoard.Destroy();
                if (makeLevel && isLeaderBoard == false)
                {
=======
                if (makeLevel)
                { 
>>>>>>> ed223ec Some final shit
                    MakeLevel();
                    makeLevel = false;
                    menuScreen.Destroy();
<<<<<<< Upstream, based on origin/master
                    isPressed = true;
                }
                if (isLeaderBoard)
                {
                    menuScreen.Destroy();
                    MakeScoreBoard();
=======
>>>>>>> ed223ec Some final shit
                }
                isPressed = true;
                if (dead)
                {
                    HUDCanvas.Destroy();
<<<<<<< Upstream, based on origin/master
                    //messageBox.Destroy();
                    MakeMenu();
                    makeLevel = true;
                    dead = true;
=======
                    messageBox.Destroy();
                    makeLevel = false;
                    dead = false;
>>>>>>> ed223ec Some final shit
                    stilldead = true;
                }
                else if (restartLevel)
                {
                    level.player.score = 0;
                    level.player.lives = 3;
                    makeLevel = true;
                    restartLevel = false;
                }
                else if (stilldead == false && isPressed)
                {
                    HUDCanvas.Score(level.player.score);
                    HUDCanvas.Lives(level.player.lives);
<<<<<<< Upstream, based on origin/master
                    //messageBox.Message();
=======
                    messageBox.Message();
>>>>>>> ed223ec Some final shit
                }
            }
<<<<<<< Upstream, based on origin/master
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
=======
		}
>>>>>>> ed223ec Some final shit

        public void MakeLevel()
        {
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
