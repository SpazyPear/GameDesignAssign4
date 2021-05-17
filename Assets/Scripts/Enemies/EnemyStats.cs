using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int MHP;
    public int HP;
    public int damageStrength;
    public GameObject parentobj;

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

    private void DoesEnemyDie()
    {
        if (HP <= 0)
        {
            Destroy(parentobj == null ? gameObject : parentobj);
        }
    }
}
