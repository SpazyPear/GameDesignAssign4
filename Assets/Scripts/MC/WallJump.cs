using UnityEngine;

public class WallJump : MonoBehaviour
{
    public bool wallJumpChip;
    public FeetHitbox feetHitbox;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            feetHitbox.canWallJump = wallJumpChip;
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
