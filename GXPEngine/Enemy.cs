using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Enemy : Creature
    {
        public Enemy(float weight, float terminalVelocity, float walkSpeed, float jumpHeight) : base(weight, terminalVelocity, walkSpeed, jumpHeight)
        {
			SetSprite(new AnimSprite("../../Assets/IMG/Ninjalien.png", 1, 1));
        }

        void Movement()
        {

        }
    }
}
