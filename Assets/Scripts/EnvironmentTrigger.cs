using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentTrigger : MonoBehaviour
{

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
       // prefab = GameObject.FindGameObjectWithTag("EnvironTriggerTest");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void trigger()
    {
        int rnd = Random.Range(1, 10);
        int rnd2 = Random.Range(1, 10);
        int rnd3 = Random.Range(1, 10);
        Instantiate(prefab, new Vector3(rnd, rnd2, rnd3), Quaternion.identity);
    }
}
