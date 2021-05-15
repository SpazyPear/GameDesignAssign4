using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (HP < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Contains("Player"))
        {
            Destroy(this.gameObject, 0f);
            if (statManager == null)
            {
                statManager = collision.transform.GetComponent<PlayerControls>().statManager;
            }
            statManager.changeHP(-damageStrength);
        }
    }
}

