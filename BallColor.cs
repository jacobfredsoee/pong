using Godot;
using System;

public partial class BallColor : Node2D
{
	[Export]
	public Color color;
	[Export]
	public float radius;
	// Called when the node enters the scene tree for the first time.
	public override void _Draw()
	{
		DrawCircle(Vector2.Zero, radius, color);
	}

}
