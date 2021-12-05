using System.Collections;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonClickSound;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _iJuniorUrlButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _iJuniorUrlButton.onClick.AddListener(OnIJuniorButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _iJuniorUrlButton.onClick.RemoveListener(OnIJuniorButtonClick);
    }

    private void OnPlayButtonClick()
    {
        StartCoroutine(DelayStart());
    }

    private void OnExitButtonClick()
    {
        _buttonClickSound.Play();
        Application.Quit();
        Debug.Log("Вышел из Хабуди");
    }

    private void OnIJuniorButtonClick()
    {
        Application.OpenURL("https://ijunior.ru/");
    }

    private IEnumerator DelayStart()
    {
        _buttonClickSound.Play();

        while (_buttonClickSound.isPlaying)
            yield return null;

        Time.timeScale = 0;
        Level_1.Load();
    }
}
