using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attribute")]
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int moneyGain = 50;
    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
            Die();
    }

    public void Slow(float slowValue)
    {
        speed = startSpeed * (1f - slowValue);
    }

    private void Die()
    {
        PlayerStats.Money += moneyGain;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(effect, 5f);
        Destroy(gameObject);
    }

}
