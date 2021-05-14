using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int MHP;
    private int HP;
    public int damageStrength;

    private StatManager statManager;
    void Start()
    {
        HP = MHP;
    }

    public void changeHP(int amount)
    {
        HP += amount;
        HP = (HP > MHP) ? MHP : HP;
        DoesEnemyDie();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Contains("Player"))
        {
            if (statManager == null)
            {
                statManager = collision.transform.GetComponent<PlayerControls>().statManager;
            }
            statManager.changeHP(-damageStrength);
            DoesEnemyDie();
        }
    }

    private void DoesEnemyDie()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
