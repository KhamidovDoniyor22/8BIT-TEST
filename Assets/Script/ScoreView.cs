using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void UpdateScoreText(int currentScore)
    {
        scoreText.text = $"Score: {currentScore}";
    }
}