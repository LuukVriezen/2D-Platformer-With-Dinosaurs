using System;
using System.Linq;
using GXPEngine;

namespace GXPEngine
{
	public class Player : Creature
	{
		public int score;
		public int lives;
		private bool invincible;
		private int invincibleMillisecondLimit;
		private int invincibleMillisecondCounter;
		private int blinkLimit;
		private int blinkCounter;
		private bool transparent;

        int oldTime;
        int shootDelay;
        int spriteDelay;
        int oldTimeSprite;

        Sound shootSound;
        Sound playerDeadSound;

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
            spriteDelay = 50;

            shootSound = new Sound("../../Assets/Sounds/cptdinopistols.mp3");
            playerDeadSound = new Sound("../../Assets/Sounds/PlayerDead.mp3");

			//TEMP
			SetSprite(new AnimSprite("../../Assets/IMG/32spritesheetdino.png", 14, 3));
			animationFramesByState.Add(CreatureState.IdleRight, Enumerable.Range(0, 7).ToArray());
			animationFramesByState.Add(CreatureState.IdleLeft, Enumerable.Range(7, 7).ToArray());
			animationFramesByState.Add(CreatureState.JumpRight, Enumerable.Range(14, 5).ToArray());
			animationFramesByState.Add(CreatureState.JumpLeft, Enumerable.Range(23, 5).ToArray());
			animationFramesByState.Add(CreatureState.WalkRight, Enumerable.Range(28, 7).ToArray());
			animationFramesByState.Add(CreatureState.WalkLeft, Enumerable.Range(35, 7).ToArray());
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
			if(Input.GetKey(Key.UP) && grounded)
			{
				ySpeed = -jumpHeight;
				grounded = false;
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
                        playerDeadSound.Play();
                        getParentLevel().isGameOver = true;
					}
					else if(collidableObject is Enemy)
					{
						if((collidableObject as Enemy).state != CreatureState.Dead)
						{
							SubtractLife();
						}
					}
					else if(collidableObject is Projectile)
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
			//Console.WriteLine(grounded);
			if(enabled)
			{
				UpdateInvincibility();
				if(invincible)
				{
					Blink();
				}
					
				//Console.WriteLine("grounded: {0}", grounded);
				//Console.WriteLine("x: {0} - y: {1}", sprite.x, sprite.y);
				CheckMovementInput();
				CheckJumpInput();
				Shoot();
				base.Update();
			}
		}

        private void Shoot()
        {
            if (Input.GetKeyDown(Key.P) && Time.time > (oldTimeSprite + spriteDelay))
            {
                oldTimeSprite = Time.time;
                sprite.SetFrame(0);
                if (Time.time > (oldTime + shootDelay))
                {
                    shootSound.Play();
                    oldTime = Time.time;
					parent.AddChild(new Projectile(this, isFacingRight, 22, 1.5f));
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
                    playerDeadSound.Play();
                    getParentLevel().isGameOver = true;
				}
			}
		}
	}
}

