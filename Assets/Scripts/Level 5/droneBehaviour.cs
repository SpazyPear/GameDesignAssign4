using UnityEngine;

public class droneBehaviour : MonoBehaviour
{
    public float movingSpeed;
    public Vector3[] positions;
    private int index;
    private EnemyStats stats;

    public GameObject bullet;
    public float fireRate;
    private float nextFire;
    [SerializeField]
    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<EnemyStats>();
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        shoot();
    }

    void movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * movingSpeed);
        if (transform.position == positions[index])
        {
            if (index == positions.Length -1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }

    void shoot()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation,transform);
            nextFire = Time.time + fireRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            stats.changeHP(-collision.GetComponent<Attack>().str);
            Destroy(collision);
        }
    }
}
