using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Beam : Sprite
    {
        int beam = 50;

        public Beam() : base("../../Assets/IMG/bullit.png")
        {

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
