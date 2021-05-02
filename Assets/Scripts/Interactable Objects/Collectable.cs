using UnityEngine;

public class Collectable : MonoBehaviour
{
    private float delta;
    private Vector3 rot;
    private Inventory inventory;

    public string upgradeName;

    [TextArea(5, 20)]
    public string desc;
    public float spinSpd;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory Screen").GetComponent<Inventory>();
    }

    void Update()
    {
        delta = Time.deltaTime;
        rot = transform.rotation.eulerAngles;
        transform.eulerAngles = new Vector3(rot.x, rot.y + (spinSpd * delta), rot.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
