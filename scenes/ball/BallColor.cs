using Godot;

public partial class BallColor : Node2D
{
	private Color _color;
	[Export]
	public Color Color
	{
		get => _color;
		set
		{
			_color = value;
			QueueRedraw();
		}
	}
	private float _radius;
	[Export]
	public float Radius
	{
		get => _radius;
		set
		{
			_radius = value;
			QueueRedraw();
		}
	}

	public override void _Draw()
	{
		DrawCircle(Vector2.Zero, Radius, Color);
	}

}
