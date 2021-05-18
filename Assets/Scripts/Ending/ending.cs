using UnityEngine;

public class ending : MonoBehaviour
{
    public float timeRemaining = 5;

    // Update is called once per frame
    void Update()
    {
        if((timeRemaining -= Time.deltaTime) < 0)
        {
            GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>().LoadSceneByIndex(0);
            Destroy(gameObject);
        }
    }
}
