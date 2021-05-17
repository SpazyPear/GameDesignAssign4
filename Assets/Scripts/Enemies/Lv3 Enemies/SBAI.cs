using UnityEngine;

public class SBAI : MonoBehaviour
{
    private Transform player;
    private InTerritory inTerritory;
    private SpriteRenderer sprite;
    private EnemyStats stats;

    public bool invincible;

    void Start()
    {
        stats = GetComponent<EnemyStats>();
        sprite = GetComponentInParent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inTerritory = GetComponentInChildren<InTerritory>();
    }

    void Update()
    {
        if (inTerritory.playerInRange)
        {
            sprite.flipX = player.position.x > transform.position.x;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack") && !invincible)
        {
            stats.changeHP(-collision.transform.GetComponent<Attack>().str);
            Destroy(collision.gameObject);
        }
    }
}
