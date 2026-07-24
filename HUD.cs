using Godot;

public enum PlayerType
{
	Player,
	Ai
}

public partial class HUD : CanvasLayer
{
	[Signal]
	public delegate void RestartRequestedEventHandler();
	private int _playerScore;
	public int PlayerScore { get => _playerScore; }
	private int _aiScore;
	public int AiScore { get => _aiScore; }

	public override void _Ready()
	{
		Reset();
	}

	public void Reset()
	{
		_playerScore = 0;
		_aiScore = 0;
		UpdateScore();
		GetNode<Label>("PlayerWinnerLabel").Hide();
		GetNode<Label>("AiWinnerLabel").Hide();
		GetNode<Button>("RestartButton").Hide();
	}

	public void PlayerScored(PlayerType playerType)
	{
		if (playerType == PlayerType.Player)
		{
			_playerScore++;
		}
		else
		{
			_aiScore++;
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
		GetNode<Label>("PlayerScoreLabel").Text = _playerScore.ToString();
		GetNode<Label>("AiScoreLabel").Text = _aiScore.ToString();
	}
	public void RestartRequestedButtonPressed()
	{
		EmitSignal(SignalName.RestartRequested);
	}
}
