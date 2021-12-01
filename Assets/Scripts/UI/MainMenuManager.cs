using System.Collections;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonClickSound;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;


    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
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

    private IEnumerator DelayStart()
    {
        _buttonClickSound.Play();

        while (_buttonClickSound.isPlaying)
            yield return null;

        Time.timeScale = 0;
        Level_1.Load();
    }
}
