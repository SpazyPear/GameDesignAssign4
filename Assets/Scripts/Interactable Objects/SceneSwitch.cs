using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    private LevelManager levelManager;
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelManager.LoadNextScene();
            Destroy(gameObject);
        }
    }
}
