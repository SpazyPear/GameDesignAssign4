using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvironmentTrigger : MonoBehaviour
{
    public GameObject levelFourProjectile;
    public GameObject player;
    public GameObject statManager;
    public bool canTrigger;

    private List<GameObject> turrets = new List<GameObject>(); //For level 4

    public void trigger()
    {
        if (!canTrigger)
        {
            return;
        }
        switch (SceneManager.GetActiveScene().buildIndex) //every case number is a different scene. Insert whatever you want that scenes trigger to do correlating the scene number to the level number.
        {
            case 4:
                sceneFour();
                break;
        }
    }

    void sceneFour()
    {
        GameObject proj;
        foreach (GameObject turret in turrets)
        {
            Vector3 pos = turret.transform.position;
            switch(turret.transform.parent.name)
            {
                case "Down":
                    proj = Instantiate(levelFourProjectile, new Vector3(pos.x, pos.y - 4, pos.z), Quaternion.identity, turret.transform);
                    proj.GetComponent<ProjectileCollision>().SetMult(0, -1);
                    Destroy(proj, 2.0f);
                    break;

                case "Left":
                    proj = Instantiate(levelFourProjectile, new Vector3(pos.x - 4, pos.y, pos.z), Quaternion.identity, turret.transform);
                    proj.GetComponent<ProjectileCollision>().SetMult(-1, 0);
                    Destroy(proj, 5.0f);
                    break;
            }
        }
    }

    public void addTurret(GameObject turret)
    {
        turrets.Add(turret);
    }
}
