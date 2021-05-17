using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineGunBehaviour : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;
    private float nextFire;
    [SerializeField]
    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }
    void shoot()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation, transform);
            nextFire = Time.time + fireRate;
        }
    }
}
