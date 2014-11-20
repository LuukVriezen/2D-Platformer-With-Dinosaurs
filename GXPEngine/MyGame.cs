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
			//this.AddChild(new Collectable());
		}
		
		void Update () {
			
		}

		static void Main() {
			new MyGame().Start();
		}
	}

}