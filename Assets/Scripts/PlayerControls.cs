using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator anim;
    private Rigidbody2D rb;
    private float delta;
    private KeyCode[] keysAvailable;

    public float speed;

    public float jumpStr;
    public int maxJumps;
    private int jumps;
    public float jumptimer;
    private float jumpcounter;
    private bool hasJumped = false;
    private bool onGround = false;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        keysAvailable = new []{KeyCode.A, KeyCode.D, KeyCode.Space};

    }

    private void Update()
    {
        delta = Time.deltaTime;
        doInput();

        if (transform.position.y < -20)
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
        }

        anim.SetBool("IsWalking", (Input.GetKey(KeyCode.A) != Input.GetKey(KeyCode.D)));
    }

    private void doInput()
    {
        foreach (KeyCode key in keysAvailable)
        {
            if (Input.GetKeyDown(key))
            {
                keyDownAction(key);
            }

            if (Input.GetKey(key))
            {
                keyAction(key);
            }

            if (Input.GetKeyUp(key))
            {
                keyUpAction(key);
            }
        }
    }

    private void keyDownAction(KeyCode key)
    {
        switch(key)
        {
            case KeyCode.Space:
                if (jumps > 0 || onGround)
                {
                    rb.velocity = Vector2.up * jumpStr;
                    jumps -= 1;
                    jumpcounter = jumptimer;
                    hasJumped = true;
                }
                return;
        }
    }

    private void keyAction(KeyCode key)
    {
        switch(key)
        {
            case KeyCode.A:
                sprite.flipX = true;
                transform.Translate(-speed * delta, 0, 0, Space.World);
                return;

            case KeyCode.D:
                sprite.flipX = false;
                transform.Translate(speed * delta, 0, 0, Space.World);
                return;

            case KeyCode.Space:
                if (jumpcounter > 0 && hasJumped)
                {
                    rb.velocity = Vector2.up * jumpStr;
                    jumpcounter -= delta;
                }
                hasJumped = jumpcounter > 0 && hasJumped;
                return;
        }
    }

    private void keyUpAction(KeyCode key)
    {
        switch(key)
        {
            case KeyCode.Space:
                jumpcounter = 0;
                return;
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
            hasJumped = false;
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Ground"))
        {
            onGround = false;
            if (!hasJumped)
            {
                jumps -= 1;
            }
        }
    }
}
