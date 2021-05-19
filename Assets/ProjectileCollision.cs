using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageStrength;
    private Rigidbody2D rb;
    private float xMult;
    private float yMult;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(xMult * 10, yMult * 10), ForceMode2D.Impulse);
        }
    }

    public void SetMult(float x, float y)
    {
        xMult = x;
        yMult = y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerControls>().statManager.changeHP(-damageStrength);
            Destroy(gameObject);
        }
    }
}
