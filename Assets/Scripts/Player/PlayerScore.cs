using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(ScoreSaver))]

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Button _resetHighScoreButton;
    [SerializeField] private Player _player;

    private ScoreSaver _scoreSaver;

    public int HighScore { get; private set; }

    public int CurrenScore { get; private set; }

    public int TotalScore { get; private set; }

    public event UnityAction CurrentChanged;
    public event UnityAction TotalChanged;
    public event UnityAction NewHigh;

    private void OnEnable()
    {
        _resetHighScoreButton.onClick.AddListener(ResetHighTotal);

        _player.GameOver += AddTotal;
    }

    private void Start()
    {
        _scoreSaver = GetComponent<ScoreSaver>();

        TotalScore = _scoreSaver.Total;
        HighScore = _scoreSaver.High;
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

            _scoreSaver.SaveHigh(HighScore);

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

        _scoreSaver.SaveTotal(TotalScore);
    }

    private void ResetHighTotal()
    {
        HighScore = 0;
        TotalScore = 0;

        _scoreSaver.ResetHighTotal();

        CurrentChanged?.Invoke();
    }
}