using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSaver : MonoBehaviour
{
    private const string HighPrefs = "HighScore";
    private const string TotalPrefs = "TotalScore";

    public int High { get; private set; }

    public int Total { get; private set; }

    private void Awake()
    {
        if (PlayerPrefs.HasKey(HighPrefs))
            High = PlayerPrefs.GetInt(HighPrefs);

        if (PlayerPrefs.HasKey(TotalPrefs))
            Total = PlayerPrefs.GetInt(TotalPrefs);
    }

    public void SaveTotal(int TotalScore)
    {
        PlayerPrefs.SetInt(TotalPrefs, TotalScore);
        PlayerPrefs.Save();
    }

    public void SaveHigh(int HighScore)
    {
        PlayerPrefs.SetInt(HighPrefs, HighScore);
        PlayerPrefs.Save();
    }

    public void ResetHighTotal()
    {
        PlayerPrefs.DeleteKey(HighPrefs);
        PlayerPrefs.DeleteKey(TotalPrefs);

        PlayerPrefs.Save();
    }
}
