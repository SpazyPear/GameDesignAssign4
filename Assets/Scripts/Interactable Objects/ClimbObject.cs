using UnityEngine;

public class ClimbObject : MonoBehaviour
{
    private PlayerControls player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = (player == null) ? collision.GetComponent<PlayerControls>() : player;
            player.canClimb = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = (player == null) ? collision.GetComponent<PlayerControls>() : player;
            player.canClimb = false;
        }
    }
}
