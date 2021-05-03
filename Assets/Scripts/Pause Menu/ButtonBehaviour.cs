using UnityEngine.UI;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    private Button btn;
    private Vector2 origin;
    private RectTransform rect;

    public float pushedOut;
    void Start()
    {
        btn = GetComponent<Button>();
        rect = GetComponent<RectTransform>();
        origin = rect.anchoredPosition;
    }

    void Update()
    {
        rect.anchoredPosition = new Vector2(origin.x + (!btn.interactable ? pushedOut : 0), origin.y);
    }
}
