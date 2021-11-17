using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private GameObject _restartScreen;
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);

        _player.GameOver += OnPlayerDie;
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _player.GameOver += OnPlayerDie;
    }

    private void OnRestartButtonClick()
    {
        _spawner.ResetPool();
        _spawner.ResetPosition();
        _playerScore.ResetScore();
        Time.timeScale = 1;
        _restartScreen.SetActive(false);
    }

    private void OnPlayerDie()
    {
        Time.timeScale = 0;
        _restartScreen.SetActive(true);
    }
}
