using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GXPEngine
{
    class Projectile : GameObject
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
        
        //Rainbow bullet en beam
        Sprite pistolBullet = new Sprite("../../Assets/IMG/32DinoProjectile.png");
        //Hit test sprite
        //Sprite hitWall = new Sprite("../../Assets/IMG/colors.png");

        public Projectile(Creature creature, bool isRight)
        {
            AddChild(pistolBullet);
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
                pistolBullet.SetXY(creature.x + creature.sprite.width, creature.y + pistolHeight);
            }
            else
            {
                pistolBullet.SetXY(creature.x - pistolBullet.width, creature.y + pistolHeight);
            }

            _isRight = isRight;

            pistolStart = pistolBullet.x;


            originX = _player.getParentLevel().x;
            originY = _player.getParentLevel().y;

            //AddChild(hitWall);
            //hitWall.SetXY(game.width - hitWall.width - 200, game.height -hitWall.height);

        }

        public void Update()
        {
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

                if (!(pistolBullet.x < 0) && !(pistolBullet.x > _player.getParentLevel().width) && (Enumerable.Range((int)pistolStart, shakeLength).Contains((int)pistolBullet.x)) || _isRight == false && (pistolStart - shakeLength) < pistolBullet.x)
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
                pistolBullet.x = (_player.x + _player.sprite.width) + xSpeed;
            }
            else
            {
                xSpeed = xSpeed - 25;
                pistolBullet.x = (_player.x - pistolBullet.width) + xSpeed;
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
            if (pistolBullet.x < _player.getParentLevel().width)
            {
                stopShot = true;
            }
            else
            {
                //pistolBullet.SetXY(_player.x, _player.y);
                xSpeed = 0;
                stopShot = false;
                pistolBullet.Destroy();
            }

        }

        public void BeamShot()
        {
            Sprite beam = DubstepBeam();
            xSpeed = xSpeed + 5;
            pistolBullet.x = xSpeed;
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
            beam.SetXY(pistolBullet.x, pistolBullet.y);
            beam.rotation = rotation;
            return beam;
        }
    }
}
