using Godot;

public partial class Main : Node
{
	[Export]
	public int ScoreToWin = 3;
	private Ball _ball;
	private HUD _hud;
	public override void _Ready()
	{
		_ball = GetNode<Ball>("Ball");
		_hud = GetNode<HUD>("HUD");
		_ball.Serve();
	}

	private bool CheckForVictory()
	{
		if (_hud.PlayerScore >= ScoreToWin)
		{
			_ball.Stop();
			_hud.ShowWinner(PlayerType.Player);
			return true;
		}
		else if (_hud.AiScore >= ScoreToWin)
		{
			_ball.Stop();
			_hud.ShowWinner(PlayerType.Ai);
			return true;
		}
		return false;
	}

	public void OnLeftGoalEntered(Node2D body)
	{
		if (body is not Ball) return;
		_hud.PlayerScored(PlayerType.Ai);

		if (CheckForVictory()) return;
		_ball.Serve();
	}

	public void OnRightGoalEntered(Node2D body)
	{
		if (body is not Ball) return;
		_hud.PlayerScored(PlayerType.Player);

		if (CheckForVictory()) return;
		_ball.Serve();
	}
	public void Restart()
	{
		_hud.Reset();
		_ball.Serve();
	}
}
