using UnityEngine;

public class Jump : MonoBehaviour
{
    public SFXManager sfxManager;
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

    public bool canWallJump = false;
    public int wallJumps = 0;

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

        onGround = Physics2D.OverlapBox(feet.position, new Vector2(0.9f, 0.1f), 0, groundDetection);
        if (onGround && rb.velocity.y == 0)
        {
            
            ResetJump();
        }

        if (canWallJump && onGround == false)
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

    private void spaceInput()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && (jumps > 0))
        {
            jumps -= 1;
            jumpcounter = jumptimer;
            hasJumped = true;
            sfxManager.Play(0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpcounter > 0 && hasJumped)
            {
                
                rb.velocity = new Vector2(rb.velocity.x, jumpStr);
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
        wallJumps = 0;
    }

    private void wallJump()
    {
        canJump = false;
        float oldG = rb.gravityScale;
        rb.gravityScale = 2;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 input = new Vector3(Input.GetAxisRaw("Horizontal"), 1);
            rb.AddForce(input * 120, ForceMode2D.Impulse);
            wallJumps++;
        }
        rb.gravityScale = oldG;
        canJump = true;
    }
}