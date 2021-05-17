using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float movementSpeed;
    private InTerritory inTerritory;
    private Transform playerPos;
    private EnemyStats enemyStats;
    private StatManager statManager;

    private void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        inTerritory = GetComponentInChildren<InTerritory>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (inTerritory.playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos.position, movementSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (statManager == null)
            {
                statManager = collision.transform.GetComponent<PlayerControls>().statManager;
            }
            statManager.changeHP(-enemyStats.damageStrength);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            enemyStats.changeHP(-collision.transform.GetComponent<Attack>().str);
            Destroy(collision.gameObject);
        }
    }
}
