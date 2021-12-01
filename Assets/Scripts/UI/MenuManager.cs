using UnityEngine;
using IJunior.TypedScenes;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _buttonClickSound;
    [SerializeField] private GameObject _restartScreen;
    [SerializeField] private GameObject _StoreScreen;

    [SerializeField] private Button _openStoreButton;
    [SerializeField] private Button _closeStoreButton;
    [SerializeField] private Button _backMainMenuButton;
    [SerializeField] private Button _exitMainMenuButton;
    [SerializeField] private Button _restartButton;


    private void OnEnable()
    {
        _openStoreButton.onClick.AddListener(OnOpenStore);
        _closeStoreButton.onClick.AddListener(OnCloseStore);
        _backMainMenuButton.onClick.AddListener(OnBackMainMenuButton);
        _exitMainMenuButton.onClick.AddListener(OnBackMainMenuButton);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _player.GameOver += OnPlayerDie;
    }

    private void OnDisable()
    {
        _openStoreButton.onClick.RemoveListener(OnOpenStore);
        _closeStoreButton.onClick.RemoveListener(OnCloseStore);
        _backMainMenuButton.onClick.RemoveListener(OnBackMainMenuButton);
        _exitMainMenuButton.onClick.RemoveListener(OnBackMainMenuButton);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _player.GameOver -= OnPlayerDie;
    }

    private void OnBackMainMenuButton() 
    {
        Time.timeScale = 1;
        MainMenu.Load();
    }

    private void OnOpenStore()
    {
        _buttonClickSound.Play();
        Time.timeScale = 0;
        _StoreScreen.SetActive(true);
    }

    private void OnCloseStore()
    {
        _buttonClickSound.Play();
        Time.timeScale = 1;
        _StoreScreen.SetActive(false);
    }

    private void OnRestartButtonClick()
    {
        _buttonClickSound.Play();
        Level_1.Load();
        _restartScreen.SetActive(false);
    }

    private void OnPlayerDie()
    {
        Time.timeScale = 0;
        _restartScreen.SetActive(true);
    }
}