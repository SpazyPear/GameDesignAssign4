using UnityEngine;

public class TitleParallax : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 size;
    RectTransform rect;

    Vector2 offset;
    public float xOffset;
    public float yOffset;
    public float maxMovement = 15;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        mousePos = Input.mousePosition;
        size = new Vector2(Screen.width, Screen.height);
        offset = new Vector2(Calculate(GetXPercentage()) + xOffset, Calculate(GetYPercentage()) + yOffset);
        rect.offsetMin = offset;
        rect.offsetMax = offset;
    }

    float GetXPercentage()
    {
        return mousePos.x / size.x - 0.5f;
    }

    float GetYPercentage()
    {
        return mousePos.y / size.y - 0.5f;
    }

    float Calculate(float offset)
    {
        return maxMovement * offset;
    }
}
