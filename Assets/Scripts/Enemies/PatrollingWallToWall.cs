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
        if (rb.velocity.x == 0)
        {
            flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.transform.tag)
        {
            case "Enemy":
            case "Hazard":
            case "Wall":
                flip();
                return;
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
