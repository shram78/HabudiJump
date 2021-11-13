using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }


    public void GoMainMenu()
    {
        MainMenu.Load();
    }

    public void PlayGame()
    {
        Level_1.Load();
        Time.timeScale = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Вышел из Хабуди");
    }
}
