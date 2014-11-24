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

        float originX = 0;
        float originY = 0;

        bool notDoneYet = true;
        //private Platform platform = new Platform();
        //delay
        //back by firing

        //Pistol hight and width from the picture
        int pistolHeight = 10;
        int pistolWidth = 0;

        int shakeLength = 200;
        int minShakeLength = -500;

        float pistolStart;
        
        //Rainbow bullet en beam
        Sprite pistolBullet = new Sprite("../../Assets/IMG/bullit.png");
        //Hit test sprite
        //Sprite hitWall = new Sprite("../../Assets/IMG/colors.png");

        public Projectile(Player player, bool isRight)
        {
            AddChild(pistolBullet);
            if (isRight)
            {
                pistolBullet.SetXY(player.x + player.sprite.width, player.y + pistolHeight);
            }
            else
            {
                pistolBullet.SetXY(player.x - pistolBullet.width, player.y + pistolHeight);
            }
            _player = player;
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
            Console.WriteLine("PistolStart: " + pistolStart);
            Console.WriteLine("shakeLength: " + shakeLength);
            Console.WriteLine("pistolBullet: " + pistolBullet.x);
            if (notDoneYet)
            {
                if (!(pistolBullet.x < 0) && (Enumerable.Range((int)pistolStart, shakeLength).Contains((int)pistolBullet.x)))
                {
                    _player.getParentLevel().x = random.Next(-25, 25);
                    _player.getParentLevel().y = random.Next(-25, 25);
                    stopShot = true;
                    notDoneYet = true;
                }
                else if (pistolBullet.x < 0)
                {
                    
                }
                //else if ((Enumerable.Range((int)pistolStart, minShakeLength).Contains((int)pistolBullet.x)))
                //{
                //    _player.getParentLevel().x = random.Next(-25, 25);
                //    _player.getParentLevel().y = random.Next(-25, 25);
                //    stopShot = true;
                //}
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
