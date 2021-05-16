using System.Collections;
using UnityEngine;

public class FeetHitbox : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    private ArrayList groundContacts = new ArrayList();
    private float delta;

    public float jumpStr;
    public int maxJumps;
    private int jumps;
    public float jumptimer;
    private float jumpcounter;

    public float coyoteTimer;
    private float coyoteTime;
    private bool isFalling;

    private bool hasJumped = true;
    private bool onGround = false;
    public bool canWallJump = false;
    public int wallJumps = 0;

    public bool canJump;
    void Start()
    {
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
        anim = gameObject.GetComponentInParent<Animator>();
        canJump = true;
        coyoteTime = coyoteTimer;
    }

    void Update()

    {
        Debug.Log(wallJumps);
        delta = Time.deltaTime;
        coyoteTime = (onGround) ? coyoteTimer : coyoteTime - delta;
        if (coyoteTime < 0 && !isFalling && !hasJumped)
        {
            jumps -= 1;
            isFalling = true;
        }

        if (canJump)
        {
            spaceInput();
        }

        if (canWallJump)
        {
            wallJump();
        }

        anim.SetBool("onGround", onGround);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Turret")
        {
            wallJumps = 0;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "FakeGround":
            case "Boulder":
            case "Ground":
                groundContacts.Add(collision);
                Vector2 pos = transform.position;
                pos = new Vector2(pos.x, pos.y - 0.1f);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.down, 0.01f);
                if (hit.collider != null)
                {
                    ResetJump();
                }
                return;
            case "Turret":
                groundContacts.Add(collision);
                Vector2 pos2 = transform.position;
                pos2 = new Vector2(pos2.x, pos2.y - 0.1f);
                RaycastHit2D hit2 = Physics2D.Raycast(pos2, Vector2.down, 0.01f);
                if (hit2.collider != null)
                {
                    ResetJump();
                }
                return;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "FakeGround":
            case "Boulder":
            case "Ground":
                ResetJump();
                return;
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "FakeGround":
            case "Boulder":
            case "Ground":
                groundContacts.Remove(collision);
                onGround = !(groundContacts.Count == 0 || hasJumped);
                return;
            case "Turret":
                groundContacts.Remove(collision);
                onGround = !(groundContacts.Count == 0 || hasJumped);
                return;
            case "Wall":
                groundContacts.Add(collision);
                Vector2 pos2 = transform.position;
                pos2 = new Vector2(pos2.x, pos2.y - 0.1f);
                RaycastHit2D hit2 = Physics2D.Raycast(pos2, Vector2.down, 0.01f);
                if (hit2.collider == null)
                {
                    ResetJump();
                }
                return;
        }
    }

    private void spaceInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (jumps > 0))
        {
            rb.velocity = Vector2.up * jumpStr;
            jumps -= 1;
            jumpcounter = jumptimer;
            hasJumped = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpcounter > 0 && hasJumped)
            {
                rb.velocity = Vector2.up * jumpStr;
                jumpcounter -= delta;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpcounter = 0;
        }
    }

    private void ResetJump()
    {
        jumps = maxJumps;
        jumpcounter = jumptimer;
        hasJumped = false;
        onGround = true;
        isFalling = false;
        wallJumps = 0;
    }

    private void wallJump()
    {
        Debug.Log(wallJumps);
        canJump = false;
        float oldG = rb.gravityScale;
        rb.gravityScale = 2;
        if (Input.GetKeyDown(KeyCode.Space) && wallJumps < 2)
        {
            Vector2 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            rb.AddForce(input*120, ForceMode2D.Impulse);
            wallJumps++;
        }
        rb.gravityScale = oldG;
        canJump = true;
    }
}