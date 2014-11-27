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
		EnemyType type;
		int sightRange;
		bool isFacingRight;

		int oldTime;
		int shootDelay;


		private int health;

        public Enemy(float weight, float terminalVelocity, float walkSpeed, float jumpHeight) : base(weight, terminalVelocity, walkSpeed, jumpHeight)
        {
			//TEMP
			health = 2;
			type = EnemyType.Standard;
			sightRange = 300;
			isFacingRight = false;
			oldTime = 0;
			shootDelay = 500;
			//TEMPEND
			SetSprite(new AnimSprite("../../Assets/IMG/Ninjalien.png", 1, 1));
			animationFramesByState.Add(CreatureState.Idle, new int[] {0});
			animationFramesByState.Add(CreatureState.Walk, new int[] {0});
			animationFramesByState.Add(CreatureState.Jump, new int[] {0});
			animationFramesByState.Add(CreatureState.Dead, new int[] {0});
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
			state = CreatureState.Dead;
			//Death animation and destruction of enemy
		}

		private void AttemptShoot()
		{
			if (Time.time > (oldTime + shootDelay))
			{
				oldTime = Time.time;
				parent.AddChild(new Projectile(this, !isFacingRight,  12, false));
			}
		}

		private void CheckPlayerDetection()
		{
			Player player = getParentLevel().player;
			int playerCenterX = (int)player.x + (player.sprite.width / 2);
			int playerCenterY = (int)player.y + (player.sprite.height / 2);

			if(((playerCenterX >= x - sightRange && playerCenterX <= x)
			   || (playerCenterX >= x + sprite.width && playerCenterX <= x + sprite.width + sightRange))
			   && (playerCenterY >= y && playerCenterY <= y + sprite.height))
			{
				isFacingRight = playerCenterX < x;
				AttemptShoot();
			}
		}

        void Update()
        {
            if (enabled)
            {
				if(!isFacingRight)
				{
					sprite.Mirror(true, false);
				}
				else
				{
					sprite.Mirror(false, false);
				}

				CheckPlayerDetection();

				if(type == EnemyType.Standard)
				{

				}
				if(state != CreatureState.Dead)
				{
					//Movement();
					base.Update();
				}
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
