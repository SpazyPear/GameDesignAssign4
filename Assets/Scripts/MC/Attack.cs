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
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Enemy":
                
                collision.GetComponent<EnemyStats>().changeHP(-str);
                return;

            case "Boulder":
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.None;
                rb.AddForce(new Vector2(1000, 50), ForceMode2D.Impulse);
                return;
        }
        lifeSpan = 0;
    }
}
