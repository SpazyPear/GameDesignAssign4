using UnityEngine;

public class SBAI : MonoBehaviour
{
    private Transform player;
    public InTerritory inTerritory;
    public InTerritory inMeleeRange;
    private SpriteRenderer sprite;
    private EnemyStats stats;
    private Animator anim;

    public bool invincible;
    public bool hurtWhenTouch;
    private bool attacking;

    void Start()
    {
        stats = GetComponent<EnemyStats>();
        sprite = GetComponentInParent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        invincible = anim.GetBool("isBlocking");
        anim.SetBool("isBlocking", inTerritory.playerInRange && !attacking);
        hurtWhenTouch = anim.GetCurrentAnimatorStateInfo(0).IsName("Attack");
        if (attacking)
        {
            anim.SetTrigger("Attack");
        }
        if (inTerritory.playerInRange)
        {
            sprite.flipX = player.position.x > transform.position.x;
            attacking = inMeleeRange.playerInRange;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") & hurtWhenTouch)
        {
            hurtWhenTouch = false;
            collision.transform.GetComponent<PlayerControls>().statManager.changeHP(-stats.damageStrength);
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
