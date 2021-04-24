using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator anim;
    private Rigidbody2D rb;
    private KeyCode[] keysAvailable;
    private FeetHitbox legs;

    public float speed;
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

        anim.SetBool("isWalking", false);

        DoInput();
        if (Input.GetKey(KeyCode.A) != Input.GetKey(KeyCode.D))
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
                rb.velocity = new Vector2(0, rb.velocity.y);
                return;

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
        transform.position = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// Change the controls of the player
    /// </summary>
    /// <param name="newSet">Set the controls of what the player can do</param>
    public void changeControls(KeyCode[] newSet)
    {
        keysAvailable = newSet;
    }

    /// <summary>
    /// Allow the player to jump.
    /// </summary>
    /// <param name="boolean">true to be able to jump</param>
    public void canJump(bool boolean)
    {
        legs.ToggleJump(boolean);
    }
}
