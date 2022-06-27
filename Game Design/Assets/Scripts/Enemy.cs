using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Attribute")]
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    public float health;

    public int moneyGain = 50;
    public GameObject deathEffect;

    [Header("Unity")]
    public Image healthBar;
    public AudioClip enemyDeathSfx;

    private bool isDead = false;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health/startHealth;

        if (health <= 0 && !isDead)
            Die();
    }

    public void Slow(float slowValue)
    {
        speed = startSpeed * (1f - slowValue);
    }

    private void Die()
    {
        isDead = true;

        PlayerStats.Money += moneyGain;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(enemyDeathSfx, Camera.main.transform.position);
        

        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

}
