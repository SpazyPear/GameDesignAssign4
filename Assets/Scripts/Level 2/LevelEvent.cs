using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public GameObject level2;
    private GameObject barrier;
    private GameObject player = null;
    private PlayerControls controls;
    private int flag;

    private float delta;

    private float x = 156;
    private float yMin = 3;
    private float yMax = 10;

    private float boulderPosX = 151.41f;
    private float boulderPosY = 6.31f;
    
    void Start()
    {
        barrier = GameObject.FindGameObjectWithTag("Barrier");

        if (player == null)
            player = GameObject.Find("MC");
        
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        level2 = GameObject.FindGameObjectWithTag("Level Manager");
        controls = player.GetComponent<PlayerControls>();

        //instatiatedObjs = new Dictionary<string, GameObject>();

        //flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //delta = Time.deltaTime 
        if (player != null)
        {
            if (player.transform.position.x <= x && player.transform.position.y >= yMin && player.transform.position.y <= yMax)
            {
                level2 = Instantiate(prefab, new Vector3(boulderPosX, boulderPosY, 0), transform.rotation);
            }
        }
    }
}
