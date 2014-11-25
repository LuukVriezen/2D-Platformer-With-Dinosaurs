using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GXPEngine
{
    class MessageBox : Canvas
    {
        //This is not complete. This also needs to be possible to give feedback above the player
        public MessageBox(int width, int height) : base(width, height)
        {
        }

        public void Message()
        {
            graphics.Clear(Color.Transparent);
            graphics.DrawString("Here is possible to make tekst onder the ground", new Font("Arial", 20), Brushes.White, new PointF(0, 400));
        }
    }
}
