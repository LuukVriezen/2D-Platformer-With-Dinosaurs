using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        //private Platform platform = new Platform();
        //delay
        //back by firing

        //Pistol hight and width from the picture
        int pistolHeight = 10;
        int pistolWidth = 0;
        
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

            //AddChild(hitWall);
            //hitWall.SetXY(game.width - hitWall.width - 200, game.height -hitWall.height);

        }

        public void Update()
        {
            if (/*Input.GetKeyDown(Key.P) ||*/ stopShot)
            //{
                GunShot();
            //}
            //if (Input.GetKeyDown(Key.B) || stopBeam)
            //{
            //    BeamShot();
            //}
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
            if (pistolBullet.x < game.width)
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
