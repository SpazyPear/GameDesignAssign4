using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Enemy")
        {
            hitInfo.gameObject.GetComponent<EnemyStats>().changeHP(1);
        }
        Destroy(gameObject);
    }
}
