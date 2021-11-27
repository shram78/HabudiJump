using UnityEngine;
using IJunior.TypedScenes;

public class MenuManager : MonoBehaviour
{
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
        Time.timeScale = 0;
        Level_1.Load();
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Вышел из Хабуди");
    }
}
