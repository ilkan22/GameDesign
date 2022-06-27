using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameEnded = false;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    private void Start()
    {
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (Input.GetKeyDown("r"))
        {
            WinLevel();
        }

        if (PlayerStats.Lives <= 0)
            EndGame();
    }

    private void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void WinLevel()
    {
        
        gameEnded = true;
        completeLevelUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
