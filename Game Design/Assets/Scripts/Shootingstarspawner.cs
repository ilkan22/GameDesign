using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootingstarspawner : MonoBehaviour
{
    public GameObject[] shootingStar;
    public Vector3 spawnValue;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int randstar;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            randstar = Random.Range(0, shootingStar.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), -10, Random.Range(-spawnValue.z, spawnValue.z));
            Instantiate(shootingStar[randstar], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
