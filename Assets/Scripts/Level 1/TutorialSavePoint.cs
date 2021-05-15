using UnityEngine;

public class TutorialSavePoint : MonoBehaviour
{
    public GameObject chip;
    private void Update()
    {
        if (chip == null)
        {
            Destroy(gameObject);
        }
    }
}
