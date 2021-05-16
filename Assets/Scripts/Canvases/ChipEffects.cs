using UnityEngine;

public class ChipEffects : MonoBehaviour
{
    public GameObject player;
    private PlayerControls playerControls;
    private Jump jump;
    private WallJump wallJump;

    private void Start()
    {
        playerControls = player.GetComponent<PlayerControls>();
        jump = player.GetComponent<Jump>();
        wallJump = player.GetComponent<WallJump>();
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
                wallJump.canWallJump = true;
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
                wallJump.canWallJump = false;
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
