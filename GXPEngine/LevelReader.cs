using System;
using System.Xml;

namespace GXPEngine
{
	public class LevelReader
	{
		private XmlDocument document;
		private XmlElement root;
		private string[] cells;

		public LevelReader (string fileName)
		{
			document = new XmlDocument();
			document.Load("../../Levels/" + fileName);
			root = document.DocumentElement;
			cells = root.InnerText.Split(',');
		}

		public int GetWidth()
		{
			int returnWidth = -1;
			int.TryParse(root.GetAttribute("width"), out returnWidth);
			return returnWidth;
		}

		public int GetHeight()
		{
			int returnHeight = -1;
			int.TryParse(root.GetAttribute("height"), out returnHeight);
			return returnHeight;
		}

		public int[,] GetTileData()
		{
			int[,] tileData = new int[GetHeight(), GetWidth()];

			for(int row = 0; row < tileData.GetLength(0); row++)
			{
				for(int col = 0; col < tileData.GetLength(1); col++)
				{
					int tile = 0;
					int.TryParse(cells[(row * GetWidth()) + col], out tile);
					tileData[row, col] = tile;
				}
			}

			return tileData;
		}
	}
}

