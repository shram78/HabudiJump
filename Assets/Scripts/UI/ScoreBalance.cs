using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _score.text = _player.Score.ToString();
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
}