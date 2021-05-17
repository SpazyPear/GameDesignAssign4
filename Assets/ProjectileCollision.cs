using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageStrength;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerControls>().statManager.changeHP(-damageStrength);
            Destroy(gameObject);
        }
    }
}
