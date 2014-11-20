using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Collectable : GameObject
    {
        public Sprite treasure = new Sprite("../../Assets/IMG/treasure.png");
        //public Sprite rum = new Sprite("../../Assets/IMG/rum.png");
        Random random = new Random();
        int score = 0;
        
        public Collectable()
        {
            
        }

        void Update()
        {

        }

        public int TreasurePoints()
        {
            //When a treasure is hit.
            score = score + random.Next(100, 501);

            return score;
        }
    }
}
