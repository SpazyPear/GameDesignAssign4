using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Screens : MonoBehaviour
{
    public Inventory inventory;
    public Text[] textboxes;

    private List<GameObject> instantiated = new List<GameObject>();

    void Start()
    {
        GetComponent<Canvas>().enabled = true;
        changeDesc("");
        gameObject.SetActive(false);
    }

    public void Reset(bool doClean)
    {
        changeDesc("");
        if (doClean)
        {
            Debug.Log("Cleaned!");
        }

    }

    /// <summary>
    /// Change the description at the bottom of the pause screen.
    /// </summary>
    /// <param name="newDesc"></param>
    public void changeDesc(string newDesc)
    {
        textboxes[0].text = newDesc;
    }

    public void ShowInventory()
    {
        Debug.Log("Huh");
    }
}
