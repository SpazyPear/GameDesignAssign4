using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Screens : MonoBehaviour
{
    public Inventory inventory;
    public Text[] textboxes;

    public GameObject chipArea;
    public GameObject chip;
    private List<GameObject> instantiated = new List<GameObject>();

    void Start()
    {
        GetComponent<Canvas>().enabled = true;
        changeDesc("");
        gameObject.SetActive(false);
    }

    public void Reset(bool doClean)
    {
        if (doClean)
        {
            ClearScreen();
            return;
        }
        changeDesc("");
        ShowInventory();
    }

    public void ClearScreen()
    {
        foreach (GameObject obj in instantiated)
        {
            Destroy(obj);
        }
        instantiated.Clear();
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
        foreach (UpgradeChip upgradeChip in inventory.GetChips())
        {
            GameObject obj = Instantiate(chip, chipArea.transform);
            DisplayChip uChip = obj.GetComponent<DisplayChip>();
            uChip.setChip(upgradeChip);
            instantiated.Add(obj);
        }
    }
}
