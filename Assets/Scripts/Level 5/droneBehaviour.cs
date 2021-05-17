using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneBehaviour : MonoBehaviour
{
    public float movingSpeed;
    public Vector3[] positions;
    private int index;

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
        movement();
        shoot();
    }

    void movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * movingSpeed);
        if (transform.position == positions[index])
        {
            if (index == positions.Length -1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }

    void shoot()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
