using UnityEngine;

public class WallJump : MonoBehaviour
{
    public bool wallJumpChip;
    public Jump feetHitbox;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            feetHitbox.canWallJump = wallJumpChip;
            feetHitbox.wallJumps = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            feetHitbox.canWallJump = false;
        }
    }
}
