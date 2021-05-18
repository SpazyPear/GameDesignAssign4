using UnityEngine;

public class ArcherAI : MonoBehaviour
{
    private Animator anim;
    private EnemyStats stats;
    private SpriteRenderer sprite;
    private InTerritory combatRange;
    private Transform player;

    public float shootingInterval = 3;
    private float shootingTimer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        stats = GetComponent<EnemyStats>();
        sprite = GetComponentInParent<SpriteRenderer>();
        combatRange = GetComponentInChildren<InTerritory>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shootingTimer = shootingInterval;
    }

    // Update is called once per frame
    void Update()
    {
        shootingTimer -= Time.deltaTime;
        if (combatRange.playerInRange)
        {
            sprite.flipX = transform.position.x > player.position.x;
            if (shootingTimer <= 0)
            {
                anim.SetTrigger("shoot");
                shootingTimer = shootingInterval;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Attack")){
            stats.changeHP(-other.GetComponent<Attack>().str);
            Destroy(other);
        }
    }
}
