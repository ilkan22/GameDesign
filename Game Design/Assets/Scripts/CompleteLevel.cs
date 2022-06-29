using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;

    public string nextLevel;
    public int levelToUnlock;

    public string menuSceneName = "MainMenu";

    public void Continue()
    {
        Time.timeScale = 1f;
        WaveSpawner.EnemiesAlive = 0;
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(menuSceneName);
    }

}
