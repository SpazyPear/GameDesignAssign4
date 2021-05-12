using UnityEngine;

public class LevelEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public AudioSource explosion;
    private GameObject barrier;
    private Transform player;
    private PlayerControls controls;
    private int flag;

    private float delta;
    
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controls = player.GetComponent<PlayerControls>();
        flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(player.position);
        }
        switch(flag)
        {
            case 0:
                if (player.position.x >= 220 && player.position.y >= -1)
                {
                    GameObject level2 = Instantiate(prefab);
                    explosion.Play();
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
