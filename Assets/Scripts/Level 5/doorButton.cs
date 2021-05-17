using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorButton : MonoBehaviour
{
    private bool isPlayerNear;
    public bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerNear = false;
        pressed = false;
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
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isPlayerNear = false;
    }

}
