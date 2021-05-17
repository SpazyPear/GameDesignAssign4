using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform firePoint;
    public bool canShoot;
    public GameObject projPrefab;

    // Update is called once per frame
    void Update()
    {
        if (canShoot) {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        }
    }

    void Fire()
    {
        Instantiate(projPrefab, firePoint.position, firePoint.rotation);
    }
}
