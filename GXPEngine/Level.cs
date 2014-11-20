using System;
using System.Drawing;
using System.Collections.Generic;

namespace GXPEngine
{
	public class Level : GameObject
	{
		private int[,] tileData;
		public int tileSize;
        Player player;

		public Level(/*Temporarily disabled: int tilesX, int tilesY*/)
		{
			//Set default values
			tileSize = 32;

			//Temporarily disabled: tileData = new int[tilesX, tilesY];

			//TEMP
			//0 = nothing
			//1 = platform
			//2 = player
			tileData = new int[,] {
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 10, 12, 11, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 11, 13, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 10, 11, 12, 11, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5 },
				{ 0, 0, 0, 0, 4, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 20, 21, 22, 23, 21, 22, 23, 24, 15, 15, 15, 20, 21, 23, 24, 15, 20, 23, 21, 24 }
			};
			//TEMPEND
			
			FillLevel();
		}

		public void FillLevel()
		{
			for (int x = 0; x < tileData.GetLength(1); x++) {
				for (int y = 0; y < tileData.GetLength(0); y++) {
					switch(tileData[y, x])
					{
						case 1:
							Platform platform = new Platform(new Point(x, y));
							platform.SetXY(x * tileSize, y * tileSize);
							this.AddChild(platform);
							break;

						case 2:
							player = new Player(0.1f, 2, 0.8f, 1.5f);
							player.SetXY(x * tileSize, y * tileSize);
							this.AddChild(player);
							break;

                        case 3:
                            Collectable collectable = new Collectable();
                            collectable.treasure.SetXY(x * tileSize, y * tileSize);
                            this.AddChild(collectable.treasure);
							break;
                        case 5:
                            Enemy enemy = new Enemy(0.1f, 2, 0.8f, 1.5f);
                            enemy.SetXY(x * tileSize, y * tileSize);
                            this.AddChild(enemy);
                            break;
                        //Tree Tiles
                        case 10:
                            Platform platform10 = new Platform(new Point(x, y));
                            platform10.SetXY(x * tileSize, y * tileSize);
                            platform10.SetSprite(new Sprite("../../Assets/IMG/32branches3.png"));
                            this.AddChild(platform10);
                            break;
                        case 11:
                            Platform platform11 = new Platform(new Point(x, y));
                            platform11.SetXY(x * tileSize, y * tileSize);
                            platform11.SetSprite(new Sprite("../../Assets/IMG/32branches2.png"));
                            this.AddChild(platform11);
                            break;
                        case 12:
                            Platform platform12 = new Platform(new Point(x, y));
                            platform12.SetXY(x * tileSize, y * tileSize);
                            platform12.SetSprite(new Sprite("../../Assets/IMG/32branches1.png"));
                            this.AddChild(platform12);
                            break;
                        case 13:
                            Platform platform13 = new Platform(new Point(x, y));
                            platform13.SetXY(x * tileSize, y * tileSize);
                            platform13.SetSprite(new Sprite("../../Assets/IMG/32branches4.png"));
                            this.AddChild(platform13);
                            break;
                        //Lava Tiles
                        case 15:
                            Platform platform15 = new Platform(new Point(x, y));
                            platform15.SetXY(x * tileSize, y * tileSize);
                            platform15.SetSprite(new Sprite("../../Assets/IMG/32Lava.png"));
                            this.AddChild(platform15);
                            break;
                        //Ground Tiles
                        case 20:
                            Platform platform20 = new Platform(new Point(x, y));
                            platform20.SetXY(x * tileSize, y * tileSize);
                            platform20.SetSprite(new Sprite("../../Assets/IMG/32ground1.png"));
                            this.AddChild(platform20);
                            break;
                        case 21:
                            Platform platform21 = new Platform(new Point(x, y));
                            platform21.SetXY(x * tileSize, y * tileSize);
                            platform21.SetSprite(new Sprite("../../Assets/IMG/32ground2.png"));
                            this.AddChild(platform21);
                            break;
                        case 22:
                            Platform platform22 = new Platform(new Point(x, y));
                            platform22.SetXY(x * tileSize, y * tileSize);
                            platform22.SetSprite(new Sprite("../../Assets/IMG/32ground3.png"));
                            this.AddChild(platform22);
                            break;
                        case 23:
                            Platform platform23 = new Platform(new Point(x, y));
                            platform23.SetXY(x * tileSize, y * tileSize);
                            platform23.SetSprite(new Sprite("../../Assets/IMG/32ground4.png"));
                            this.AddChild(platform23);
                            break;
                        case 24:
                            Platform platform24 = new Platform(new Point(x, y));
                            platform24.SetXY(x * tileSize, y * tileSize);
                            platform24.SetSprite(new Sprite("../../Assets/IMG/32ground5.png"));
                            this.AddChild(platform24);
                            break;

						default:
							break;
					}
				}
			}
		}

		public TileObject[] GetTileObjectsInTiles(Point[] tiles)
		{
			List<TileObject> tileObjects = new List<TileObject>();
			List<GameObject> children = GetChildren();
			foreach(GameObject child in children)
			{
				if(child is TileObject && Array.IndexOf(tiles, (child as TileObject).tileCoordinates) != -1)
				{
					tileObjects.Add(child as TileObject);
				}
			}
			return tileObjects.ToArray();
		}

        void Update()
        {
            ShakeShot();
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
                if (player.y + x > 300)
                {
                    y = 300 - player.y;
                }
                if (player.x + x < 100)
                {
                    y = 100 - player.y;
                }
            }
        }


        public void ShakeShot()
        {
            
        }
	}
}

