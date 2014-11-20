using System;

namespace GXPEngine
{
	public class Player : Creature
	{
        private Projectile projectile;
        private bool isFacingRight = true;
		public Player (float weight, float terminalVelocity, float walkSpeed, float jumpHeight) : base(weight, terminalVelocity, walkSpeed, jumpHeight)
		{
			//TEMP
			SetSprite(new CreatureSprite("../../Assets/IMG/player32.png", 1, 1));
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
				xSpeed = 0;
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
			base.CheckCollisions();
		}

		new void Update()
		{
			CheckMovementInput();
			CheckJumpInput();
            Shoot();
			base.Update();
		}

        private void Shoot()
        {
            if (Input.GetKeyDown(Key.P))
            {
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
	}
}

