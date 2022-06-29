using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenuUI : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
