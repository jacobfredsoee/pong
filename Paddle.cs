using Godot;

public abstract partial class Paddle : AnimatableBody2D
{
	[Export]
	public float Speed = 400.0f;
	[Export]
	public Color Color;

	private Vector2 _screenSize;
	protected ColorRect _colorRect;
	private int _borderInset = 15;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_screenSize = GetViewportRect().Size;
		_colorRect = GetNode<ColorRect>("ColorRect");
		_colorRect.Color = Color;
	}

	// Move in the physics frame: the paddle is a collision body the ball must
	// reliably hit, so its transform must stay in lockstep with the physics tick.
	public override void _PhysicsProcess(double delta)
	{
		var direction = GetMoveDirection();
		var velocity = Vector2.Up * direction * Speed;

		Position += velocity * (float)delta;
		Position = new Vector2(Position.X, Mathf.Clamp(Position.Y, 0 + _borderInset, _screenSize.Y - _colorRect.Size.Y - _borderInset));
	}
	protected abstract float GetMoveDirection();
}
