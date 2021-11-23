using UnityEngine;
using TMPro;

public class ViewScoreInGame : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _hiScoreText;

    [SerializeField] private PlayerScore _playerScore;

    private void Start()
    {
        _hiScoreText.text = _playerScore._hiScore.ToString();
    }

    private void OnEnable()
    {
        _scoreText.text = _playerScore._currenScore.ToString();
        _hiScoreText.text = _playerScore._hiScore.ToString();

        _playerScore.ScoreChanged += OnScoreChanged;
        _playerScore.HiScoreChanged += OnHiScoreChanged;
    }

    private void OnDisable()
    {
        _playerScore.ScoreChanged -= OnScoreChanged;
        _playerScore.HiScoreChanged -= OnHiScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }

    private void OnHiScoreChanged(int hiScore)
    {
        _hiScoreText.text = _playerScore._hiScore.ToString();
    }
}
