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
                break;
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
                break;
        }
    }
}
