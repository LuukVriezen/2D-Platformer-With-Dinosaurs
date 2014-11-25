using System;

namespace GXPEngine
{
	public class Player : Creature
	{
        private Projectile projectile;
        private bool isFacingRight = true;
		public int score;
		public int lives;
		private bool invincible;
		private int invincibleMillisecondLimit;
		private int invincibleMillisecondCounter;
		private int blinkLimit;
		private int blinkCounter;
		private bool transparent;

        int shootDelay;
        int oldTime;

		public Player (float weight, float terminalVelocity, float walkSpeed, float jumpHeight) : base(weight, terminalVelocity, walkSpeed, jumpHeight)
		{
			score = 0;
			lives = 3;
			invincible = false;
			invincibleMillisecondLimit = 2000;
			invincibleMillisecondCounter = 0;
			blinkLimit = 100;
			blinkCounter = blinkLimit;
			transparent = false;
            shootDelay = 500;

			//TEMP
			SetSprite(new AnimSprite("../../Assets/IMG/32spritesheetdino.png", 6, 6));
			animationFramesByState.Add(CreatureState.Idle, new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8});
			animationFramesByState.Add(CreatureState.Walk, new int[] {12, 13, 14, 15, 16, 17, 18, 19, 20});
			animationFramesByState.Add(CreatureState.Jump, new int[] {24, 25, 26, 27, 28, 29});
			//TEMPEND
		}

		private void CheckMovementInput()
		{
			if(Input.GetKey(Key.RIGHT))
			{
				xSpeed = walkSpeed;
                isFacingRight = true;
			}
			else
			if(Input.GetKey(Key.LEFT))
			{
				xSpeed = -walkSpeed;
                isFacingRight = false;
			}
			else
			{
				float speedMutation = Math.Abs(xSpeed) < 0.05f ? xSpeed : xSpeed * 0.2f;
				xSpeed -= speedMutation;
			}
		}

		private void CheckJumpInput()
		{
			if(Input.GetKeyDown(Key.UP))
			{
				ySpeed = -jumpHeight;
			}
		}

		protected override void CheckCollisions()
		{
			SpriteObject[] collidableObjects = getParentLevel().GetCollidableObjectsInTiles(GetOccupyingTiles());

			foreach(SpriteObject collidableObject in collidableObjects)
			{
				bool hitTest;

				if(collidableObject is Enemy)
				{
					hitTest = sprite.HitTest((collidableObject as Enemy).sprite);
				}
				else
				{
					hitTest = sprite.HitTest(collidableObject.sprite);
				}

				if(hitTest)
				{
					if(collidableObject is Platform)
					{
						Platform platform = collidableObject as Platform;

						//Push Up
						if(preMoveY < y && y + sprite.height < platform.y + platform.sprite.height && y + sprite.height > platform.y)
						{
							y -= (y + sprite.height) - platform.y;
							ySpeed = 0;
							grounded = true;
						}
					}
					else if(collidableObject is Collectable)
					{
						getParentLevel().player.score += (collidableObject as Collectable).TreasurePoints();
						getParentLevel().RemoveChild(collidableObject);
					}
					else if(collidableObject is Lava)
					{
						getParentLevel().GameOver();
					}
					else if(collidableObject is Enemy)
					{
						SubtractLife();

					}
				}
			}
		}

		private void UpdateInvincibility()
		{
			if(invincible && invincibleMillisecondCounter <= invincibleMillisecondLimit)
			{
				invincibleMillisecondCounter += Time.deltaTime;
			}
			else
			{
				invincible = false;
				invincibleMillisecondCounter = 0;
				blinkCounter = blinkLimit;
				transparent = false;
				sprite.alpha = 1;
			}
		}

		public void Blink()
		{
			if(blinkCounter <= blinkLimit)
			{
				blinkCounter += Time.deltaTime;
			}
			else
			{
				transparent = !transparent;
				sprite.alpha = transparent ? 0.3f : 1;
				blinkCounter = 0;
			}
		}

		new void Update()
		{
            if (enabled)
            {
                UpdateInvincibility();
                if (invincible)
                {
                    Blink();
                }

                Console.WriteLine("invincible: {0}", invincible);
                if (!isFacingRight)
                {
                    sprite.Mirror(true, false);
                }
                else
                {
                    sprite.Mirror(false, false);
                }
                CheckMovementInput();
                CheckJumpInput();
                Shoot();
                base.Update();
            }
		}

        private void Shoot()
        {
            if (Input.GetKeyDown(Key.P) && Time.time > (oldTime + shootDelay))
            {
                oldTime = Time.time;
                if (isFacingRight)
                {
                    projectile = new Projectile(this, true);
                    parent.AddChild(projectile);
                }
                else
                {
                    projectile = new Projectile(this, false);
                    parent.AddChild(projectile);
                }

            }
        }

		private void SubtractLife()
		{
			if(!invincible)
			{
				lives--;
				if(lives > 0)
				{
					invincible = true;
				}
				else
				{
					getParentLevel().GameOver();
				}
			}
		}
	}
}

