using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Button _resetHighScoreButton;
    [SerializeField] private Player _player;

    private const string HighScorePrefs = "HighScore";
    private const string TotalScorePrefs = "TotalScore";

    public int HighScore { get; private set; }

    public int CurrenScore { get; private set; }

    public int TotalScore { get; private set; }

    public event UnityAction CurrentChanged;
    public event UnityAction TotalChanged;
    public event UnityAction NewHigh;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(HighScorePrefs))
            HighScore = PlayerPrefs.GetInt(HighScorePrefs);

        if (PlayerPrefs.HasKey(TotalScorePrefs))
            TotalScore = PlayerPrefs.GetInt(TotalScorePrefs);
    }

    private void OnEnable()
    {
        _resetHighScoreButton.onClick.AddListener(ResetHighTotal);

        _player.GameOver += AddTotal;
    }

    private void OnDisable()
    {
        _resetHighScoreButton.onClick.RemoveListener(ResetHighTotal);

        _player.GameOver -= AddTotal;
    }

    public void Add(int score)
    {
        CurrenScore = score;

        if (CurrenScore > HighScore)
        {
            HighScore = CurrenScore;

            SaveInFile();

            NewHigh?.Invoke();
        }

        CurrentChanged?.Invoke();
    }

    public void SubtractTotal(int purchase)
    {
        TotalScore -= purchase;

        TotalChanged?.Invoke();
    }

    private void AddTotal()
    {
        TotalScore += CurrenScore;
        PlayerPrefs.SetInt(TotalScorePrefs, TotalScore); 
        PlayerPrefs.Save();
    }

    private void SaveInFile()
    {
        PlayerPrefs.SetInt(HighScorePrefs, HighScore); 
        PlayerPrefs.Save();
    }

      private void ResetHighTotal()
    {
        HighScore = 0;
        TotalScore = 0;
        PlayerPrefs.DeleteKey(HighScorePrefs);
        PlayerPrefs.DeleteKey(TotalScorePrefs);

        PlayerPrefs.Save();

        CurrentChanged?.Invoke();
    }
}