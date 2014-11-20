using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Enemy : Creature
    {
        bool right = true;
        int maxLengthFixedEnemy = 510;
        public Enemy(float weight, float terminalVelocity, float walkSpeed, float jumpHeight) : base(weight, terminalVelocity, walkSpeed, jumpHeight)
        {
			SetSprite(new AnimSprite("../../Assets/IMG/Ninjalien.png", 1, 1));
        }

        void Update()
        {
            Movement();
        }

        void Movement()
        {
            if (right)
            {
                x = x - 5;
                if (x < maxLengthFixedEnemy)
                {
                    right = false;
                }
            }
            else
            {
                x = x + 5;
                if (x > game.width - sprite.width)
                {
                    right = true;
                }
            }

        }
    }
}
