using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneBullet : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;

    public int damageStrength;
    private StatManager statManager;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * -1.0f * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.transform.tag != "Enemy")
        {
            if (hitObject.transform.tag == "Player")
            {
                if (statManager == null)
                {
                    statManager = hitObject.transform.GetComponent<PlayerControls>().statManager;
                }
                statManager.changeHP(-damageStrength);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
