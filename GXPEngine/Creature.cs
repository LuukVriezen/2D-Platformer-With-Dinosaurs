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

		//Gravity properties
		private float weight; //The Y distance to add each frame
		private float terminalVelocity; //The maximum speed to reach through gravity

		//Misc properties
		private CreatureState state;
		public CreatureSprite sprite;
		private float preMoveX;
		private float preMoveY;


		public Creature(float weight, float terminalVelocity, float walkSpeed, float jumpHeight)
		{
			//Set default values
			this.xSpeed = 0;
			this.ySpeed = 0;
			this.preMoveX = this.x;
			this.preMoveY = this.y;
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

						//Push Left
						if(x + sprite.width < platform.x + platform.sprite.width && x + sprite.width > platform.x)
						{
							x -= (x + sprite.width) - platform.x;
							xSpeed = 0;
						}

						//Push Right
						else if(x < platform.x + platform.sprite.width && x > platform.x)
						{
							x += x - (platform.x + platform.sprite.width);
							xSpeed = 0;
						}

						//Push Up
						if(y + sprite.height < platform.y + platform.sprite.height && y + sprite.height > platform.y)
						{
							y -= (y + sprite.height) - platform.y;
							ySpeed = 0;
						}

						//Push Down
						else if(y < platform.y + platform.sprite.height && y > platform.y)
						{
							y += y - (platform.y + platform.sprite.height);
							ySpeed = 0;
						}
					}
				}
			}
		}

		protected void Update()
		{
			//ApplyGravity();
			Move(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime);
			CheckCollisions();
		}
	}
}

