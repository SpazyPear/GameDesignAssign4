using System.Collections.Generic;
using UnityEngine;

public class ChipEffects : MonoBehaviour
{
    public GameObject player;
    private PlayerControls playerControls;
    private Jump jump;
    private WallJump wallJump;
    
    

    private List<GameObject> atkTypes = new List<GameObject>();
    public GameObject[] attacks;

    private void Start()
    {
        playerControls = player.GetComponent<PlayerControls>();
        jump = player.GetComponent<Jump>();
        wallJump = player.GetComponent<WallJump>();

        foreach (GameObject atk in attacks)
        {
            atkTypes.Add(atk);
        }
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
              //  player.GetComponent<Rigidbody2D>().sharedMaterial = wallJumpPlayerMat;
                return;
            case "Higher Jump":
                jump.jumpStr += 5;
                return;
            case "Increase Speed":
                playerControls.speed += 10;
                return;
            case "Shoot":
                playerControls.attack = atkTypes[1];
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
                return;
            case "Higher Jump":
                jump.jumpStr -= 5;
                return;
            case "Increase Speed":
                playerControls.speed -= 10;
                return;
            case "Shoot":
                playerControls.attack = atkTypes[0];
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
