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
            //Canvas scoreSectionCanvast = new Canvas(width, height);
            leaderBoardSprite.width = width;
            leaderBoardSprite.height = height;
            AddChild(leaderBoardSprite);
            StreamReader streamReader = new StreamReader("../../Levels/ScoreBoard.txt");
            string line = streamReader.ReadToEnd();
            string[] stringsScore = line.Split(',');
            int position=0;
            for (int i = 0; i < stringsScore.Length; i++)
			{
                position = i * 36 + 100;
                if (stringsScore[i] != null)
                {
                    scoreCanvas.graphics.DrawString("" + stringsScore[i] + "\n", new Font("Arial", 14), Brushes.Gray, new PointF((game.width / 2), position));
                    this.AddChild(scoreCanvas);
                }
            }
            streamReader.Close();
        }

        public void WriteToFile(string name, int score)
        {
            StreamReader streamReader = new StreamReader("../../Levels/ScoreBoard.txt");
            string Fileline = streamReader.ReadToEnd();
            string[] stringScore = Fileline.Split(',');
            int[] intScores = new int[11];
            for (int i = 0; i < stringScore.Length-1; i++)
            {
                if (stringScore[i] != null)
                {
                    intScores[i] = int.Parse(stringScore[i]);
                }
            }
            streamReader.Close();
            intScores[10] = score;
            //Array.Reverse(intScores);
            var sorted = intScores.OrderByDescending(i => i);

            intScores = sorted.ToArray();

            File.WriteAllText("../../Levels/ScoreBoard.txt", String.Empty);
            StreamWriter sw = new StreamWriter("../../Levels/ScoreBoard.txt");
            for (int i = 0; i < intScores.Length -1; i++)
            {
                sw.Write("{0},", intScores[i]);
            }

            sw.Close();
        }

    }
}
