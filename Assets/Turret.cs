using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _target;
    [Header("Atributes")]
    // Range
    public float range = 15f;
    //Shooting
    public float fireRate = 1f;
    private float _fireCd = 0f;

    [Header("Unity Setup Fields")]
    // enemy tag
    public string enemyTag = "Enemy";
    //Head rotation
    public Transform partToRotate;
    public float turnSpeed = 10f;
    // bullet
    public GameObject bulletPrefab;
    public Transform firePoint;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Updating target
    void UpdateTarget()
	{
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float ShortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < ShortestDistance)
			{
                ShortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
			}
		}

        if (nearestEnemy != null && ShortestDistance <= range)
		{
            _target = nearestEnemy.transform;
		}
        else
        {
            _target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //targeting and rotatiing to target
        if (_target == null)
		{
            return;    
        }
        Vector3 dir = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //shooting
        if (_fireCd <= 0f)
        {
            Shoot();
            _fireCd = 1f / fireRate;
		}

        _fireCd -= Time.deltaTime;
    }
    
    // Shooting function
    void Shoot()
	{
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
		{
            bullet.Seek(_target);
		}
	}

    // drawing gismos
	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
	}
}
