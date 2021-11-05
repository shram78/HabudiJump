using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Worm _worm;

    private void OnEnable()
    {
        _worm.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _worm.GameOver -= OnGameOver;

    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void OnPlayButtonClick()
    {
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _worm.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
    }
}
