using System;
using System.Drawing;
using System.Collections.Generic;

namespace GXPEngine
{
	public class Level : Canvas
	{
		private int[,] tileData;
		private int _tileSize;

		public int tileSize
		{
			get
			{
				if(_tileSize < 1)
				{
					_tileSize = 1;
				}
				return _tileSize;
			}
			set
			{
				_tileSize = value;
			}
		}

        public Player player;
		private LevelReader reader;
        GameOver gameover;
        int timer = 2;
        public bool isGameOver;
        int oldtime = 0;
        int seconds = 10000;

		public Level(/*Temporarily disabled: int tilesX, int tilesY*/ int width, int height, int tileSize, LevelReader reader) : base(width, height)
		{
            //Set default values
			this.tileSize = tileSize;

			tileData = reader.GetTileData();

//                tileData = new int[,] {
//				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//				{ 0, 10, 12, 11, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 11, 13, 0, 0, 0, 0, 0 },
//				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//				{ 0, 0, 0, 0, 0, 0, 10, 11, 12, 11, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//				{ 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5 },
//				{ 0, 0, 0, 0, 4, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
//				{ 20, 21, 22, 23, 21, 22, 23, 24, 15, 15, 15, 20, 21, 23, 24, 15, 20, 23, 21, 24 }
//			};
                //TEMPEND

                FillLevel();
		}

		protected MyGame getParentMyGame()
		{
			return parent as MyGame;
		}

