using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private ScoreView view;
    [SerializeField] private Button addButton;
    [SerializeField] private Button resetButton;

    [SerializeField] private int _scorePerItem = 1;

    private ScoreModel _model;

    private void Awake()
    {
        _model = new ScoreModel();
        _model.OnScoreChanged += view.UpdateScoreText;

        view.UpdateScoreText(0);

        addButton.onClick.AddListener(() => _model.AddScore(1));
        resetButton.onClick.AddListener(_model.ResetScore);
    }
    private void OnEnable()
    {
        CollectibleItem.OnCollected += HandleItemCollected;
    }

    private void OnDisable()
    {
        CollectibleItem.OnCollected -= HandleItemCollected;
    }
    private void HandleItemCollected()
    {
        _model.AddScore(_scorePerItem);
    }
}