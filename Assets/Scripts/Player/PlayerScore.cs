using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Button _resetHiScoreButton;
    [SerializeField] private Player _player;

    private const string SaveHiScore = "HiScore";
    private const string SaveTotalScore = "TotalScore";

    public int HiScore { get; private set; }

    public int CurrenScore { get; private set; }

    public int TotalScore { get; private set; }

    public event UnityAction ScoreChanged;
    public event UnityAction TotalScoreChanged;
    public event UnityAction NewHiScore;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(SaveHiScore))
            HiScore = PlayerPrefs.GetInt(SaveHiScore);

        if (PlayerPrefs.HasKey(SaveTotalScore))
            TotalScore = PlayerPrefs.GetInt(SaveTotalScore);
    }

    private void OnEnable()
    {
        _resetHiScoreButton.onClick.AddListener(ResetHiTotal);

        _player.GameOver += AddTotal;
    }

    private void OnDisable()
    {
        _resetHiScoreButton.onClick.RemoveListener(ResetHiTotal);

        _player.GameOver -= AddTotal;
    }

    public void Add(int score)
    {
        CurrenScore = score;

        if (CurrenScore > HiScore)
        {
            HiScore = CurrenScore;

            SaveInFile();

            NewHiScore?.Invoke();
        }

        ScoreChanged?.Invoke();
    }

    public void SubtractTotal(int purchase)
    {
        TotalScore -= purchase;

        TotalScoreChanged?.Invoke();
    }

    private void AddTotal()
    {
        TotalScore += CurrenScore;
        PlayerPrefs.SetInt(SaveTotalScore, TotalScore); 
        PlayerPrefs.Save();
    }

    private void SaveInFile()
    {
        PlayerPrefs.SetInt(SaveHiScore, HiScore); 
        PlayerPrefs.Save();
    }

      private void ResetHiTotal()
    {
        HiScore = 0;
        TotalScore = 0;
        PlayerPrefs.DeleteKey(SaveHiScore);
        PlayerPrefs.DeleteKey(SaveTotalScore);

        PlayerPrefs.Save();

        ScoreChanged?.Invoke();
    }
}