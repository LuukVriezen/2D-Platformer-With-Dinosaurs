using System;
using System.Drawing;
using System.Collections.Generic;

namespace GXPEngine
{
	public class Creature : GameObject
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
		}

		protected virtual void UpdateCreatureState()
		{
			if(ySpeed != 0)
			{
				state = CreatureState.Jump;
			}
			else if(xSpeed != 0)
			{
				state = CreatureState.Walk;
			}
			else
			{
				state = CreatureState.Idle;
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
			TileObject[] collidableObjects = getParentLevel().GetTileObjectsInTiles(GetOccupyingTiles());

			foreach(TileObject collidableObject in collidableObjects)
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

		protected void Update()
		{
			ApplyGravity();

			preMoveX = this.x;
			preMoveY = this.y;

			float collisionChecksPerFrame = 10;

			for(int i = 0; i < collisionChecksPerFrame; i++)
			{
				Move((xSpeed * Time.deltaTime) / collisionChecksPerFrame,
					(ySpeed * Time.deltaTime) / collisionChecksPerFrame);

				//grounded is false unless proven true in collisions
				grounded = false;
				CheckCollisions();
			}
		}
	}
}

