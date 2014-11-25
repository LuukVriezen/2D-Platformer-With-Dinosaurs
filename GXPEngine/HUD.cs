using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GXPEngine
{
    class HUD : Canvas
    {
        Canvas canvasScore;
        Canvas canvasLives;
        AnimSprite sprite1 = new AnimSprite("../../Assets/IMG/32livesspritesheet.png", 2, 1);
        AnimSprite sprite2 = new AnimSprite("../../Assets/IMG/32livesspritesheet.png", 2, 1);
        AnimSprite sprite3 = new AnimSprite("../../Assets/IMG/32livesspritesheet.png", 2, 1);
        public HUD(int width, int height) : base(width, height)
        {
            canvasScore = new Canvas(width, height);
            canvasLives = new Canvas(width, height);
            this.AddChild(canvasScore);
            this.AddChild(canvasLives);
            this.AddChild(sprite1);
            this.AddChild(sprite2);
            this.AddChild(sprite3);
        }

        public void Score(int score)
        {
            canvasScore.graphics.Clear(Color.Transparent);
            canvasScore.graphics.DrawString("Score: " + score, new Font("Arial", 20), Brushes.White, new PointF(20, 20));
        }

        public void Lives(int lives)
        {
            if (lives == 3)
	        {
                LifeImages(1, 1, 1);
	        }
            else if (lives == 2)
	        {
                LifeImages(1, 1, 0);
	        }
            else if (lives == 1)
	        {
                LifeImages(1, 0, 0);
	        }
            else
            {
                //game over
            }
        }

        public void LifeImages(int sprite1Img, int sprite2Img, int sprite3Img)
        {
            sprite1.SetXY(430, 20);
            sprite2.SetXY(500, 20);
            sprite3.SetXY(570, 20);
            sprite1.SetFrame(sprite1Img);
            sprite2.SetFrame(sprite2Img);
            sprite3.SetFrame(sprite3Img);
            canvasLives.graphics.Clear(Color.Transparent);
            canvasLives.graphics.DrawString("Lives: ", new Font("Arial", 20), Brushes.White, new PointF(350, 35));
        }
    }
}
