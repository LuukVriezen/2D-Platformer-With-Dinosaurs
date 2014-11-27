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

		int oldTime;
		int shootDelay;

        Sound StarSound;
        Sound deadSound;


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
			animationFramesByState.Add(CreatureState.IdleRight, new int[] {0});
			animationFramesByState.Add(CreatureState.IdleLeft, new int[] {0});
			animationFramesByState.Add(CreatureState.WalkRight, new int[] {0});
			animationFramesByState.Add(CreatureState.WalkLeft, new int[] {0});
			animationFramesByState.Add(CreatureState.JumpRight, new int[] {0});
			animationFramesByState.Add(CreatureState.JumpLeft, new int[] {0});
			animationFramesByState.Add(CreatureState.Dead, new int[] {0});

            StarSound = new Sound("../../Assets/Sounds/Star.mp3");
            deadSound = new Sound("../../Assets/Sounds/dyingalien.mp3");
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
            deadSound.Play();
			//Death animation and destruction of enemy

            //score
            getParentLevel().player.score += 100;
		}

		private void AttemptShoot()
		{
			if (Time.time > (oldTime + shootDelay))
			{
                StarSound.Play();
				oldTime = Time.time;
				parent.AddChild(new Projectile(this, !isFacingRight, 12, 0.7f, false));
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
