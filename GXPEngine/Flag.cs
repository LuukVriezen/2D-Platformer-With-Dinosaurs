using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Flag : SpriteObject
    {
        float frame = 0.0f;
        int firstFrame = 0;
        int lastFrame = 1;
        public Flag() : base()
        {
            SetSprite(new AnimSprite("../../Assets/IMG/flag.png", 2, 1));
            AddChild(sprite);
        }

        void Update()
        {
            UpdateSprite();
        }

        void UpdateSprite()
        {
            frame = frame + 0.05f;
            if (frame >= lastFrame + 1)
            {
                frame = firstFrame;
            }
            if (frame < firstFrame)
            {
                frame = lastFrame;
            }
            sprite.SetFrame((int)frame);
        }
    }
}
