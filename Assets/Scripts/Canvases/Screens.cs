using UnityEngine.UI;
using UnityEngine;

public class Screens : MonoBehaviour
{
    public ButtonBehaviour initialScreen;
    private Button currentScreen;
    public Text screenName;
    public Text desc;
    void Start()
    {
        currentScreen = initialScreen.btn;
        Reset();
        GetComponent<Canvas>().enabled = true;
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        initialScreen.OnClick();
    }

    public void changeDesc(string newDesc)
    {
        desc.text = newDesc;
    }

    public void changeScreen(Button btn, string newScreenName)
    {
        currentScreen.interactable = true;
        btn.interactable = false;
        currentScreen = btn;
        screenName.text = newScreenName;
        changeDesc("");
    }
}
