using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class Collectable : TileObject
    {
        Random random = new Random();
        int score = 0;
        
		public Collectable(Point tileCoordinates) : base(tileCoordinates)
        {
            //TEMP
			SetSprite(new Sprite("../../Assets/IMG/treasure.png"));
			//TEMPEND
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
