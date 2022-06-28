using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject ui;
    public GameObject optionsUi;

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
            return;
        }

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }

    public void Options()
    {
        optionsUi.SetActive(!optionsUi.activeSelf);

        if (optionsUi.activeSelf)
        {
            Time.timeScale = 0f;
            Toggle();
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}
