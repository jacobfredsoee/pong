using Godot;

public partial class Ball : RigidBody2D
{
	[Export]
	public float Speed;
	private Vector2 _startPosition = new Vector2(320, 180);
	private Timer _serveTimer;
	[Export]
	public float Radius;

	public override void _Ready()
	{
		_serveTimer = GetNode<Timer>("ServeTimer");
		GetNode<CollisionShape2D>("CollisionShape2D").Shape = new CircleShape2D { Radius = Radius };
		GetNode<BallColor>("BallColor").Radius = Radius;
	}

	public void Stop()
	{
		Position = _startPosition;
		LinearVelocity = Vector2.Zero;
		Hide();
	}

	public void Serve()
	{
		Show();
		Position = _startPosition;
		LinearVelocity = Vector2.Zero;
		_serveTimer.Start();
	}

	private void OnServeTimerTimeout()
	{
		float spread = Mathf.Pi / 3f;   // 60°
		var serveDirection = GD.RandRange(0, 1) == 0 ? 0 : Mathf.Pi;

		float angleRad = serveDirection + (float)GD.RandRange(-spread, spread);
		LinearVelocity = Vector2.FromAngle(angleRad) * Speed;
	}

	// Runs inside the physics solver. Bounces set the direction; we pin the
	// magnitude here so the ball can never gain or lose speed over time.
	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		state.LinearVelocity = state.LinearVelocity.Normalized() * Speed;
	}
}
