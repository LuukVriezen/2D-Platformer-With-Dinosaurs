<<<<<<< HEAD
using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{	
	public MyGame () : base(640, 480, false)
	{
        Projectile projectile = new Projectile();
        this.AddChild(projectile);
	}
	
	void Update () {
		//empty
	}

	static void Main() {
		new MyGame().Start();
	}
}

=======
using System;
using GXPEngine;
using System.Drawing;

public class MyGame : Game
{	
	public MyGame () : base(640, 480, false)
	{
		this.AddChild(new Level());
	}
	
	void Update () {
		//empty
	}

	static void Main() {
		new MyGame().Start();
	}
}

>>>>>>> Stash
