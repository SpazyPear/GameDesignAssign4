using UnityEngine;

public class LevelEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    private GameObject barrier;
    private Transform player;
    private PlayerControls controls;
    private int flag;

    private float delta;
    
    void Start()
    {
        //barrier = GameObject.FindGameObjectWithTag("Barrier"); //Don't know the point of this
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controls = player.GetComponent<PlayerControls>();
        flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        delta = Time.deltaTime; //needed?
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(player.position);
        }
        switch(flag)
        {
            case 0:
                if (player.position.x >= 200 && player.position.y >= -1)
                {
                    GameObject level2 = Instantiate(prefab);
                    level2.SetActive(true);
                    flag++;
                }
                return;
            default:
                Destroy(gameObject);
                return;
        }
    }
}
