using Godot;

public partial class AiPaddle : Paddle
{
	[Export]
	public Ball Ball;

	protected override float GetMoveDirection()
	{
		if (Ball == null) return 0;

		float paddleCenterY = Position.Y + _colorRect.Size.Y / 2;
		bool shouldMove = Mathf.Abs(Ball.Position.Y - paddleCenterY) > 15;
		if (shouldMove)
		{
			return Ball.Position.Y > paddleCenterY ? -1 : 1;
		}
		return 0;
	}
}