		public void FillLevel()
		{
			for (int x = 0; x < tileData.GetLength(1); x++)
			{
				for (int y = 0; y < tileData.GetLength(0); y++)
				{
					Platform platform;
					Lava lava;
					Enemy enemy;
                    Collectable treasure;
                    Flag flag;
					switch(tileData[y, x])
					{
						case 1:
                            platform = new Platform(new Point(x, y));
                            platform.SetXY(x * tileSize, y * tileSize);
                            platform.SetSprite(new AnimSprite("../../Assets/IMG/32branches1.png", 1, 1));
                            this.AddChild(platform);
                            break;

                        case 2:
                            platform = new Platform(new Point(x, y));
                            platform.SetXY(x * tileSize, y * tileSize);
                            platform.SetSprite(new AnimSprite("../../Assets/IMG/32branches2.png", 1, 1));
                            this.AddChild(platform);
                            break;

                        case 3:
                            platform = new Platform(new Point(x, y));
                            platform.SetXY(x * tileSize, y * tileSize);
                            platform.SetSprite(new AnimSprite("../../Assets/IMG/32branches3.png", 1, 1));
                            this.AddChild(platform);
                            break;

                        case 4:
                            platform = new Platform(new Point(x, y));
                            platform.SetXY(x * tileSize, y * tileSize);
                            platform.SetSprite(new AnimSprite("../../Assets/IMG/32branches4.png", 1, 1));
                            this.AddChild(platform);
                            break;

                        case 5:
                            enemy = new Enemy(0.1f, 2, 0.25f, 1.3f);
                            enemy.SetXY(x * tileSize, y * tileSize);
                            this.AddChild(enemy);
                            break;

                        case 6:
                            platform = new Platform(new Point(x, y));
                            platform.SetXY(x * tileSize, y * tileSize);
                            platform.SetSprite(new AnimSprite("../../Assets/IMG/32groundfill.png", 1, 1));
                            this.AddChild(platform);
                            break;

                        case 7:
                            platform = new Platform(new Point(x, y));
                            platform.SetXY(x * tileSize, y * tileSize);
                            platform.SetSprite(new AnimSprite("../../Assets/IMG/32ground1.png", 1, 1));
                            this.AddChild(platform);
                            break;

                        case 8:
                            platform = new Platform(new Point(x, y));
                            platform.SetXY(x * tileSize, y * tileSize);
                            platform.SetSprite(new AnimSprite("../../Assets/IMG/32ground2.png", 1, 1));
                            this.AddChild(platform);
                            break;

                        case 9:
                            platform = new Platform(new Point(x, y));
                            platform.SetXY(x * tileSize, y * tileSize);
                            platform.SetSprite(new AnimSprite("../../Assets/IMG/32ground3.png", 1, 1));
                            this.AddChild(platform);
                            break;

                        case 10:
                            platform = new Platform(new Point(x, y));
                            platform.SetXY(x * tileSize, y * tileSize);
                            platform.SetSprite(new AnimSprite("../../Assets/IMG/32ground4.png", 1, 1));
                            this.AddChild(platform);
                            break;

                        case 11:
                            platform = new Platform(new Point(x, y));
                            platform.SetXY(x * tileSize, y * tileSize);
                            platform.SetSprite(new AnimSprite("../../Assets/IMG/32ground5.png", 1, 1));
                            this.AddChild(platform);
                            break;

                        case 12:
                            lava = new Lava(new Point(x, y));
                            lava.SetXY(x * tileSize, y * tileSize);
                            lava.SetSprite(new AnimSprite("../../Assets/IMG/32lavafill.png", 1, 1));
                            this.AddChild(lava);
                            break;

                        case 13:
                            lava = new Lava(new Point(x, y));
                            lava.SetXY(x * tileSize, y * tileSize);
                            lava.SetSprite(new AnimSprite("../../Assets/IMG/32lava1.png", 1, 1));
                            this.AddChild(lava);
                            break;

                        case 14:
                            lava = new Lava(new Point(x, y));
                            lava.SetXY(x * tileSize, y * tileSize);
                            lava.SetSprite(new AnimSprite("../../Assets/IMG/32lava2.png", 1, 1));
                            this.AddChild(lava);
                            break;

                        case 15:
                            lava = new Lava(new Point(x, y));
                            lava.SetXY(x * tileSize, y * tileSize);
                            lava.SetSprite(new AnimSprite("../../Assets/IMG/32lava3.png", 1, 1));
                            this.AddChild(lava);
                            break;

                        case 16:
                            lava = new Lava(new Point(x, y));
                            lava.SetXY(x * tileSize, y * tileSize);
                            lava.SetSprite(new AnimSprite("../../Assets/IMG/32lava4.png", 1, 1));
                            this.AddChild(lava);
                            break;

                        case 17:
                            player = new Player(0.1f, 2, 0.25f, 1.3f);
                            player.SetXY(x * tileSize, y * tileSize);
                            this.AddChild(player);
                            break;

                        case 18:
                            lava = new Lava(new Point(x, y));
                            lava.SetXY(x * tileSize, y * tileSize);
                            lava.SetSprite(new AnimSprite("../../Assets/IMG/32spacetile1.png", 1, 1));
                            this.AddChild(lava);
                            break;

                        case 19:
                            lava = new Lava(new Point(x, y));
                            lava.SetXY(x * tileSize, y * tileSize);
                            lava.SetSprite(new AnimSprite("../../Assets/IMG/32spacetile2.png", 1, 1));
                            this.AddChild(lava);
                            break;

                        case 20:
                            lava = new Lava(new Point(x, y));
                            lava.SetXY(x * tileSize, y * tileSize);
                            this.AddChild(lava);
                            break;

                        case 21:
                            lava = new Lava(new Point(x, y));
                            lava.SetXY(x * tileSize, y * tileSize);
                            lava.SetSprite(new AnimSprite("../../Assets/IMG/32spacetile4.png", 1, 1));
                            this.AddChild(lava);
                            break;

                        case 22:
                            flag = new Flag();
                            flag.SetXY(x * tileSize, y * tileSize);
                            this.AddChild(flag);
                            break;

                        case 23:
                            treasure = new Collectable(new Point(x, y));
                            treasure.SetXY(x * tileSize, y * tileSize);
                            treasure.SetSprite(new AnimSprite("../../Assets/IMG/tresure-chest-spritesheet.png", 4, 2));
                            this.AddChild(treasure);
                            break;

                        default:
                            break;
					}
				}
			}
		}

