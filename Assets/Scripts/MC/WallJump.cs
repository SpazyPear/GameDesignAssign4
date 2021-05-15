using UnityEngine;

public class WallJump : MonoBehaviour
{
    public bool canWallJump = false;
    private Jump jump;

    private void Start()
    {
        jump = GetComponent<Jump>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Wall") && canWallJump)
        {
            jump.jumps++;
            jump.wallJumpState++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            jump.jumps -= (jump.wallJumpState == 1) ? 1 : 0;
            jump.wallJumpState = 0;
        }
    }
}
