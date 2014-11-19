using System;

namespace GXPEngine
{
	public class Creature : GameObject
	{
		//Movement properties
		private float xSpeed; //The X distance to move in the current frame
		private float ySpeed; //The Y distance to move in the current frame

		//Gravity properties
		private float weight; //The Y distance to add each frame
		private float terminalVelocity; //The maximum speed to reach through gravity

		//Misc properties
		private CreatureState state;
		private CreatureSprite sprite;

		public Creature ()
		{
			//Set default values
			xSpeed = 0;
			ySpeed = 0;
			state = CreatureState.Idle;
			sprite = null;
		}

		private void SetSprite()
		{
			sprite = new CreatureSprite();
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

		void Update()
		{
			ApplyGravity();
			Move(xSpeed, ySpeed);
		}
	}
}