		public SpriteObject[] GetCollidableObjectsInTiles(Point[] tiles)
		{
			List<SpriteObject> collidableObjects = new List<SpriteObject>();
			List<GameObject> children = GetChildren();
			foreach(GameObject child in children)
			{
				if(child is SpriteObject)
				{
					if(child is TileObject && Array.IndexOf(tiles, (child as TileObject).tileCoordinates) != -1)
					{
						collidableObjects.Add(child as SpriteObject);
					}
					else if(child is Enemy)
					{
						foreach(Point occupyingTile in (child as Enemy).GetOccupyingTiles())
						{
							if(Array.IndexOf(tiles, occupyingTile) != -1)
							{
								collidableObjects.Add(child as SpriteObject);
								break;
							}
						}
					}
					else if(child is Projectile)
					{
						foreach(Point occupyingTile in (child as Projectile).GetOccupyingTiles())
						{
							if(Array.IndexOf(tiles, occupyingTile) != -1)
							{
								collidableObjects.Add(child as SpriteObject);
								break;
							}
						}
					}
				}
			}
			return collidableObjects.ToArray();
		}
        void Update()
        {
            if (isGameOver)
            {
                if (Time.now > (oldtime + 1000))
                {
                    if (timer < 2)
                    {
                        gameover.Destroy();
                    }
                    oldtime = Time.now;
                    GameOver(timer);
                    timer--;
                }
                #region oldShit
                //if (Input.GetKey(Key.S))
                //{
                //    List<GameObject> elements = this.GetChildren();
                //    if (timer > 0)
                //    {
                //        for (int i = 0; i < elements.Count; i++)
                //        {
                //            elements[i].Destroy();
                //        }
                //        getParentMyGame().dead = false;
                //        this.Destroy();
                //        isGameOver = false;
                //        MyGame.restartLevel = true;
                //    }
                #endregion
            }
            

            Scrolling();
        }

        public void Scrolling()
        {
            if (player != null)
            {
                #region OldScrol
                //if (player.x + x > 400)
                //{
                //    x = 400 - player.x;
                //}
                //if (player.x + x <50)
                //{
                //    x = 50 - player.x;
                //}
                //if (player.x + x < 400)
                //{
                //    x = 0;
                //}
                //if (player.x > 2950)
                //{
                //    x = -2560;
                //}
                //if (player.y + y > 45)
                //{
                //    y = 75; /*- player.y;*/
                //}
                //if (player.y < 100)
                //{
                //    y = 100;
                //}
                //if (player.y < 0)
                //{
                //    y = 100 - player.y;
                //}
                //{
                //    y = 75;
                //}
                //if (player.y + y < 100)
                //{
                    
                //    y = 100 - player.y;
                //}
                #endregion

                if (player.x + x > 200)
                {
                    x = 200 - player.x;
                }
                if (player.x + x < 100)
                {
                    x = 100 - player.x;
                }
                if (player.y + y > 300)
                {
                    y = -125;
                    //y = 300 - player.y;

                }
                if (player.y + y < 300)
                {
                   y = 300 - player.y;
                }
                //Console.WriteLine("Px: " + player.x);
                //Console.WriteLine("Py+y: " + (player.y + y));
                //Console.WriteLine("Cx: " + x);
                //Console.WriteLine("Cy: " + y);
            }
		}

        private void GameOver(int timer)
        {
            //Back to the start anyways.
            gameover = new GameOver(timer);
            //gameover.x = player.x - player.sprite.width - 20;
            gameover.x = -x;
            gameover.y = y+300;
            //gameover.y = game.y;
            this.AddChild(gameover);

            List<GameObject> children = this.GetChildren();
            foreach (GameObject child in children)
            {
                if (child is Creature)
                {
                    (child as Creature).enabled = false;
                }
            }
            if (timer <= 0)
            {
                isGameOver = false;
                MyGame.restartLevel = false;
                getParentMyGame().dead = true;
                for (int i = 0; i < children.Count; i++)
                {
                    children[i].Destroy();
                }
                this.Destroy();
                //this.visible = false;
            }
        }
	}
}
