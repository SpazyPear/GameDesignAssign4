using UnityEngine;

public class ExitInventory : MonoBehaviour
{
    public PlayerControls playerControls;

    private void OnMouseDown()
    {
        playerControls.DoPause();
    }
}
