using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorButton : MonoBehaviour
{
    private bool isPlayerNear;
    public bool pressed;

    public Sprite normal;
    public Sprite activate;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerNear = false;
        pressed = false;
        this.GetComponent<SpriteRenderer>().sprite = normal;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            pressed = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerNear = true;
            this.GetComponent<SpriteRenderer>().sprite = activate;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isPlayerNear = false;
        this.GetComponent<SpriteRenderer>().sprite = normal;
    }

}
