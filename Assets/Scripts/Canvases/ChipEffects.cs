using UnityEngine;
using UnityEngine.SceneManagement;

public class ChipEffects : MonoBehaviour
{
    public GameObject player;
    private PlayerControls playerControls;
    private Jump jump;
    private WallJump wallJump;
    private Rigidbody2D rb;
    public PhysicsMaterial2D wallJumpPlayerMat;

    private void Start()
    {
        playerControls = player.GetComponent<PlayerControls>();
        jump = player.GetComponent<Jump>();
        wallJump = player.GetComponent<WallJump>();
        rb = player.GetComponent<Rigidbody2D>();
       /* if (SceneManager.GetActiveScene().buildIndex == 4)
            if (GameObject.Find("Upgrade Chip") != null)
                Debug.Log("test");
                 wallJumpPlayerMat.friction = (GameObject.Find("Upgrade Chip") != null)  ? 0f : 0.035f; */

    }

    public void ApplyEffect(string effect)
    {
        switch(effect)
        {
            case "Jump++":
                jump.maxJumps++;
                resetJump();
                return;
            case "WallJump":
                wallJump.wallJumpChip = true;
                wallJumpPlayerMat.friction = 0.035f;
                return;
            case "Higher Jump":
                jump.jumpStr += 5;
                return;
            case "Increase Speed":
                playerControls.speed += 10;
                return;
        }
    }

    public void UnapplyEffect(string effect)
    {
        switch(effect)
        {
            case "Jump++":
                jump.maxJumps--;
                resetJump();
                return;
            case "WallJump":
                wallJump.wallJumpChip = false;
                wallJumpPlayerMat.friction = 0f;
                return;
            case "Higher Jump":
                jump.jumpStr -= 5;
                return;
            case "Increase Speed":
                playerControls.speed -= 10;
                return;
        }
    }

    private void resetJump()
    {
        if (jump.onGround)
        {
            jump.jumps = jump.maxJumps;
        }
    }
}
