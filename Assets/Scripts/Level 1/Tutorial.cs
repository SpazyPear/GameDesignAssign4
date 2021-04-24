using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private GameObject FakeGround;
    private GameObject player;
    private PlayerControls controls;
    private int flag;

    private float delta;
    private float timer;
    void Start()
    {
        FakeGround = GameObject.FindGameObjectWithTag("FakeGround");
        player = GameObject.FindGameObjectWithTag("Player");
        controls = player.GetComponent<PlayerControls>();
        flag = 0;
    }

    void Update()
    {
        delta = Time.deltaTime;
        timer -= delta;
        switch (flag) {
            case 0:
                controls.canJump(false);
                if (player.transform.position.x > 14)
                {
                    flag++;
                    controls.changeControls(new KeyCode[0]);
                    timer = 1;
                }
                return;

            case 1:
                if (timer <= 0)
                {
                    flag++;
                    FakeGround.SetActive(false);
                }
                return;

            case 2:
                if (player.transform.position.y < -50)
                {
                    flag++;
                    controls.changeControls(new KeyCode[] { KeyCode.A, KeyCode.D });
                    controls.canJump(true);
                }
                return;

            case 3:
                return;
        }
    }
}
