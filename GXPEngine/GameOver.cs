﻿using System;
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
            Canvas menuCanvas = new Canvas(game.width, game.height);
            menuCanvas.graphics.Clear(Color.Empty);
            menuCanvas.graphics.DrawString("Game Over \nTry Again? " + counter + "", new Font("Arial", 20), Brushes.White, new PointF((game.width / 2) - 200, game.height / 2));
            AddChild(menuCanvas);
        }
    }
}
