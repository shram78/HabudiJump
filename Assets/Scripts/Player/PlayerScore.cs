using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Button _resetHiScoreButton;
    [SerializeField] private Player _player;

    private const string _saveHiScore = "HiScore";
    private const string _saveTotalScore = "TotalScore";

    public int HiScore { get; private set; }

    public int CurrenScore { get; private set; }

    public int TotalScore { get; private set; }

    public event UnityAction ScoreChanged;
    public event UnityAction TotalScoreChanged;
    public event UnityAction NewHiScore;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_saveHiScore))
            HiScore = PlayerPrefs.GetInt(_saveHiScore);

        if (PlayerPrefs.HasKey(_saveTotalScore))
            TotalScore = PlayerPrefs.GetInt(_saveTotalScore);
    }

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

    public void AddScore(int score)
    {
        CurrenScore = score;

        if (CurrenScore > HiScore)
        {
            HiScore = CurrenScore;

            SaveHiScore();

            NewHiScore?.Invoke();
        }

        ScoreChanged?.Invoke();
    }

    public void SubtractTotalScore(int purchase)
    {
        TotalScore -= purchase;

        TotalScoreChanged?.Invoke();
    }

    private void AddTotalScore()
    {
        TotalScore += CurrenScore;
        PlayerPrefs.SetInt(_saveTotalScore, TotalScore); 
        PlayerPrefs.Save();
    }

    private void SaveHiScore()
    {
        PlayerPrefs.SetInt(_saveHiScore, HiScore); 
        PlayerPrefs.Save();
    }

      private void ResetHiScore()
    {
        HiScore = 0;
        TotalScore = 0;
        PlayerPrefs.DeleteKey(_saveHiScore);
        PlayerPrefs.DeleteKey(_saveTotalScore);

        PlayerPrefs.Save();

        ScoreChanged?.Invoke();
    }
}