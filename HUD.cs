using Godot;

public enum PlayerType
{
	Player,
	Ai
}

public partial class HUD : CanvasLayer
{
	[Signal]
	public delegate void OnRestartEventHandler();
	public int PlayerScore { get; set; }
	public int AiScore { get; set; }

	public override void _Ready()
	{
		Reset();
	}

	public void Reset()
	{
		PlayerScore = 0;
		AiScore = 0;
		UpdateScore();
		GetNode<Label>("PlayerWinnerLabel").Hide();
		GetNode<Label>("AiWinnerLabel").Hide();
		GetNode<Button>("RestartButton").Hide();
	}

	public void PlayerScored(PlayerType playerType)
	{
		if (playerType == PlayerType.Player)
		{
			PlayerScore++;
		}
		else
		{
			AiScore++;
		}
		UpdateScore();
	}

	public void ShowWinner(PlayerType playerType)
	{
		if (playerType == PlayerType.Player)
		{
			GetNode<Label>("PlayerWinnerLabel").Show();
		}
		else
		{
			GetNode<Label>("AiWinnerLabel").Show();
		}
		GetNode<Button>("RestartButton").Show();
	}

	private void UpdateScore()
	{
		GetNode<Label>("PlayerScoreLabel").Text = PlayerScore.ToString();
		GetNode<Label>("AiScoreLabel").Text = AiScore.ToString();
	}
	public void OnRestartButtonPressed()
	{
		EmitSignal(SignalName.OnRestart);
	}
}
