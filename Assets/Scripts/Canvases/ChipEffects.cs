using UnityEngine;

public class ChipEffects : MonoBehaviour
{
    public PlayerControls playerControls;
    public FeetHitbox feetHitbox;

    public void ApplyEffect(string effect)
    {
        switch(effect)
        {
            case "Jump++":
                feetHitbox.maxJumps++;
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
        }
    }
}
