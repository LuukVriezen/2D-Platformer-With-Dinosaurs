﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GXPEngine
{
    class MenuScreen : GameObject
    {
        public MenuScreen()
        {
            Canvas menuCanvas = new Canvas(game.width, game.height);
            menuCanvas.graphics.Clear(Color.Empty);
            menuCanvas.graphics.DrawString("Insert coin to continue", new Font("Arial", 20), Brushes.White, new PointF((game.width/2) - 150, game.height / 2));
            AddChild(menuCanvas);
        }
    }
}