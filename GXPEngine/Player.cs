using System;

namespace GXPEngine
{
	public class Player : Creature
	{
        Projectile projectile;
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
			}
			else
			if(Input.GetKey(Key.LEFT))
			{
				xSpeed = -walkSpeed;
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
                projectile = new Projectile(this);
                parent.AddChild(projectile);
            }
        }
	}
}

