using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 1f;
    private float timeBetweenEnemies = 0.5f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());    // Coroutine ermöglicht die funktion gleichzeitig laufen zu lassen
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;        // zählt 1 Sekunde runter


        countdown = Mathf.Clamp(countdown,0f, Mathf.Infinity);  //Countdown soll nicht negativ werden
        waveCountdownText.text = string.Format("{0:00.00}",countdown); 
    }

    //Managet die Waves grade noch linear, sollte durch Polynomialfunktion geändert werden
    // IEnumerator ermöglicht das warten in einer Funktion
    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);  //wartet Anzahl an sekunden
        }
    }

    //Spawnt Gegner an Startposition
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
