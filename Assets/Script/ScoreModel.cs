using System;

public class ScoreModel
{
    public event Action<int> OnScoreChanged;
    private int _score;

    public void AddScore(int value)
    {
        _score += value;
        OnScoreChanged?.Invoke(_score);
    }

    public void ResetScore()
    {
        _score = 0;
        OnScoreChanged?.Invoke(_score);
    }
}