using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string chipName;

    [TextArea(5, 20)]
    public string description;

    public int weight;
    public string[] effects;

    public UpgradeChip getChip()
    {
        return new UpgradeChip(chipName, description, weight, effects);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Canvas Manager").GetComponent<Inventory>().Obtain(getChip());
            Destroy(gameObject);
        }
    }
}
