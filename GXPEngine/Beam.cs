using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Beam : Sprite
    {
        int beam = 50;
        //'Til the end of the screen
        int length = 0;

        public Beam() : base("../../Assets/IMG/bullit.png")
        {
            length = game.width;
        }

        public void Update()
        {
            alpha = beam / 50.0f;
            beam = beam -1;
            if (beam < 0)
	        {
		        Destroy();
	        }
        }
    }
}
