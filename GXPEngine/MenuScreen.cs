using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GXPEngine
{
    class MenuScreen : GameObject
    {

        Sprite menusprite;
        Sprite glow;
        bool isKeyDown = false;
        bool isKeyUp = true;

        public bool inGame = true;
        public MenuScreen( )
        {
            glow = new Sprite("../../Assets/IMG/menu light.png");
            menusprite = new Sprite("../../Assets/IMG/Menu.png");

            Canvas menuCanvas = new Canvas(game.width, game.height);
            menusprite.width = game.width;
            menusprite.height = game.height;
            menuCanvas.graphics.Clear(Color.Transparent);
            //menuCanvas.graphics.DrawString("Insert coin(space) to continue", new Font("Arial", 20), Brushes.White, new PointF((game.width/2) - 200, game.height / 2));
            AddChild(glow);
            AddChild(menusprite);
        }

        void Update()
        {
            if (Input.GetKeyDown(Key.DOWN))
            {
                isKeyDown = true;
                isKeyUp = false;
            }
            if (isKeyDown)
            {
                glow.SetXY(0, 178);
                glow.width = 240;
                glow.height = 90;

            }
            if (Input.GetKeyDown(Key.UP))
            {
                isKeyDown = false;
                isKeyUp = true;

            }
            if (isKeyUp)
            {

                glow.SetXY(0, 40);
                glow.width = 240;
                glow.height = 90;
            }
        }

        public bool LeaderBoard()
        {
            if (glow.y == 35)
            {
                return false;
            }
            else if (glow.y == 178 && inGame == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
