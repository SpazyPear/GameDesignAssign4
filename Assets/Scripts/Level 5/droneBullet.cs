using UnityEngine;

public class droneBullet : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;

    public int damageStrength;
    public float lifespan = 5;
    private float delta;
    private StatManager statManager;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.up * bulletSpeed;
    }

    private void Update()
    {
        if ((lifespan -= Time.deltaTime) < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.transform.tag != "Enemy" && hitObject.transform.tag !=  "climbable")
        {
            if (hitObject.transform.tag == "Player")
            {
                statManager = (statManager == null) ? hitObject.transform.GetComponent<PlayerControls>().statManager : statManager;
                statManager.changeHP(-damageStrength);
            }
            Destroy(gameObject);
        }
    }
}
