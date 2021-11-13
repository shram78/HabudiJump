using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;

    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    //private void OnPlayButtonClick()
    //{
    //    StartGame();
    //}

    //private void OnRestartButtonClick()
    //{
    //    StartGame();
    //}

    //private void StartGame()
    //{
    //    Time.timeScale = 1;
    //    _player.ResetPlayer();
    //}

    public void OnGameOver()
    {
        Time.timeScale = 0;
    }
}
// not used now