using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvironmentTrigger : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    public GameObject statManager;
    public bool canTrigger;

    public void trigger()
    {
        if (!canTrigger)
        {
            return;
        }
        switch (SceneManager.GetActiveScene().buildIndex) //every case number is a different scene. Insert whatever you want that scenes trigger to do correlating the scene number to the level number.
        {
            case 1:
                sceneOne();
                break;
            case 2:
                sceneOne();
                break;
            case 3:
                sceneOne();
                break;
            case 4:
                sceneFour();
                break;
            case 5:
                sceneOne();
                break;
        }
    }

    void sceneFour()
    {
        Transform screen = GameObject.Find("Big Manager").transform.GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "Inventory Screen");
        if (screen.gameObject.activeSelf == false)
        {
            GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
            foreach (GameObject turret in turrets)
            {
                
                if (turret.transform.parent.gameObject.name == "Down")
                {
                    GameObject proj = Instantiate(projectile, new Vector3(turret.GetComponent<Transform>().position.x, turret.GetComponent<Transform>().position.y -4, turret.GetComponent<Transform>().position.z), Quaternion.identity);
                    proj.transform.parent = GameObject.Find("Level 4 Stuff").transform;
                    proj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -10), ForceMode2D.Impulse);
                    Destroy(proj, 2.0f);
                }
                else if (turret.transform.parent.gameObject.name == "Left")
                {
                    GameObject proj = Instantiate(projectile, new Vector3(turret.GetComponent<Transform>().position.x - 4, turret.GetComponent<Transform>().position.y, turret.GetComponent<Transform>().position.z), Quaternion.identity);
                    proj.transform.parent = GameObject.Find("Level 4 Stuff").transform;
                    proj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
                    Destroy(proj, 5.0f);
                }

            }
        }
    }

    void sceneOne()
    {
        GameObject cube = Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y + 5, 0), Quaternion.identity); //Instantiate the cube above the players head
        cube.GetComponent<Rigidbody2D>().gravityScale = 5;
        Destroy(cube, 2.0f); //Destroy in 2 seconds so it doesn't just stay there forever
    }
}
