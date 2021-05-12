using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float movementSpeed;
    public bool playerInRange;
    public static bool musicCue; //Not sure what the point of this is

    private Transform playerPos;

    void Update()
    {
        if (playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos.position, movementSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerPos == null)
            {
                playerPos = collision.transform;
            }
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
