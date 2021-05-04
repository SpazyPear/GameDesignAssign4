using UnityEngine;

public class Collectable : MonoBehaviour
{
    private float delta;
    private Vector3 rot;

    public string chipName;

    [TextArea(5, 20)]
    public string description;

    public int weight;
    public string[] effects;

    public float spinSpd;

    void Update()
    {
        delta = Time.deltaTime;
        rot = transform.rotation.eulerAngles;
        transform.eulerAngles = new Vector3(rot.x, rot.y + (spinSpd * delta), rot.z);
    }

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
