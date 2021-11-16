using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _globalHiScore;
    private int _currenScore;

    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        if (PlayerPrefs.HasKey("A"))
            _globalHiScore = PlayerPrefs.GetInt("A");

    }

    //private void Update()
    //{
    //    if (_currenScore > _globalHiScore)
    //        _globalHiScore = _player.Score;


    //    PlayerPrefs.SetInt("A", _globalHiScore);
    //    PlayerPrefs.Save();

    //    Debug.Log("GlobalScore == " + _globalHiScore);
    //}

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
}