using UnityEngine;

public class Hazard : MonoBehaviour
{
    private StatManager statManager;
    public int damage; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            statManager = (statManager == null) ? collision.transform.GetComponent<PlayerControls>().statManager : statManager;
            statManager.changeHP(-damage);
        }
    }
}
