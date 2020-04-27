using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class turret_Ai : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Stats")]
    private Transform target;
    private enemy_Ai enemytarget;
    private NavMeshAgent enemymove;
 
    [Header ("Bullet stats")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab; 

    [Header("laser stats")]
    public bool uselaser = false;
    public LineRenderer linerenderer;
    public int damageovertime = 30;
    public float slowdown = 0.5f;
 
    [Header ("basic turret ai")]
    public string enemyTag = "Enemy";
    public float range = 15f;
    public Transform rotate;
    public float turnSpeed = 10f;
    public AudioClip rocket;
    public AudioSource audioSource;

    
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        audioSource = GetComponent<AudioSource>();
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            enemytarget = nearestEnemy.GetComponent<enemy_Ai>();
            enemymove = nearestEnemy.GetComponent<NavMeshAgent>();
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (uselaser)
            {
                if (linerenderer.enabled)
                    linerenderer.enabled = false;

                
            }
            return;
        }
        

        lockon();

        if (uselaser)
        {
            laser();
        }
        else
        {


            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;

            }
            fireCountdown -= Time.deltaTime;
        }
    }
    void lockon()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotate.rotation, lookrotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotate.rotation = Quaternion.Euler(-90f, rotation.y, 0f);
    }

    void laser()
    {
        enemytarget.damagetaken(damageovertime * Time.deltaTime);
          enemytarget.Slow(slowdown); 
       
        if (!linerenderer.enabled)
            linerenderer.enabled = true;
        linerenderer.SetPosition (0, firePoint.position);
        linerenderer.SetPosition(1, target.position);
    }
    void Shoot()
    {
       
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet bullet = bulletGo.GetComponent<bullet>();

        if (bullet != null)
            bullet.aim(target);
        audioSource.Play();

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        
    }
}
