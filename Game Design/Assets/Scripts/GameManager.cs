using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameEnded = false;

    public GameObject gameOverUI;

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

        if(PlayerStats.Lives <= 0)
            EndGame();
    }

    private void EndGame()
    {
        gameEnded = true;

        gameOverUI.SetActive(true);
        Debug.Log("Game Over");
    }
}