using UnityEngine;
using TMPro;

public class ViewScoreInGame : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreInGame;
    [SerializeField] private TMP_Text _scoreInFinish;
    [SerializeField] private TMP_Text _hiScore;
    [SerializeField] private TMP_Text _totalScore;

    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private Player _player;

    private void Start()
    {
        _scoreInGame.text = _playerScore._currenScore.ToString();
        _totalScore.text = _playerScore._totalScore.ToString();
    }

    private void OnEnable()
    {
        _player.GameOver += OnShowPoints;

        _playerScore.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnShowPoints;

        _playerScore.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged()
    {
        _scoreInGame.text = _playerScore._currenScore.ToString();

        _hiScore.text = _playerScore._hiScore.ToString();
    }

    private void OnShowPoints()
    {
        _scoreInFinish.text = _playerScore._currenScore.ToString();
        _hiScore.text = _playerScore._hiScore.ToString();
    }
}
