using UnityEngine;

public class Jump : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private float delta;

    public Transform feet;
    public LayerMask groundDetection;
    public float detectionRadius;
    public float jumpStr;
    public int maxJumps;
    public int jumps;
    public float jumptimer;
    private float jumpcounter;

    public float coyoteTimer;
    private float coyoteTime;
    private bool isFalling;

    private bool hasJumped = true;
    public bool onGround = false;

    public bool canJump;

    public float strongGravity;
    public float weakGravity;

    public int wallJumpState = 0;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        canJump = true;
        coyoteTime = coyoteTimer;
    }

    void Update()
    {
        delta = Time.deltaTime;
        coyoteTime = (onGround) ? coyoteTimer : coyoteTime - delta;
        if (coyoteTime < 0 && !isFalling && !hasJumped)
        {
            jumps -= 1;
            isFalling = true;
        }

        rb.gravityScale = (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space) && canJump) ? weakGravity : strongGravity;
        if (canJump)
        {
            spaceInput();
        }

        onGround = Physics2D.OverlapBox(feet.position, new Vector2(1f, 0.1f), 0, groundDetection);
        if (onGround && rb.velocity.y == 0)
        {
            ResetJump();
        }

        anim.SetBool("onGround", onGround);
    }

    private void spaceInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (jumps > 0))
        {
            jumps--;
            if (wallJumpState == 1)
            {
                wallJumpState++;
                jumps = maxJumps - 1;
            }
            jumpcounter = jumptimer;
            hasJumped = true;
            onGround = false;
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
        isFalling = false;
        wallJumpState = 0;
    }
}