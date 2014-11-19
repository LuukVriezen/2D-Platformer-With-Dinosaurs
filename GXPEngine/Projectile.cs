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
        int distance = 100;
        bool stopBeam = false;
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
            hitWall.SetXY(game.width - hitWall.width - 200, game.height /2);

        }

        public void Update()
        {
            Gunshot();
        }

        public void Gunshot()
        {
            if (Input.GetKey(Key.P))
            {
                xSpeed = xSpeed + 25;
                pistolBullet.x = xSpeed;

                //Check collision with an object.
                if (pistolBullet.HitTest(hitWall))
                {
                    HitCollision();
                }
            }
            else if (Input.GetKey(Key.B))
            {
                Sprite beam = DubstepBeam();
                xSpeed = xSpeed + 10;
                pistolBullet.x = xSpeed;
                if (beam.HitTest(hitWall))
                {
                    beam.Destroy();
                    hitWall.Destroy();
                    pistolBullet.Destroy();
                    distance = 0;
                }
                else
                {
                    if (distance < 0)
                    {
                        beam.Destroy();
                    }
                }
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

        public void HitCollision()
        {
            hitWall.Destroy();
        }

    }
}
