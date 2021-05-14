using UnityEngine;

public class ChipEffects : MonoBehaviour
{
    public PlayerControls playerControls;
    public FeetHitbox feetHitbox;
    public WallJump wallJump;

    public void ApplyEffect(string effect)
    {
        switch(effect)
        {
            case "Jump++":
                feetHitbox.maxJumps++;
                return;
            case "WallJump":
                wallJump.wallJumpChip = true;
                return;
            case "Higher Jump":
                feetHitbox.jumpStr += 5;
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
                feetHitbox.maxJumps--;
                return;
            case "WallJump":
                wallJump.wallJumpChip = false;
                return;
            case "Higher Jump":
                feetHitbox.jumpStr -= 5;
                return;
            case "Increase Speed":
                playerControls.speed -= 10;
                return;
        }
    }
}
