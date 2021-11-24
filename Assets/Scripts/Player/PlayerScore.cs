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

    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HiScoreChanged;

    private void OnEnable()
    {
        _player.GameOver += AddTotalScore;

        _resetHiScoreButton.onClick.AddListener(ResetHiScore);
    }

    private void OnDisable()
    {
        _player.GameOver -= AddTotalScore;

        _resetHiScoreButton.onClick.RemoveListener(ResetHiScore);
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_saveHiScore))
            _hiScore = PlayerPrefs.GetInt(_saveHiScore);

        if (PlayerPrefs.HasKey(_saveTotalScore))  // объединить в функцией выше
            _hiScore = PlayerPrefs.GetInt(_saveTotalScore);
    }

    public void AddScore(int score)
    {
        _currenScore = score;

        if (_currenScore > _hiScore)
        {
            _hiScore = _currenScore;

            SaveHiScore();
        }

        ScoreChanged?.Invoke(_currenScore);
    }

    private void AddTotalScore()
    {
        _totalScore += _currenScore;

        Debug.Log("Total Score = " + _totalScore);
    }

    private void SaveHiScore()
    {
        PlayerPrefs.SetInt(_saveHiScore, _hiScore); // вынести из апдейта
        PlayerPrefs.Save();
    }

    private void SaveTotalScore()
    {
        PlayerPrefs.SetInt(_saveTotalScore, _totalScore); // вынести из апдейта
        PlayerPrefs.Save();
    }

    private void ResetHiScore()
    {
        _hiScore = 0;
        PlayerPrefs.DeleteKey(_saveHiScore);
        PlayerPrefs.Save();

        HiScoreChanged?.Invoke(_hiScore);
    }
}