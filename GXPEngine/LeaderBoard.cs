using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace GXPEngine
{
    class LeaderBoard : Canvas
    {
        public LeaderBoard(int width, int height) : base(width, height)
        {
            //Sprite leaderBoardSprite = new Sprite();
            StreamReader streamReader = new StreamReader("../../Level/ScoreBoard.txt");

            string line = streamReader.ReadLine();

			while (line != null) 
			{
                graphics.DrawString(""+ line + "", new Font("Arial", 20), Brushes.White, new PointF((game.width / 2) - 200, game.height / 2));
				Console.WriteLine(line);
				line = streamReader.ReadLine();
			}
            
			streamReader.Close();
        }

        public void ReadToFile(string name, int score)
        {
            StreamWriter sw = new StreamWriter("../../Level/ScoreBoard.txt");

            sw.WriteLine("Name: {0} Score: {1}\n", name, score);

            sw.Close();
        }

    }
}
