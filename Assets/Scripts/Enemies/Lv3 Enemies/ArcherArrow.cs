using UnityEngine;

public class ArcherArrow : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private SpriteRenderer sprite;
    
    public float airTime = 5.0f; // Projectile stays active for airTime sec then despawns
    private Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = transform.parent.position;
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = Player.position.x < transform.position.x;
        rb.velocity = transform.right * speed * (sprite.flipX ? 1 : -1);
    }

    // Update is called once per frame
    void Update()
    {
        if((airTime -= Time.deltaTime) < 0){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hit) {
        if(!hit.CompareTag("Enemy")){
            if(hit.CompareTag("Player")){
                hit.gameObject.GetComponent<PlayerControls>().statManager.changeHP(-GetComponent<EnemyStats>().damageStrength);
            }
            Destroy(gameObject);
        }
    }
}
