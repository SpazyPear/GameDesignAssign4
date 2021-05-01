using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private GameObject FakeGround;
    private GameObject player;
    private PlayerControls controls;
    private int flag;

    public GameObject[] fabs;
    private Dictionary<string, GameObject> instantiatedObjs;

    private float delta;
    private float timer;
    void Start()
    {
        FakeGround = GameObject.FindGameObjectWithTag("FakeGround");
        player = GameObject.FindGameObjectWithTag("Player");
        controls = player.GetComponent<PlayerControls>();

        instantiatedObjs = new Dictionary<string, GameObject>();
        controls.SetPosition(0, 0, 0);
        controls.allowBtnPress = true;
        controls.allowClick = false;
        Load("D" ,0);

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
                    controls.CannotMove();
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
                flag++;
                return;

            case 9:
                return;
        }
    }

    private void Load(string name, int index)
    {
        instantiatedObjs.Add(name, Instantiate(fabs[index]));
    }

    private void Unload(string name)
    {
        Destroy(instantiatedObjs[name]);
        instantiatedObjs.Remove(name);
    }
}
