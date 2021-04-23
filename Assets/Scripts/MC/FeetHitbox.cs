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
    private bool hasJumped = false;
    private bool onGround = false;

    void Start()
    {
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
        anim = gameObject.GetComponentInParent<Animator>();
    }

    void Update()
    {
        delta = Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && (jumps > 0 || onGround))
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
            hasJumped = jumpcounter > 0 && hasJumped;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpcounter = 0;
        }

        anim.SetBool("onGround", onGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Ground":
                groundContacts.Add(collision);
                rb.velocity.Set(rb.velocity.x, 0);
                ResetJump();
                return;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Ground":
                jumps -= (!hasJumped) ? 1 : 0;
                groundContacts.Remove(collision);
                onGround = !(groundContacts.Count == 0 || hasJumped);
                return;
        }
    }

    private void ResetJump()
    {
        jumps = maxJumps;
        jumpcounter = jumptimer;
        hasJumped = false;
        onGround = true;
    }
}
