using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static bool gameEnded = false;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    public Button startButton;
    public bool isStarted = false;

    private void Awake()
    {
        startButton.gameObject.SetActive(false);
        Invoke("timeStop",0.8f);
    }

    private void timeStop()
    {
        startButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(StartGame);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;

        isStarted = true;
        // Hides the button
        startButton.gameObject.SetActive(false);
    }

    private void Start()
    {
        gameEnded = false;
    }
    public void Toggle(GameObject _ui)
    {
        _ui.SetActive(!_ui.activeSelf);

        if (_ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
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
        isStarted = false;
        gameEnded = true;
        Toggle(gameOverUI);
    }

    public void WinLevel()
    {
        isStarted = false;
        gameEnded = true;
        Toggle(completeLevelUI);
    }
}
