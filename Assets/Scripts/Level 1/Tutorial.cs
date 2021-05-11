using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Transform level1;
    private GameObject FakeGround;
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
        FakeGround = GameObject.FindGameObjectWithTag("Fake Ground");
        player = GameObject.FindGameObjectWithTag("Player");
        controls = player.GetComponent<PlayerControls>();

        instantiatedObjs = new Dictionary<string, GameObject>();
        controls.SetPosition(0, 0, 0);
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
                if (player.transform.position.x > 19)
                {
                    flag++;
                    controls.AllowInput(false);
                    timer = 1;
                    Unload("D");
                }
                return;

            case 1:
                flag++;
                FakeGround.SetActive(false);
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
                    timer = 0.5f;
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
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Unload("Escape");
                    Load("Tutorial Save Point", 8);
                    instantiatedObjs.Add("Tutorial Inventory", Instantiate(fabs[9], GameObject.FindGameObjectWithTag("Inventory Screen").transform));
                    tutorialChip = instantiatedObjs["Tutorial Save Point"].GetComponentInChildren<SpinEffect>().transform.gameObject;
                    flag++;
                }
                return;

            case 11:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Unload("Tutorial Inventory");
                    flag++;
                }
                return;

            case 12:
                if (tutorialChip == null)
                {
                    Unload("Tutorial Save Point");
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
