using Godot;
using System;

public partial class AiPaddle : Paddle
{
	[Export]
	public Ball ball;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
	}

	protected override float GetMoveDirection()
	{
		bool shouldMove = Mathf.Abs(ball.Position.Y - Position.Y) > 15;
		if (shouldMove)
		{
			return ball.Position.Y > Position.Y ? -1 : 1;
		}
		return 0;
	}
}
