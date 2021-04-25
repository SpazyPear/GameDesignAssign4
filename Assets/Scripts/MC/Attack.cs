using UnityEngine;

public class Attack : MonoBehaviour
{
    public int str;
    public float lifeSpan;
    private float delta;

    void Update()
    {
        delta = Time.deltaTime;
        if ((lifeSpan -= delta) < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyStats>().changeHP(-str);
        }
    }
}
