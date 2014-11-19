using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{	
	public MyGame () : base(1280, 960, false)
	{

	}
	
	void Update () {
		//empty
	}

	static void Main() {
		new MyGame().Start();
	}
}

