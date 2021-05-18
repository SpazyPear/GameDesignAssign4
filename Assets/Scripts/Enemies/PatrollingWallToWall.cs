using UnityEngine;

public class PatrollingWallToWall : MonoBehaviour
{
    public float enemyMovementSpeed = 3.0f;
    public bool goingRight;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private EnemyStats enemyStats;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyStats = GetComponent<EnemyStats>();
        sprite = GetComponent<SpriteRenderer>();
        flip();
    }

    void Update()
    {
        rb.velocity = new Vector2((goingRight ? 1 : -1) * enemyMovementSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        flip();
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerControls>().statManager.changeHP(-enemyStats.damageStrength);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            enemyStats.changeHP(-collision.GetComponent<Attack>().str);
        }
    }

    void flip()
    {
        goingRight = !goingRight;
        sprite.flipX = goingRight;
    }
}
