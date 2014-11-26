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

		private int health;

        public Enemy(float weight, float terminalVelocity, float walkSpeed, float jumpHeight) : base(weight, terminalVelocity, walkSpeed, jumpHeight)
        {
			//TEMP
			health = 2;
			//TEMPEND
			SetSprite(new AnimSprite("../../Assets/IMG/Ninjalien.png", 1, 1));
			animationFramesByState.Add(CreatureState.Idle, new int[] {0});
			animationFramesByState.Add(CreatureState.Walk, new int[] {0});
			animationFramesByState.Add(CreatureState.Jump, new int[] {0});
        }

		public void TakeDamage(int damage)
		{
			health -= damage;
			if(health <= 0)
			{
				Die();
			}
		}

		private void Die()
		{
			Console.WriteLine("DEAD");
			//Death animation and destruction of enemy
		}

        void Update()
        {
            if (enabled)
            {
                //Movement();
			    base.Update();
            }
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
