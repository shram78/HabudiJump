using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartNewGame : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _restartScreen;
    [SerializeField] private Button _playButton;

    private void OnEnable()
    {
        _player.GameOver += PauseGame;
        _playButton.onClick.AddListener(OnPlayButtonClick); 
    }

    private void OnDisable()
    {
        _player.GameOver -= PauseGame;
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        
        _restartScreen.SetActive(true);
    }

    private void OnPlayButtonClick()
    {
        _spawner.ResetPool();
        _spawner.ResetPosition();
        _restartScreen.SetActive(false);
        _player.ResetPlayer();
        Time.timeScale = 1;
    }

    private void Start()
    {
        Time.timeScale = 0;
    }
}
