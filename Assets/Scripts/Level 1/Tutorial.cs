using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Transform level1;
    public GameObject FakeGround;
    private GameObject player;
    private PlayerControls controls;
    private int flag;

    public GameObject[] fabs;
    private Dictionary<string, GameObject> instantiatedObjs;

    public GameObject tutorialChip;
    private float delta;
    private float timer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controls = player.GetComponent<PlayerControls>();

        instantiatedObjs = new Dictionary<string, GameObject>();
        controls.transform.position = new Vector3(0, 0, 0);
        controls.allowBtnPress = true;
        controls.allowClick = false;
        Load("D", 0);

        flag = 0;
    }

    void Update()
    {
        delta = Time.deltaTime;
        timer -= delta;
        if (timer > 0)
        {
            return;
        }
        switch (flag) {
            case 0:
                controls.canJump(false);
                if (player.transform.position.x > 17)
                {
                    flag++;
                    controls.AllowInput(false);
                    timer = 1;
                    Unload("D");
                }
                return;

            case 1:
                flag++;
                Destroy(FakeGround);
                Load("Vines", 5);
                return;

            case 2:
                if (player.transform.position.y < -50)
                {
                    flag++;
                    timer = 1;
                }
                return;

            case 3:
                flag++;
                Load("A", 1);
                controls.allowBtnPress = true;
                return;

            case 4:
                if (player.transform.position.x < 1)
                {
                    Unload("A");
                    Load("Space", 2);
                    controls.canJump(true);
                    flag++;
                }
                return;

            case 5:
                if (player.transform.position.x > 25)
                {
                    Unload("Space");
                    Load("Interact", 3);
                    Load("Boulder", 6);
                    flag++;
                }
                return;

            case 6:
                if (player.transform.position.x >= 45)
                {
                    Load("Mouse", 7);
                    Unload("Interact");
                    controls.allowClick = true;
                    flag++;
                }
                return;

            case 7:
                if (instantiatedObjs["Boulder"].transform.position.y < - 20)
                {
                    timer = 0.25f;
                    flag++;
                }
                return;

            case 8:
                Destroy(instantiatedObjs["Boulder"].GetComponent<Rigidbody2D>());
                Destroy(instantiatedObjs["Boulder"].GetComponent<Collider2D>());
                Unload("Mouse");
                flag++;
                return;

            case 9:
                if (tutorialChip == null)
                {
                    Load("Escape", 4);
                    controls.allowPause = true;
                    flag++;
                }
                return;

            case 10:
                if (Input.GetKeyDown(KeyCode.Escape) && controls.allowPause)
                {
                    Unload("Escape");
                    GameObject pause = GameObject.FindGameObjectWithTag("Inventory Screen");
                    instantiatedObjs.Add("Tutorial Inventory", Instantiate(fabs[8], pause.transform));
                    instantiatedObjs.Add("Tutorial Inventory On Ram", Instantiate(fabs[9], pause.transform));

                    flag++;
                }
                return;

            case 11:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Unload("Tutorial Inventory");
                    Unload("Tutorial Inventory On Ram");
                    flag++;
                }
                return;

            default:
                Destroy(gameObject);
                return;
        }
    }

    private void Load(string name, int index)
    {
        instantiatedObjs.Add(name, Instantiate(fabs[index], level1));
    }

    private void Unload(string name)
    {
        Destroy(instantiatedObjs[name]);
        instantiatedObjs.Remove(name);
    }
}
