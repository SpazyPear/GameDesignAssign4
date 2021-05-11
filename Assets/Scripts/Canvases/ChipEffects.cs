using UnityEngine;

public class ChipEffects : MonoBehaviour
{
    public PlayerControls playerControls;
    public FeetHitbox feetHitbox;
    public PlayerCollisions playerCollisions;

    private void Start()
    {
        playerCollisions = GameObject.Find("MC").GetComponent<PlayerCollisions>();
    }

    public void ApplyEffect(string effect)
    {
        switch(effect)
        {
            case "Jump++":
                feetHitbox.maxJumps++;
                return;
            case "WallJump":
                playerCollisions.wallJumpChip = true;
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
                playerCollisions.wallJumpChip = false;
                break;

        }
    }
}
