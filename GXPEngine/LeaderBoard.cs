using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace GXPEngine
{
    class LeaderBoard : GameObject
    {
        public LeaderBoard(int width, int height)
        {
            Sprite leaderBoardSprite = new Sprite("../../Assets/IMG/Leaderboard.png");
            Canvas scoreCanvas = new Canvas(width, height);
            leaderBoardSprite.width = width;
            leaderBoardSprite.height = height;
            AddChild(leaderBoardSprite);
            StreamReader streamReader = new StreamReader("../../Levels/ScoreBoard.txt");


            string line = streamReader.ReadToEnd();
            string[] score = line.Split(',');

            for (int i = 0; i < score.Length; i++)
			{
                if (score[i] != null)
                {
                    scoreCanvas.graphics.DrawString("" + score[i] + "\n", new Font("Arial", 24), Brushes.White, new PointF((game.width / 2), 200));
                    this.AddChild(scoreCanvas);
                }
            }
            streamReader.Close();
        }

        public void ReadToFile(string name, int score)
        {
            StreamWriter sw = new StreamWriter("../../Levels/ScoreBoard.txt");

            sw.WriteLine("{1}\n",score);

            sw.Close();
        }

    }
}
