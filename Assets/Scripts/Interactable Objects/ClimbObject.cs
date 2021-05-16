using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbObject : MonoBehaviour
{
    private PlayerControls player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.canClimb = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.canClimb = false;
        }
    }
}
