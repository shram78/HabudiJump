using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Button _resetHiScoreButton;

    public int _hiScore { get; private set; }
    public int _currenScore { get; private set; }


    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HiScoreChanged;


    private void OnEnable()
    {
        _resetHiScoreButton.onClick.AddListener(ResetHiScore);
    }

    private void OnDisable()
    {
        _resetHiScoreButton.onClick.RemoveListener(ResetHiScore);
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("A"))
            _hiScore = PlayerPrefs.GetInt("A");
    }

    private void Update()
    {
        if (_currenScore > _hiScore)
        {
            _hiScore = _currenScore;
        }

        PlayerPrefs.SetInt("A", _hiScore); // ������� �� �������
        PlayerPrefs.Save();

        Debug.Log(_hiScore);
    }

    public void AddScore(int score)
    {
        _currenScore = score;

        ScoreChanged?.Invoke(_currenScore);
    }

    public void ResetScore()
    {
        _currenScore = 0;
        ScoreChanged?.Invoke(_currenScore);
    }

    private void ResetHiScore()
    {
        _hiScore = 0;
        PlayerPrefs.DeleteKey("A");
        PlayerPrefs.Save();

        HiScoreChanged?.Invoke(_hiScore);
    }
}