using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvironmentTrigger : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    public GameObject statManager;
    public bool canTrigger;

    //public FlyingEnemy flyingEnemy;
    

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
                sceneTwo();
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

    void sceneTwo()
    {
        if (FlyingEnemy.musicCue == false)
        { FlyingEnemy.musicCue = true; }

        if (FlyingEnemy.musicCue == true)
        { FlyingEnemy.musicCue = false; }    

    }

    void sceneFour()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
        foreach (GameObject turret in turrets) {
            GameObject proj = Instantiate(projectile, new Vector3(turret.GetComponent<Transform>().position.x - 1, turret.GetComponent<Transform>().position.y, turret.GetComponent<Transform>().position.z), Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
        }
    }

    void sceneOne()
    {
        GameObject cube = Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y + 5, 0), Quaternion.identity); //Instantiate the cube above the players head
        Destroy(cube, 2.0f); //Destroy in 2 seconds so it doesn't just stay there forever
    }
}
