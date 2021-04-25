using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator anim;
    private Rigidbody2D rb;
    private KeyCode[] keysAvailable;
    private FeetHitbox legs;

    public float speed;
    public bool allowInput;
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        legs = gameObject.GetComponentInChildren<FeetHitbox>();
        keysAvailable = new []{KeyCode.A, KeyCode.D};
    }

    private void Update()
    {
        if (transform.position.y < -100)
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
        }

        if (allowInput)
        {
            DoInput();
        }

        anim.SetBool("isWalking", false);
        if (Input.GetKey(KeyCode.A) != Input.GetKey(KeyCode.D) && allowInput)
        {
            anim.SetBool("isWalking", true);
            sprite.flipX = Input.GetKey(KeyCode.A);
        }
    }

    private void DoInput()
    {
        foreach (KeyCode key in keysAvailable)
        {
            /*if (Input.GetKeyDown(key))
            {
                KeyDownAction(key);
            }*/

            if (Input.GetKey(key))
            {
                KeyAction(key);
            }

            if (Input.GetKeyUp(key))
            {
                KeyUpAction(key);
            }
        }
    }

    private void KeyDownAction(KeyCode key)
    {
    }

    private void KeyAction(KeyCode key)
    {
        switch(key)
        {
            case KeyCode.A:
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                break;

            case KeyCode.D:
                rb.velocity = new Vector2(speed, rb.velocity.y);
                break;
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void KeyUpAction(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.A:
            case KeyCode.D:
                rb.velocity = new Vector2(0, rb.velocity.y);
                return;
        }
    }

    /// <summary>
    /// Set the player to either be visible or not
    /// </summary>
    /// <param name="boolean">true to show/false to hide</param>
    public void SetActive(bool boolean)
    {
        sprite.enabled = boolean;
        rb.simulated = boolean;
        allowInput = boolean;
        canJump(boolean);
        transform.position = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// Allow the player to jump.
    /// </summary>
    /// <param name="boolean">true to be able to jump</param>
    public void canJump(bool boolean)
    {
        legs.ToggleJump(boolean);
    }

    public void Stop()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}
