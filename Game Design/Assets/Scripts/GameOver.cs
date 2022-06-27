using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;
    public SceneFader sceneFader;


    public string menuSceneName = "MainMenu";

    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(menuSceneName);
    }

}
