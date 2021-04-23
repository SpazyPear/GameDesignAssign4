using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator anim;
    private Rigidbody2D rb;
    private float delta;
    private KeyCode[] keysAvailable;

    public float speed;

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
        DoInput();

        if (transform.position.y < -100)
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
        }

        anim.SetBool("isWalking", (Input.GetKey(KeyCode.A) != Input.GetKey(KeyCode.D)));
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

            /*if (Input.GetKeyUp(key))
            {
                KeyUpAction(key);
            }*/
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
                sprite.flipX = true;
                transform.Translate(-speed * delta, 0, 0, Space.World);
                return;

            case KeyCode.D:
                sprite.flipX = false;
                transform.Translate(speed * delta, 0, 0, Space.World);
                return;
        }
    }

    private void KeyUpAction(KeyCode key)
    {
    }

    /// <summary>
    /// Set the player to either be visible or not
    /// </summary>
    /// <param name="boolean">true to show/false to hide</param>
    public void SetActive(bool boolean)
    {
        sprite.enabled = boolean;
        rb.simulated = boolean;
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

}
