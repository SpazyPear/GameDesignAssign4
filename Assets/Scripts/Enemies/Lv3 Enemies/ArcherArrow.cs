using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherArrow : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    
    public float airTime = 5.0f; // Projectile stays active for airTime sec then despawns
    private int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(airTime > 0){
            airTime -= Time.deltaTime;
        } else {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hit) {
        if(hit.transform.tag != "Enemy"){
            if(hit.transform.tag == "Player"){
                hit.gameObject.GetComponent<PlayerControls>().statManager.changeHP(-damage);
            }
            Destroy(gameObject);
        }
    }
}
