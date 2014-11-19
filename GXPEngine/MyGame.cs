using System;
using GXPEngine;
using System.Drawing;

namespace GXPEngine
{

	public class MyGame : Game
	{	
		public MyGame () : base(640, 480, false)
		{
			this.AddChild(new Level());
			this.AddChild(new Projectile());
		}
		
		void Update () {
			//empty
		}

		static void Main() {
			new MyGame().Start();
		}
	}

}