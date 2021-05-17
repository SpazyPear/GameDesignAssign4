using UnityEngine;

public class BoulderAI : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.AddForce(new Vector2(1000, 50), ForceMode2D.Impulse);
        }
    }
}
