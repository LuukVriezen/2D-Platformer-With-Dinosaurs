using System;

namespace GXPEngine
{
	public class Creature : GameObject
	{
		//Movement properties
		protected float xSpeed; //The X distance to move in the current frame
		protected float ySpeed; //The Y distance to move in the current frame
		protected float walkSpeed; //The maximum speed used for walking
		protected float jumpHeight; //The speed to use when jumping

		//Gravity properties
		private float weight; //The Y distance to add each frame
		private float terminalVelocity; //The maximum speed to reach through gravity

		//Misc properties
		private CreatureState state;
		private CreatureSprite sprite;

		public Creature(float weight, float terminalVelocity, float walkSpeed, float jumpHeight)
		{
			//Set default values
			this.xSpeed = 0;
			this.ySpeed = 0;
			this.walkSpeed = walkSpeed;
			this.jumpHeight = jumpHeight;
			this.weight = weight;
			this.terminalVelocity = terminalVelocity;
			this.state = CreatureState.Idle;
			this.sprite = null;
		}

		protected void SetSprite(CreatureSprite sprite)
		{
			this.sprite = sprite;
			this.AddChild(this.sprite);
		}

		private void ApplyGravity()
		{
			//Only apply gravity if ySpeed is not already at or above terminalVelocity
			//If the terminalVelocity is already reached then gravity will do nothing
			if(ySpeed < terminalVelocity)
			{
				//If adding the weight to current ySpeed exceeds the terminalVelocity then set the ySpeed to the terminalVelocity value
				//Otherwise add weight to ySpeed
				ySpeed = (ySpeed + weight > terminalVelocity) ? terminalVelocity : ySpeed + weight;
			}
		}

		protected void Update()
		{
			//ApplyGravity();
			Move(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime);
		}
	}
}

