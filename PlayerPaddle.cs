using Godot;

public partial class PlayerPaddle : Paddle
{
	protected override float GetMoveDirection()
	{
		return Input.GetAxis("move_down", "move_up");
	}
}
