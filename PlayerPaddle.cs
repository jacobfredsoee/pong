using Godot;
using System;

public partial class PlayerPaddle : Paddle
{
	protected override float GetMoveDirection()
	{
		// positive action = "move_up" so pressing up returns +1, and
		// velocity = Vector2.Up * (+1) moves the paddle up (screen Y decreases).
		return Input.GetAxis("move_down", "move_up");
	}
}
