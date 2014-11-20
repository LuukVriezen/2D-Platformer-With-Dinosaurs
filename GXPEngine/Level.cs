﻿using System;
using System.Drawing;
using System.Collections.Generic;

namespace GXPEngine
{
	public class Level : Canvas
	{
		private int[,] tileData;
		public int tileSize;
		public int score;

		public Level(/*Temporarily disabled: int tilesX, int tilesY*/ int width, int height) : base(width, height)
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
				{ 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5 },
				{ 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1 }
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
							Player player = new Player(0.1f, 2, 0.8f, 1.5f);
							player.SetXY(x * tileSize, y * tileSize);
							this.AddChild(player);
							break;

						case 3:
							Collectable collectable = new Collectable(new Point(x, y));
							collectable.SetXY(x * tileSize, y * tileSize);
                            this.AddChild(collectable);
							break;

                      
                        case 5:
                            Enemy enemy = new Enemy(0.1f, 2, 0.8f, 1.5f);
                            enemy.SetXY(x * tileSize, y * tileSize);
                            this.AddChild(enemy);
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
			Console.WriteLine("Score: {0}", score);
		}
	}
}

