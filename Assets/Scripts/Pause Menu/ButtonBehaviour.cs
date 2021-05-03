using UnityEngine.UI;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public Button btn { get; private set; }
    private Vector2 origin;
    private RectTransform rect;
    private Image image;

    public string screenName;
    public Screens screens;
    public string function;

    public Sprite[] sprites;

    public float pushedOut;
    void Start()
    {
        btn = GetComponent<Button>();
        rect = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        origin = rect.anchoredPosition;
    }

    void Update()
    {
        rect.anchoredPosition = new Vector2(origin.x + (!btn.interactable ? pushedOut : 0), origin.y);
    }

    public void OnClick()
    {
        screens.changeScreen(btn, screenName);
        switch(function)
        {
            case "Close game":
                Application.Quit();
                return;
        }
    }

    public void OnMouseEnter()
    {
        image.sprite = sprites[1];
    }

    public void OnMouseExit()
    {
        image.sprite = sprites[0];
    }

    public void OnMouseDown()
    {
        OnClick();
    }
}
