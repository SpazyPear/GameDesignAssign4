using System.Collections.Generic;
using UnityEngine;

public class HeartSprite : MonoBehaviour
{
    public float HPDistance;
    public GameObject HPSprite;
    private List<GameObject> hearts = new List<GameObject>();

    public GameObject HPArea;
    public void updateHearts(int amount)
    {
        if (amount > 0)
        {
            for (int i = 1; i < amount + 1; i++)
            {
                float x = HPDistance * i;
                GameObject heart = Instantiate(HPSprite, HPArea.transform);
                heart.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, -HPDistance);
                hearts.Add(heart);
            }
            return;
        }

        for (int i = 0; i < Mathf.Abs(amount); i++)
        {
            if (hearts.Count == 0)
            {
                return;
            }

            Destroy(hearts[hearts.Count - 1]);
            hearts.RemoveAt(hearts.Count - 1);
        }
    }
}
