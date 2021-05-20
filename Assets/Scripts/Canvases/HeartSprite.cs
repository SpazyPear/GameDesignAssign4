using System.Collections.Generic;
using UnityEngine;

public class HeartSprite : MonoBehaviour
{
    public float HPDistance;
    public GameObject HPSprite;
    private List<GameObject> hearts = new List<GameObject>();

    public GameObject HPArea;
    public void ChangeHeartCount(int amount)
    {
        if (amount > 0)
        {
            int size = hearts.Count;
            for (int i = size + 1; i < amount + size + 1; i++)
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

    public void SetHeartCount(int amount)
    {
        ChangeHeartCount(-hearts.Count);
        ChangeHeartCount(amount);
    }
}
