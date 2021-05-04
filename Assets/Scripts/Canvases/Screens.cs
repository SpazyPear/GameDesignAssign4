using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Screens : MonoBehaviour
{
    public Inventory inventory;
    public ButtonBehaviour initialScreen;
    private Button currentScreen;
    public Text screenName;
    public Text desc;

    private List<GameObject> instantiated = new List<GameObject>();
    public GameObject memory;
    void Start()
    {
        currentScreen = initialScreen.btn;
        initialScreen.OnClick(true);
        GetComponent<Canvas>().enabled = true;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Default the pause screen back to its original state, inventory screen.
    /// </summary>
    public void Reset()
    {
        initialScreen.OnClick();
    }

    /// <summary>
    /// Change the description at the bottom of the pause screen.
    /// </summary>
    /// <param name="newDesc"></param>
    public void changeDesc(string newDesc)
    {
        desc.text = newDesc;
    }

    public void changeScreen(Button btn, string newScreenName)
    {
        foreach (GameObject obj in instantiated)
        {
            Destroy(obj);
        }
        instantiated.Clear();

        currentScreen.interactable = true;
        btn.interactable = false;
        currentScreen = btn;
        screenName.text = newScreenName;
        changeDesc("");
    }

    public void ShowInventory()
    {
        instantiated.Add(Instantiate(memory, transform));
    }
}
