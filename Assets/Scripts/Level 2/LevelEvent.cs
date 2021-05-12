using UnityEngine;

public class LevelEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public GameObject level2;
    private GameObject barrier;
    private Transform player;
    private PlayerControls controls;
    private int flag;

    private float delta;
    
    void Start()
    {
        //barrier = GameObject.FindGameObjectWithTag("Barrier");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controls = player.GetComponent<PlayerControls>();
        flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        delta = Time.deltaTime; //needed?
        switch(flag)
        {
            case 0:
                //Do you really need to make the variables? If you're going to only use these variables once
                //Might as well sub it into the if condition and the location of where the boulder spawns.
                float x = 156;
                float yMin = 3;
                float yMax = 10;
                float boulderPosX = 151.41f;
                float boulderPosY = 6.31f;
                if (player.position.x <= x && player.position.y >= yMin && player.position.y <= yMax)
                {
                    level2 = Instantiate(prefab, new Vector3(boulderPosX, boulderPosY, 0), transform.rotation);
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
