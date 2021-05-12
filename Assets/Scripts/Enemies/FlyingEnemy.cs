using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{

    private PlayerControls player;

    public float movementSpeed;

    public float playerRange;

    public LayerMask playerLayer;

    public bool playerInRange;
    public static bool musicCue;

    public bool musicFlyer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

        if (!musicFlyer)
        {
            if (playerInRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
                return;
            }
        }

        if (musicFlyer)
        {
            if (musicCue)
            {
                if (playerInRange)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
                    return;
                }
            }
        }    

    }


    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, playerRange);
    }
}
