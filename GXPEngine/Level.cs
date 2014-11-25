using System;
using System.Drawing;
using System.Collections.Generic;

namespace GXPEngine
{
	public class Level : Canvas
	{
		private int[,] tileData;
		public int tileSize;
        public Player player;
		private LevelReader reader;
<<<<<<< HEAD
        GameOver gameover = new GameOver();
=======


>>>>>>> Stash

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
							platform = new Platform(new Point(x, y));
							platform.SetXY(x * tileSize, y * tileSize);
							platform.SetSprite(new AnimSprite("../../Assets/IMG/32ground1.png", 1, 1));
							this.AddChild(platform);
							break;

						case 6:
							platform = new Platform(new Point(x, y));
							platform.SetXY(x * tileSize, y * tileSize);
							platform.SetSprite(new AnimSprite("../../Assets/IMG/32ground2.png", 1, 1));
							this.AddChild(platform);
							break;

						case 7:
							platform = new Platform(new Point(x, y));
							platform.SetXY(x * tileSize, y * tileSize);
							platform.SetSprite(new AnimSprite("../../Assets/IMG/32ground3.png", 1, 1));
							this.AddChild(platform);
							break;

						case 8:
							platform = new Platform(new Point(x, y));
							platform.SetXY(x * tileSize, y * tileSize);
							platform.SetSprite(new AnimSprite("../../Assets/IMG/32ground4.png", 1, 1));
							this.AddChild(platform);
							break;

						case 9:
							platform = new Platform(new Point(x, y));
							platform.SetXY(x * tileSize, y * tileSize);
							platform.SetSprite(new AnimSprite("../../Assets/IMG/32ground5.png", 1, 1));
							this.AddChild(platform);
							break;

						case 10:
							lava = new Lava(new Point(x, y));
							lava.SetXY(x * tileSize, y * tileSize);
							lava.SetSprite(new AnimSprite("../../Assets/IMG/32Lava.png", 1, 1));
							this.AddChild(lava);
							break;

						case 11:
							player = new Player(0.1f, 2, 0.25f, 1.3f);
							player.SetXY(x * tileSize, y * tileSize);
							this.AddChild(player);
							break;

						case 12:
							enemy = new Enemy(0.1f, 2, 0.25f, 1.3f);
							enemy.SetXY(x * tileSize, y * tileSize);
							this.AddChild(enemy);
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
				}
			}
			return collidableObjects.ToArray();
		}
        void Update()
        {
            GameOver();
            Scrolling();
        }

        public void Scrolling()
        {
            if (player != null)
            {
                if (player.x + x > 400)
                {
                    x = 400 - player.x;
                }
                if (player.x + x < 100)
                {
                    x = 100 - player.x;
                }
                //if (player.y + y > 200)
                //{
                //    y = 200 - player.y;
                //}
                //if (player.y + y < 200)
                //{
                //    y = 200 - player.y;
                //}
            }
		}

<<<<<<< HEAD
        public void GameOver()
        {
            //Back to the start anyways.
            if (Input.GetKeyDown(Key.D))
            {
                AddChild(gameover);

                List<GameObject> children = this.GetChildren();
                foreach (GameObject child in children)
                {
                    if (child is Creature)
                    {
                        (child as Creature).enabled = false;
                    }
                }
                if (Input.GetKeyDown(Key.Y))
                {
                    foreach (GameObject child in children)
                    {
                        if (child is Creature)
                        {
                            (child as Creature).enabled = true;
                        }
                    }
                    gameover.Destroy();
                }
                if (10 < 9)
                {
                    //Here when is started again.
                }
            }

        }
=======
		public void GameOver()
		{
			//Temporarily empty
		}
>>>>>>> Stash
	}
}
