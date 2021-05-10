using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EnvironmentTrigger : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    public GameObject statManager;
    public bool canTrigger;
   
    

        private void Start()
    {
       
        
    }
    public void trigger()
    {
        if (!canTrigger)
        {
            return;
        }
        switch (SceneManager.GetActiveScene().buildIndex) //every case number is a different scene. Insert whatever you want that scenes trigger to do correlating the scene number to the level number.
        {
            case 0:
                //GameObject cube = Instantiate(prefab, new Vector3(player.transform.position.x, player.transform.position.y + 5, 0), Quaternion.identity); //Instantiate the cube above the players head
                //Destroy(cube, 2.0f); //Destroy in 2 seconds so it doesn't just stay there forever
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                sceneFour();
                break;
            case 5:
                break;
        }
    }

    void sceneFour()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
        foreach (GameObject turret in turrets) {
            GameObject proj = Instantiate(projectile, new Vector3(turret.GetComponent<Transform>().position.x - 1, turret.GetComponent<Transform>().position.y, turret.GetComponent<Transform>().position.z), Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
            
        }
    }
}
