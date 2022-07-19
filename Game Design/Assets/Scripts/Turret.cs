using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public Transform targetLocked;
    private Enemy targetEnemy;
    public bool isUpgraded = false;


    [Header("General")]
    public float range = 10f;

    [Header("Bullet(Default)")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject projectilePrefab;

    [Header("Laser")]
    public bool useLaserTurret = false;
    public float damageOverTime = 30f;
    public float slowAmount = 0.5f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;
    public AudioClip laserBeamSfx;
    public bool laserOn = false;

    [Header("SetUp")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;
    public float targetUpdateTime = 0.1f;
    public AudioClip turretShootSfx;
    public AudioClip missileLauncherShootSfx;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, targetUpdateTime); // Widerholt die funktion jede Anzahl an Sekunden
    }

    // Gegnersuche
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistanceToEnemy = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            targetEnemy = enemy.GetComponent<Enemy>();
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);


            if (distanceToEnemy < shortestDistanceToEnemy)
            {
                shortestDistanceToEnemy = distanceToEnemy;

                nearestEnemy = enemy;
            }
        }
  
        if (nearestEnemy != null && shortestDistanceToEnemy <= range )
        {
            target = nearestEnemy.transform;
            targetEnemy = target.GetComponent<Enemy>();
        }
        else
            target = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            if (useLaserTurret)
            {
                if (lineRenderer.enabled)
                {
                    laserOn = false;
                    LaserAudio(laserOn);
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
                return;
            }
        }
        else
        {


            //TARGET LOCKED
            LockOnTarget();

            if (useLaserTurret)
            {
                laserOn = true;
                Laser(laserOn);
            }
            else
            {
                if (fireCountdown <= 0f)
                {
                    if (this.CompareTag("MissileLauncher") && isUpgraded)
                    {
                        ShootUpgradedMissileLauncher();

                        Invoke("ShootUpgradedMissileLauncher", 0.2f);

                    }
                    else
                    {
                        Shoot();
                    }
                    fireCountdown = 1f / fireRate;
                }

                fireCountdown -= Time.deltaTime;
            }
        }
    
    }

    void LockOnTarget()
    {
        Vector3 directionToEnemy = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(directionToEnemy);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser(bool _laserOn)
    {

        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);

        //Laser und Licht An
        if (!lineRenderer.enabled)
        {
            LaserAudio(_laserOn);

            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }


        // Laser Position
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);


        //Impact Effekt Position
        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void LaserAudio(bool _laserOn)
    {
        AudioSource laserAudio = GetComponent<AudioSource>();
        laserAudio.clip = laserBeamSfx;
        if (laserOn)
        {
            laserAudio.loop = _laserOn;
            laserAudio.Play();
        }
        else
            laserAudio.Stop();
    }

    void Shoot()
    {

        GameObject bulletGO = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        

        if (this.CompareTag("StandardTurret"))
            AudioSource.PlayClipAtPoint(turretShootSfx, Camera.main.transform.position);
        else
            AudioSource.PlayClipAtPoint(missileLauncherShootSfx, Camera.main.transform.position);

        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }

    void ShootUpgradedMissileLauncher()
    {
        GameObject bulletGO = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        AudioSource.PlayClipAtPoint(missileLauncherShootSfx, Camera.main.transform.position);


        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);

    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    
}
