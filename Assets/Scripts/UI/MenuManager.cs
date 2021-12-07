using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private AudioSource _buttonClickSound;
    [SerializeField] private AudioSource _newHiScoreSound;
    [SerializeField] private GameObject _restartScreen;
    [SerializeField] private GameObject _StoreScreen;
    [SerializeField] private Image _newHiScore;
    [SerializeField] private Button _openStoreButton;
    [SerializeField] private Button _closeStoreButton;
    [SerializeField] private Button _backMainMenuButton;
    [SerializeField] private Button _exitMainMenuButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextBoostButton;
    [SerializeField] private Button _useCurrentBoostButton;

    private bool _isSetNewHiScore = false;

    private void OnEnable()
    {
        _openStoreButton.onClick.AddListener(OnOpenStore);
        _closeStoreButton.onClick.AddListener(OnCloseStore);
        _backMainMenuButton.onClick.AddListener(OnBackMainMenuButton);
        _exitMainMenuButton.onClick.AddListener(OnBackMainMenuButton);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _nextBoostButton.onClick.AddListener(OnNextBoostButtonClick);
        _useCurrentBoostButton.onClick.AddListener(OnUseBoostButtonClick);

        _player.GameOver += OnPlayerDie;
        _playerScore.NewHiScore += OnPlayerNewHiScore;
        _player.NoNextBoost += ShowNexBoostButton;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q) || Input.GetMouseButton(1))
            OnUseBoostButtonClick();
    }

    private void OnDisable()
    {
        _openStoreButton.onClick.RemoveListener(OnOpenStore);
        _closeStoreButton.onClick.RemoveListener(OnCloseStore);
        _backMainMenuButton.onClick.RemoveListener(OnBackMainMenuButton);
        _exitMainMenuButton.onClick.RemoveListener(OnBackMainMenuButton);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _nextBoostButton.onClick.RemoveListener(OnNextBoostButtonClick);
        _useCurrentBoostButton.onClick.RemoveListener(OnUseBoostButtonClick);

        _player.GameOver -= OnPlayerDie;
        _playerScore.NewHiScore -= OnPlayerNewHiScore;
        _player.NoNextBoost -= ShowNexBoostButton;
    }

    private void OnUseBoostButtonClick()
    {
        _player.UseCurrentBoost();
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
        Time.timeScale = 0;
        _buttonClickSound.Play();

        Level_1.Load();
        _restartScreen.SetActive(false);
    }

    private void OnPlayerDie()
    {
        _restartScreen.SetActive(true);

        if (_isSetNewHiScore)
            _newHiScoreSound.Play();
    }

    private void OnPlayerNewHiScore()
    {
        _newHiScore.gameObject.SetActive(true);

        _isSetNewHiScore = true;
    }

    private void OnNextBoostButtonClick()
    {
        _player.NextBoost();
    }

    private void ShowNexBoostButton()
    {
        if (_player.BoostCount <= 1)

        _nextBoostButton.gameObject.SetActive(false);

        else
            _nextBoostButton.gameObject.SetActive(true);
    }
}