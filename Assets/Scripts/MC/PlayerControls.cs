using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator anim;
    private Rigidbody2D rb;
    private FeetHitbox legs;
    public PauseManager pauseManager;

    public float speed;
    public bool allowBtnPress = true;
    public bool allowClick = true;
    public bool allowPause = true;
    public GameObject attack;
    public PhysicsMaterial2D[] friction;
    public float coyoteTimer;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        legs = gameObject.GetComponentInChildren<FeetHitbox>();
    }

    private void Update()
    {
        if (transform.position.y < -100)
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
        }

        if (allowBtnPress)
        {
            DoBtnInput();
        }

        if (allowPause && Input.GetKeyDown(KeyCode.Escape))
        {
            DoPause();
        }

        if (allowClick)
        {
            DoMouseClick();
        }

        anim.SetBool("isWalking", false);
        rb.sharedMaterial = friction[1];
        if (Input.GetKey(KeyCode.A) != Input.GetKey(KeyCode.D) && allowBtnPress)
        {
            anim.SetBool("isWalking", true);
            rb.sharedMaterial = friction[0];
            sprite.flipX = Input.GetKey(KeyCode.A);
        }
    }

    private void DoBtnInput()
    {
        foreach (KeyCode key in new[] { KeyCode.A, KeyCode.D })
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
    
    private void DoMouseClick()
    {
        for (int button = 0; button < 2; button++)
        {
            if (Input.GetMouseButtonDown(button))
            {
                switch (button)
                {
                    case 0: //Left click
                        GameObject atk = Instantiate(attack);
                        atk.transform.position = transform.position;
                        float angle = (sprite.flipX) ? 180 : 0;
                        angle = Input.GetKey(KeyCode.W) ? 90 : angle;
                        atk.transform.eulerAngles = new Vector3(0, 0, angle);
                        return;

                    case 1: //Right click
                        Debug.Log("Right click");
                        return;
                }
            }
        }
    }

    public void DoPause()
    {
        if (!pauseManager.SafeToUnpause())
        {
            return;
        }
        Time.timeScale = 1 - Time.timeScale;
        pauseManager.SetPauseState(allowBtnPress);
        AllowInput(!allowBtnPress);
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
            Stop();
        }
    }

    private void KeyUpAction(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.A:
            case KeyCode.D:
                Stop();
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
    }

    /// <summary>
    /// Sets the position of the player.
    /// </summary>
    /// <param name="x">X coordinate.</param>
    /// <param name="y">Y coordinate.</param>
    /// <param name="z">Z coordinate.</param>
    public void SetPosition(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }

    /// <summary>
    /// Allow the player to jump.
    /// </summary>
    /// <param name="boolean">true to be able to jump</param>
    public void canJump(bool boolean)
    {
        legs.canJump = boolean;
    }

    /// <summary>
    /// Stop the player from moving.
    /// </summary>
    public void Stop()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    /// <summary>
    /// Toggle player input and stops movement
    /// </summary>
    public void AllowInput(bool boolean)
    {
        allowBtnPress = boolean;
        allowClick = boolean;
        canJump(boolean);
        Stop();
    }
}
