using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int MHP;
    private int HP;
    public float Spd;

    void Start()
    {
        HP = MHP;
    }

    public void changeHP(int amount)
    {
        HP += amount;
        HP = (HP > MHP) ? MHP : HP;
        if (HP < 0)
        {
            Destroy(gameObject);
        }
    }
}
