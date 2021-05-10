using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelManager.SetSpawnPoint(gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}
