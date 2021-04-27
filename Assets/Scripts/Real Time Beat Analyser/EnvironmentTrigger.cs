using UnityEngine;

public class EnvironmentTrigger : MonoBehaviour
{
    public GameObject prefab;
    public GameObject player;
    public GameObject statManager;
    public bool canTrigger;
    public void trigger()
    {
        if (!canTrigger)
        {
            return;
        }
        GameObject cube = Instantiate(prefab, new Vector3(player.transform.position.x, player.transform.position.y + 5, 0), Quaternion.identity); //Instantiate the cube above the players head
        Destroy(cube, 2.0f); //Destroy in 2 seconds so it doesn't just stay there forever
    }
}
