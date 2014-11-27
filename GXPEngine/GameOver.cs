using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GXPEngine
{
    class GameOver : GameObject
    {
        public GameOver(int counter)
        {
            Canvas gameOverCanvas = new Canvas(game.width, game.height);
            Sprite gameOverSprite = new Sprite("../../Assets/IMG/gameover.png");
            gameOverSprite.width = game.width;
            gameOverSprite.height = game.height-100;
            //gameOverSprite.SetXY( - (gameOverSprite.width - 25), 0);
            gameOverCanvas.graphics.Clear(Color.Empty);
            gameOverCanvas.graphics.DrawString("Try Again? " + counter + "", new Font("Arial", 20), Brushes.White, new PointF((game.width / 2) - 200, game.height / 2));
            AddChild(gameOverSprite);
        }
    }
}
