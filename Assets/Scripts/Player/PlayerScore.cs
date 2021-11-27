using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Button _resetHiScoreButton;
    [SerializeField] private Player _player;

    private const string _saveHiScore = "HiScore";
    private const string _saveTotalScore = "TotalScore";

    public int _hiScore { get; private set; }

    public int _currenScore { get; private set; }

    public int _totalScore { get; private set; }

    public event UnityAction ScoreChanged;

    private void OnEnable()
    {
        _resetHiScoreButton.onClick.AddListener(ResetHiScore);

        _player.GameOver += AddTotalScore;
    }

    private void OnDisable()
    {
        _resetHiScoreButton.onClick.RemoveListener(ResetHiScore);

        _player.GameOver -= AddTotalScore;
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_saveHiScore))
            _hiScore = PlayerPrefs.GetInt(_saveHiScore);

        if (PlayerPrefs.HasKey(_saveTotalScore))  
            _totalScore = PlayerPrefs.GetInt(_saveTotalScore);
    }

    public void AddScore(int score)
    {
        _currenScore = score;

        if (_currenScore > _hiScore)
        {
            _hiScore = _currenScore;

            SaveHiScore();
        }

        ScoreChanged?.Invoke();
    }

    private void AddTotalScore()
    {
        _totalScore += _currenScore;
        PlayerPrefs.SetInt(_saveTotalScore, _totalScore); 
        PlayerPrefs.Save();
    }

    private void SaveHiScore()
    {
        PlayerPrefs.SetInt(_saveHiScore, _hiScore); 
        PlayerPrefs.Save();
    }

      private void ResetHiScore()
    {
        _hiScore = 0;
        _totalScore = 0;
        PlayerPrefs.DeleteKey(_saveHiScore);
        PlayerPrefs.DeleteKey(_saveTotalScore);

        PlayerPrefs.Save();

        ScoreChanged?.Invoke();
    }
}