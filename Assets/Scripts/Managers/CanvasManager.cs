using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject inventoryScreen;

    void Update()
    {
        Cursor.visible = inventoryScreen.activeSelf;
    }
}
