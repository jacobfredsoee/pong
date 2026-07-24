using Godot;
using System;

public partial class Main : Node
{
	private Ball ball;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ball = GetNode<Ball>("Ball");
		ball.Serve();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private bool CheckForVictory()
	{
		if (GetNode<HUD>("HUD").PlayerScore >= 3)
		{
			ball.Stop();
			GetNode<HUD>("HUD").ShowWinner(PlayerType.Player);
			return true;
		}
		else if (GetNode<HUD>("HUD").AiScore >= 3)
		{
			ball.Stop();
			GetNode<HUD>("HUD").ShowWinner(PlayerType.Ai);
			return true;
		}
		return false;
	}

	public void OnLeftGoalEntered(Node2D body)
	{
		if (body is not Ball) return;
		GetNode<HUD>("HUD").PlayerScored(PlayerType.Ai);

		if (CheckForVictory()) return;
		ball.Serve();
	}

	public void OnRightGoalEntered(Node2D body)
	{
		if (body is not Ball) return;
		GetNode<HUD>("HUD").PlayerScored(PlayerType.Player);

		if (CheckForVictory()) return;
		ball.Serve();
	}
	public void Restart()
	{
		GetNode<HUD>("HUD").Reset();
		ball.Serve();
	}
}
