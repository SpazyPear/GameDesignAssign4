using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator anim;
    private Rigidbody2D rb;
    private Jump legs;

    public PauseManager pauseManager;
    public StatManager statManager;

    public float speed;
    public float climbSpeed;
    public bool allowBtnPress = true;
    public bool allowClick = true;
    public bool allowPause = true;
    public bool canClimb;
    public GameObject attack;
    public PhysicsMaterial2D[] friction;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        legs = gameObject.GetComponent<Jump>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(allowBtnPress ? Input.GetAxisRaw("Horizontal") * speed : 0, rb.velocity.y);
        anim.SetBool("isWalking", false);
        rb.sharedMaterial = friction[1];
        if (Input.GetKey(KeyCode.A) != Input.GetKey(KeyCode.D) && allowBtnPress)
        {
            anim.SetBool("isWalking", true);
            rb.sharedMaterial = friction[0];
            sprite.flipX = Input.GetKey(KeyCode.A);
        }

        if (allowPause && Input.GetKeyDown(KeyCode.Escape))
        {
            DoPause();
        }

        if (allowClick && Input.GetMouseButtonDown(0)) //Left click
        {
            DoMouseClick();
        }

        anim.SetBool("isClimbing", false);
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isClimbing", canClimb);
            rb.velocity = new Vector2(rb.velocity.x, (canClimb) ? climbSpeed * Input.GetAxisRaw("Vertical") : rb.velocity.y);
        }
    }

    private void DoMouseClick()
    {
        GameObject atk = Instantiate(attack, transform);
        atk.transform.position = transform.position;
        float angle = (sprite.flipX) ? 180 : 0;
        angle = Input.GetKey(KeyCode.W) ? 90 : angle;
        angle = Input.GetKey(KeyCode.S) && !legs.onGround ? 270 : angle;
        atk.transform.eulerAngles = new Vector3(0, 0, angle);
        anim.SetTrigger("isAttacking");
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
    /// Allow the player to jump.
    /// </summary>
    /// <param name="boolean">true to be able to jump</param>
    public void canJump(bool boolean)
    {
        legs.canJump = boolean;
    }

    /// <summary>
    /// Stop the player from moving vertically.
    /// </summary>
    public void StopVerticalMovement()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
    }

    /// <summary>
    /// Toggle player input and stops movement
    /// </summary>
    public void AllowInput(bool boolean)
    {
        allowBtnPress = boolean;
        allowClick = boolean;
        canJump(boolean);
    }
}
