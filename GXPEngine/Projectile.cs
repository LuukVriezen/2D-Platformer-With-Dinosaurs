using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GXPEngine
{
	class Projectile : SpriteObject
    {
        //Fields of Projectile
        float xSpeed = 0.0f;
        //float ySpeed = 0.0f;
        bool stopBeam = false;
        bool stopShot = true;
        private bool _isRight = true;
        private Player _player;
        private Enemy _enemy;

        float originX = 0;
        float originY = 0;

        bool notDoneYet = true;
        //private Platform platform = new Platform();
        //delay
        //back by firing

        //Pistol hight and width from the picture
        int pistolHeight = 22;
        int pistolWidth = 0;

        int shakeLength = 200;
        int minShakeLength = -10;

        float pistolStart;
        
        //Hit test sprite
        //Sprite hitWall = new Sprite("../../Assets/IMG/colors.png");

		public int damage;

        public Projectile(Creature creature, bool isRight)
        {
			sprite = new AnimSprite("../../Assets/IMG/32DinoProjectile.png", 1, 1);

            AddChild(sprite);
            if (creature is Player)
            {
                _player = (Player)creature;
            }
            else if (creature is Enemy)
            {
                _enemy = (Enemy)creature;
            }
            if (isRight)
            {
                sprite.SetXY(creature.x + creature.sprite.width, creature.y + pistolHeight);
            }
            else
            {
                sprite.SetXY(creature.x - sprite.width, creature.y + pistolHeight);
            }

            _isRight = isRight;

            pistolStart = sprite.x;


            originX = _player.getParentLevel().x;
            originY = _player.getParentLevel().y;

            //AddChild(hitWall);
            //hitWall.SetXY(game.width - hitWall.width - 200, game.height -hitWall.height);

			//TEMP
			damage = 1;
			//TEMPEND

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

		private void CheckCollisions()
		{
			SpriteObject[] collidableObjects = getParentLevel().GetCollidableObjectsInTiles(GetOccupyingTiles());

			foreach(SpriteObject collidableObject in collidableObjects)
			{
				if(sprite.HitTest(collidableObject.sprite))
				{
					if(collidableObject is Enemy)
					{
						(collidableObject as Enemy).TakeDamage(damage);
						RemoveProjectile();
					}
				}
			}
		}

        public void Update()
        {
			CheckCollisions();
            if (/*Input.GetKeyDown(Key.P) ||*/ stopShot)
            {
                GunShot();
                ShakeShot();
            }
            //if (Input.GetKeyDown(Key.B) || stopBeam)
            //{
            //    BeamShot();
            //}
        }

        public void ShakeShot()
        {
            Random random = new Random();

            if (notDoneYet)
            {

                if (!(sprite.x < 0) && !(sprite.x > _player.getParentLevel().width) && (Enumerable.Range((int)pistolStart, shakeLength).Contains((int)sprite.x)) || _isRight == false && (pistolStart - shakeLength) < sprite.x)
                {
                    _player.getParentLevel().x = _player.getParentLevel().x + random.Next(-10, 10);
                    _player.getParentLevel().y = _player.getParentLevel().y + random.Next(-10, 10);

                    stopShot = true;
                    notDoneYet = true;
                }
                else
                {
                    _player.getParentLevel().x = originX;
                    _player.getParentLevel().y = originY;
                    notDoneYet = false;
                }
            }
        }

        public void GunShot()
        {
            if (_isRight)
            {
                xSpeed = xSpeed + 25;
                sprite.x = (_player.x + _player.sprite.width) + xSpeed;
            }
            else
            {
                xSpeed = xSpeed - 25;
                sprite.x = (_player.x - sprite.width) + xSpeed;
            }
            //Console.WriteLine(pistolBullet.x);
            //Check collision with an object.
            /*if (pistolBullet.HitTest(hitWall))
            {
                hitWall.Destroy();
                pistolBullet.SetXY(_player.x, _player.y);
                xSpeed = 0;
                stopShot = false;
            }
            else*/
            if (sprite.x < _player.getParentLevel().width)
            {
                stopShot = true;
            }
            else
            {
				RemoveProjectile();
            }

        }

		public void RemoveProjectile()
		{
			//pistolBullet.SetXY(_player.x, _player.y);
			xSpeed = 0;
			stopShot = false;
			sprite.Destroy();
		}

        public void BeamShot()
        {
            Sprite beam = DubstepBeam();
            xSpeed = xSpeed + 5;
            sprite.x = xSpeed;
            /*
            if (pistolBullet.HitTest(hitWall))
            {
                hitWall.Destroy();
                pistolBullet.SetXY(0, game.height / 2);
                //beam.Destroy();
                stopBeam = false;
                xSpeed = 0;
            }
            else
            {*/
                stopBeam = true;
            //}
        }

        public Sprite DubstepBeam()
        {
            Beam beam = new Beam();
            parent.AddChild(beam);
            beam.SetXY(sprite.x, sprite.y);
            beam.rotation = rotation;
            return beam;
        }
    }
}
