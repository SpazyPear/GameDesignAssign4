using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public GameObject player;
    public GameObject statManager;
    public bool wallJumpChip;
    public FeetHitbox feetHitbox;
    private int newJump;
    private int oldJump;
    // Start is called before the first frame update
    void Start()
    {
        wallJumpChip = false;
        newJump = feetHitbox.maxJumps + 1;
        oldJump = feetHitbox.maxJumps - 1;
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile") //if player collides with a projectile it takes 1 damage
        {
            Destroy(collision.gameObject, 0f);
            statManager.GetComponent<StatManager>().changeHP(-1);
        }
        if (collision.gameObject.tag == "Wall")
        {
            if (wallJumpChip == true)
            {
                feetHitbox.maxJumps = newJump;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if(wallJumpChip == true)
            feetHitbox.maxJumps = oldJump;
        }
    }


}
