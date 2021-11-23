using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private Player _player;
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
        Level_1.Load();
        _restartScreen.SetActive(false);
    }

    private void OnPlayerDie()
    {
        Time.timeScale = 0;
        _restartScreen.SetActive(true);
    }
}
