using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private float delta;

    public float speed;
    public float jumpStr;

    public int maxJumps;
    private int jumps;
    private bool isJumping;
    public float jumptimer;
    private float jumpcounter;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        delta = Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            sprite.flipX = true;
            transform.Translate(-speed * delta, 0, 0, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            sprite.flipX = false;
            transform.Translate(speed * delta, 0, 0, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
            rb.velocity = Vector2.up * jumpStr;
            jumps -= 1;
            isJumping = true;
            jumpcounter = jumptimer;
        }

        if (Input.GetKey(KeyCode.Space) && jumpcounter > 0 && isJumping)
        {
            rb.velocity = Vector2.up * jumpStr;
            jumpcounter -= delta;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    public void setActive(bool boolean)
    {
        sprite.enabled = boolean;
        rb.simulated = boolean;
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Ground"))
        {
            rb.velocity.Set(rb.velocity.x, 0);
            jumps = maxJumps;
            jumpcounter = jumptimer;
        }
    }
}
