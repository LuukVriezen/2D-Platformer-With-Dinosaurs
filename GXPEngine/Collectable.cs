﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class Collectable : TileObject
    {
        Random random = new Random();
        int score = 0;
        float frame = 0.0f;
        int firstFrame = 0;
        int lastFrame = 7;

        int framecounter = 0;
        
		public Collectable(Point tileCoordinates) : base(tileCoordinates)
        {
            //TEMP
            SetSprite(new AnimSprite("../../Assets/IMG/tresure-chest-spritesheet.png", 4, 2));
			//TEMPEND
        }

        void Update()
        {
            if (framecounter < 8)
            {
                TreasureAnimation();
            }
            else
            {
                sprite.SetFrame(7);
                framecounter = 0;
            }
        }

        public int TreasureAnimation()
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
            sprite.SetFrame((int)frame);
            return (int)frame;
        }

        public int TreasurePoints()
        {
            //When a treasure is hit.
            score = score + random.Next(100, 501);

            return score;
        }
    }
}
