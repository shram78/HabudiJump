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

    private void OnEnable()
    {
        _player.GameOver += OnShowPoints;

        _playerScore.CurrentChanged += OnScoreChanged;

        _playerScore.TotalChanged += OnScoreChanged;
    }

    private void Start()
    {
        _scoreInGame.text = _playerScore.CurrenScore.ToString();
        _totalScore.text = _playerScore.TotalScore.ToString();
    }

    private void OnDisable()
    {
        _player.GameOver -= OnShowPoints;

        _playerScore.CurrentChanged -= OnScoreChanged;

        _playerScore.TotalChanged -= OnScoreChanged;
    }

    private void OnScoreChanged()
    {
        _scoreInGame.text = _playerScore.CurrenScore.ToString();

        _hiScore.text = _playerScore.HighScore.ToString();

        _totalScore.text = _playerScore.TotalScore.ToString();
    }

    private void OnShowPoints()
    {
        _scoreInFinish.text = _playerScore.CurrenScore.ToString();
        _hiScore.text = _playerScore.HighScore.ToString();
    }
}
