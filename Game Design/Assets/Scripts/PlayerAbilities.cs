using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    public float fireRateMultiplier = 1.5f;
    public float rangeMultiplier = 1.2f;
    public float laserDamageOverTimeMultiplier = 1.5f;
    public float abilityCoolDown = 60f;
    public float abilityDuration = 5f;
    public Text abilityCountdownText;
    public Text abilityDurationText;


    private float damageOverTimeOld;
    private float missileFireRateOld;
    private float missileRangeOld;
    private float standardFireRateOld;
    private float standardRangeOld;

    private bool countDownActive = false;
    private bool duractionActive = false;
    private float countdown = 0f;
    private float duration = 0f;
    private GameObject[] laserTurrets;
    private GameObject[] missileLaunchers;
    private GameObject[] standardTurrets;

    private Turret laserTurret;
    private Turret missileLauncher;
    private Turret standardTurret;


    // Update is called once per frame
    void Update()
    {
        laserTurrets = GameObject.FindGameObjectsWithTag("LaserTurret");
        missileLaunchers = GameObject.FindGameObjectsWithTag("MissileLauncher");
        standardTurrets = GameObject.FindGameObjectsWithTag("StandardTurret");

        if ((Input.GetKey("g") && !countDownActive))
        {
            Debug.Log("G GEDR����CKT");
            countDownActive = true;
            duractionActive = true;
            TowerBoost();
            countdown = abilityCoolDown;
            duration = abilityDuration;
            return;
        }

        if (duration <= 0f && duractionActive)
        {
            TowerBoostOff();
            duractionActive = false;
            return;
        }

        if (countdown <= 0f)
        {
            countDownActive = false;
            return;
        }

        duration -= Time.deltaTime;        // z�hlt 1 Sekunde runter
        countdown -= Time.deltaTime;        // z�hlt 1 Sekunde runter
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);  //Countdown soll nicht negativ werden
        duration = Mathf.Clamp(duration, 0f, Mathf.Infinity);  //Countdown soll nicht negativ werden
        abilityCountdownText.text = string.Format("AbilityCoolDown " + "{0:00.00}", countdown);
        abilityDurationText.text = string.Format("AbilityDuration " + "{0:00.00}", duration);
    }

    void TowerBoost()
    {
        Debug.Log("TOWEEEERBOOOOOOOST");


        foreach (GameObject _laserTurret in laserTurrets)
        {
            laserTurret = _laserTurret.GetComponent<Turret>();
            damageOverTimeOld = laserTurret.damageOverTime;
            laserTurret.damageOverTime = laserTurret.damageOverTime * laserDamageOverTimeMultiplier;
        }

        foreach (GameObject _missileLauncher in missileLaunchers)
        {
            missileLauncher = _missileLauncher.GetComponent<Turret>();
            missileFireRateOld = missileLauncher.fireRate;
            missileRangeOld = missileLauncher.range;
            missileLauncher.fireRate = missileLauncher.fireRate * fireRateMultiplier;
            missileLauncher.range = missileLauncher.range * rangeMultiplier;
        }

        foreach (GameObject _standardTurret in standardTurrets)
        {
            standardTurret = _standardTurret.GetComponent<Turret>();
            standardFireRateOld = standardTurret.fireRate;
            standardRangeOld = standardTurret.range;
            standardTurret.fireRate = standardTurret.fireRate * fireRateMultiplier;
            standardTurret.range = standardTurret.range * rangeMultiplier;
        }
    }
    void TowerBoostOff()
    {
        foreach (GameObject _laserTurret in laserTurrets)
        {
            laserTurret.damageOverTime = damageOverTimeOld;
        }

        foreach (GameObject _missileLauncher in missileLaunchers)
        {
            missileLauncher.fireRate = missileFireRateOld;
            missileLauncher.range = missileRangeOld;
        }

        foreach (GameObject _standardTurret in standardTurrets)
        {
            standardTurret.fireRate = standardFireRateOld;
            standardTurret.range = standardRangeOld;
        }
    }

}