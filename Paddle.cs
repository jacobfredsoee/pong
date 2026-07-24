using Godot;

public abstract partial class Paddle : AnimatableBody2D
{
	[Export]
	public float speed = 400.0f;
	[Export]
	public Color color;

	private Vector2 _screenSize;
	private ColorRect _colorRect;
	private int _borderInset = 15;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_screenSize = GetViewportRect().Size;
		_colorRect = GetNode<ColorRect>("ColorRect");
		_colorRect.Color = color;
	}

	public override void _Process(double delta)
	{
		var direction = GetMoveDirection();
		var velocity = Vector2.Up * direction * speed;

		Position += velocity * (float)delta;
		Position = new Vector2(Position.X, Mathf.Clamp(Position.Y, 0 + _borderInset, _screenSize.Y - _colorRect.Size.Y - _borderInset));
	}
	protected abstract float GetMoveDirection();
}
