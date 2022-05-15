using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 1f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    public GameManager gameManager;

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        //Letzte Welle
        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());    // Coroutine ermöglicht die funktion gleichzeitig laufen zu lassen
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;        // zählt 1 Sekunde runter


        countdown = Mathf.Clamp(countdown,0f, Mathf.Infinity);  //Countdown soll nicht negativ werden
        waveCountdownText.text = string.Format("{0:00.00}",countdown); 
    }

    // IEnumerator ermöglicht das warten in einer Funktion
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.enemyCount;

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.spawnRate);  //wartet Anzahl an sekunden
        }


        waveIndex++;
    }

    //Spawnt Gegner an Startposition
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
