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
        float ySpeed = 0.0f;
        int lengthOfBeam = 0;
        int lengthOfPistol = 0;
        int distance = 100;
        bool stopBeam = false;
        bool stopShot = false;   
        //delay
        //back by firing
        
        //Rainbow bullet en beam
        Sprite pistolBullet = new Sprite("../../Assets/IMG/bullit.png");
        //Hit test sprite
        Sprite hitWall = new Sprite("../../Assets/IMG/colors.png");

        public Projectile()
        {
            //Constructor of Projectile. Already made for later use.
            AddChild(pistolBullet);
            pistolBullet.SetXY(0, game.height / 2);

            AddChild(hitWall);
            hitWall.SetXY(game.width - hitWall.width - 200, game.height -hitWall.height);

        }

        public void Update()
        {
            if (Input.GetKeyDown(Key.P) || stopShot)
            {
                GunShot();
            }
            if (Input.GetKeyDown(Key.B) || stopBeam)
            {
                BeamShot();
            }
        }

        public void GunShot()
        {
            xSpeed = xSpeed + 25;
            pistolBullet.x = xSpeed;
            Console.WriteLine(pistolBullet.x);
            //Check collision with an object.
            if (pistolBullet.HitTest(hitWall))
            {
                hitWall.Destroy();
                pistolBullet.SetXY(0, game.height / 2);
                xSpeed = 0;
                stopShot = false;
            }
            else if (pistolBullet.x < game.width)
            {
                stopShot = true;
            }
            else
            {
                pistolBullet.SetXY(0, game.height / 2);
                xSpeed = 0;
                stopShot = false;
            }

        }

        public void BeamShot()
        {
            Sprite beam = DubstepBeam();
            xSpeed = xSpeed + 5;
            pistolBullet.x = xSpeed;
            if (pistolBullet.HitTest(hitWall))
            {
                hitWall.Destroy();
                pistolBullet.SetXY(0, game.height / 2);
                //beam.Destroy();
                stopBeam = false;
                xSpeed = 0;
            }
            else
            {
                stopBeam = true;
            }
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
