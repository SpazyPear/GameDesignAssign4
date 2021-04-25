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
    private bool hasJumped = true;
    private bool onGround = false;

    private bool canJump;
    void Start()
    {
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
        anim = gameObject.GetComponentInParent<Animator>();
        canJump = true;
    }

    void Update()
    {
        delta = Time.deltaTime;
        if (canJump)
        {
            spaceInput();
        }
        anim.SetBool("onGround", onGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "FakeGround":
            case "Ground":
                groundContacts.Add(collision);
                jumps = maxJumps;
                jumpcounter = jumptimer;
                hasJumped = false;
                onGround = true;
                return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "FakeGround":
            case "Ground":
                groundContacts.Remove(collision);
                jumps -= (!hasJumped) ? 1 : 0;
                onGround = !(groundContacts.Count == 0 || hasJumped);
                return;
        }
    }

    private void spaceInput()
    {
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
    }

    /// <summary>
    /// Toggle where the player can jump or not
    /// </summary>
    /// <param name="boolean">true to be able to jump</param>
    public void ToggleJump(bool boolean)
    {
        canJump = boolean;
    }
}
