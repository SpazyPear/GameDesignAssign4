using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string chipName;

    [TextArea(5, 20)]
    public string description;

    public int weight;
    public string[] effects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UpgradeChip chip = new UpgradeChip(chipName, description, weight, effects);
            GameObject.FindGameObjectWithTag("Canvas Manager").GetComponent<Inventory>().Obtain(chip);
            Destroy(gameObject);
        }
    }
}
