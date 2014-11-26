using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Background : GameObject
    {
        Sprite background;
        AnimSprite trees;

        float frame = 0.0f;
        int firstFrame = 0;
        int lastFrame = 15;

        public Background(int width, int height)
        {
            Canvas canvas = new Canvas(width, height);
            background = new Sprite("../../Assets/IMG/background.jpg");
            background.width = width;
            background.height = height;
            AddChild(background);
            
            trees = new AnimSprite("../../Assets/IMG/Background 2D.png",1,14);
            trees.width = width*2;
            trees.height = game.height / 2;
            trees.y = game.height - trees.height;
            AddChild(trees);
        }

        public void BackgroundAnimation()
        {

            frame = frame + 0.09f;
            if (frame >= lastFrame + 1)
            {
                frame = firstFrame;
            }
            if (frame < firstFrame)
            {
                frame = lastFrame;
            }
            trees.SetFrame((int)frame);

        }
    }
}
