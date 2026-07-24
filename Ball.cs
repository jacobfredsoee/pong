using Godot;

public partial class Ball : RigidBody2D
{
	[Export]
	public float speed = 200.0f;
	private Vector2 startPosition = new Vector2(340, 180);
	private Timer serveTimer;

	public override void _Ready()
	{
		serveTimer = GetNode<Timer>("ServeTimer");
	}

	public void Stop()
	{
		Position = startPosition;
		LinearVelocity = Vector2.Zero;
		Hide();
	}

	public void Serve()
	{
		Show();
		Position = startPosition;
		LinearVelocity = Vector2.Zero;
		serveTimer.Start();
	}

	private void OnServeTimerTimeout()
	{
		float spread = Mathf.Pi / 3f;   // 60°
		var serveDirection = GD.RandRange(0, 1) == 0 ? 0 : Mathf.Pi;

		float angleRad = serveDirection + (float)GD.RandRange(-spread, spread);
		LinearVelocity = Vector2.FromAngle(angleRad) * speed;
	}

	// Runs inside the physics solver. Bounces set the direction; we pin the
	// magnitude here so the ball can never gain or lose speed over time.
	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		state.LinearVelocity = state.LinearVelocity.Normalized() * speed;
	}
}
