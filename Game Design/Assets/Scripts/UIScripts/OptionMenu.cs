using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject pauseMenuUi;

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    private void Update()
    {
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

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }

    public void back()
    {
        pauseMenuUi.SetActive(!pauseMenuUi.activeSelf);

        if (pauseMenuUi.activeSelf)
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
