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
                    controls.allowInput = false;
                    controls.Stop();
                    timer = 1;
                    Unload("D");
                }
                return;

            case 1:
                flag++;
                FakeGround.SetActive(false);
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
                controls.allowInput = true;
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
                    flag++;
                }
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
