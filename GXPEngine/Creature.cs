using System;
using System.Drawing;
using System.Collections.Generic;

namespace GXPEngine
{
	public class Creature : SpriteObject
	{
		//Movement properties
		protected float xSpeed; //The X distance to move in the current frame
		protected float ySpeed; //The Y distance to move in the current frame
		protected float walkSpeed; //The maximum speed used for walking
		protected float jumpHeight; //The speed to use when jumping
		protected bool grounded; //Whether the creature is currently hitting the ground

		//Gravity properties
		private float weight; //The Y distance to add each frame
		private float terminalVelocity; //The maximum speed to reach through gravity

		//Misc properties
		protected CreatureState state;
		public AnimSprite sprite;
		protected float preMoveX;
		protected float preMoveY;

		//Animation properties
		protected Dictionary<CreatureState, int[]> animationFramesByState;
		protected int[] currentAnimationFrames;
		protected float currentAnimationFramesIndex;

        public bool enabled;


		public Creature(float weight, float terminalVelocity, float walkSpeed, float jumpHeight)
		{
			//Set default values
			this.xSpeed = 0;
			this.ySpeed = 0;
			this.preMoveX = this.x;
			this.preMoveY = this.y;
			this.walkSpeed = walkSpeed;
			this.jumpHeight = jumpHeight;
			this.grounded = false;
			this.weight = weight;
			this.terminalVelocity = terminalVelocity;
			this.state = CreatureState.Idle;
			this.sprite = null;
			this.animationFramesByState = new Dictionary<CreatureState, int[]>();
			this.currentAnimationFrames = new int[0];
			this.currentAnimationFramesIndex = 0;
            this.enabled = true;
		}

		protected virtual CreatureState GetCreatureState()
		{
			if(ySpeed != 0)
			{
				return CreatureState.Jump;
			}
			else if(xSpeed != 0)
			{
				return CreatureState.Walk;
			}
			else
			{
				return CreatureState.Idle;
			}
		}

		protected void SetSprite(AnimSprite sprite)
		{
			this.sprite = sprite;
			this.AddChild(this.sprite);
		}

		private void ApplyGravity()
		{
			//Only apply gravity if ySpeed is not already at or above terminalVelocity
			//If the terminalVelocity is already reached then gravity will do nothing
			if(ySpeed < terminalVelocity || grounded)
			{
				//If adding the weight to current ySpeed exceeds the terminalVelocity then set the ySpeed to the terminalVelocity value
				//Otherwise add weight to ySpeed
				ySpeed = (ySpeed + weight > terminalVelocity) ? terminalVelocity : ySpeed + weight;
			}
		}

		public Level getParentLevel()
		{
			return parent as Level;
		}

		public Point[] GetOccupyingTiles()
		{
			int tileSize = 0;
			List<Point> occupyingTiles = new List<Point>();

			try
			{
				tileSize = getParentLevel().tileSize;
			}
			catch
			{
				//TODO: Error handling
			}

			Point topLeftCoordinates = new Point((int)x / tileSize, (int)y / tileSize);
			Point bottomRightCoordinates = new Point(((int)x + sprite.width) / tileSize, ((int)y + sprite.height) / tileSize);

			for(int tileX = topLeftCoordinates.X; tileX <= bottomRightCoordinates.X; tileX++)
			{
				for(int tileY = topLeftCoordinates.Y; tileY <= bottomRightCoordinates.Y; tileY++)
				{
					occupyingTiles.Add(new Point(tileX, tileY));
				}
			}

			return occupyingTiles.ToArray();
		}

		protected virtual void CheckCollisions()
		{
			SpriteObject[] collidableObjects = getParentLevel().GetCollidableObjectsInTiles(GetOccupyingTiles());

			foreach(SpriteObject collidableObject in collidableObjects)
			{
				if(sprite.HitTest(collidableObject.sprite))
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
				}
			}
		}

		protected void SetCreatureState(CreatureState state)
		{
			this.state = state;
			currentAnimationFrames = animationFramesByState[state];
			currentAnimationFramesIndex = 0;
		}

		protected void ApplyAnimation()
		{
			currentAnimationFramesIndex += 0.01f * Time.deltaTime;
			if((int)currentAnimationFramesIndex >= currentAnimationFrames.Length)
			{
				currentAnimationFramesIndex = 0;
			}

			sprite.SetFrame(currentAnimationFrames[(int)currentAnimationFramesIndex]);
		}

		protected void Update()
		{
            if (enabled)
            {
                CreatureState newState = GetCreatureState();
                if (state != newState || currentAnimationFrames.Length <= 0)
                {
                    SetCreatureState(newState);
                }

                ApplyAnimation();

                if (!grounded)
                {
                    ApplyGravity();
                }

                GameBoundaries();

                preMoveX = this.x;
                preMoveY = this.y;

                float collisionChecksPerFrame = 3;

                for (int i = 0; i < collisionChecksPerFrame; i++)
                {
                    Move((xSpeed * Time.deltaTime) / collisionChecksPerFrame,
                        (ySpeed * Time.deltaTime) / collisionChecksPerFrame);

                    //grounded is false unless proven true in collisions
                    grounded = false;
                    CheckCollisions();
                }
            }
		}

        private void GameBoundaries()
        {
            if (x < 0) x = 0;
			if (x > getParentLevel().width - sprite.width) x = getParentLevel().width - sprite.width;
            y = y + ySpeed;
            if (y < 0) y = 0;
			if (y > getParentLevel().height - sprite.height) y = getParentLevel().height - sprite.height;
        }
	}
}

