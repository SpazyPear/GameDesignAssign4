using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private StatManager statManager;
    public int damage; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Contains("Player"))
        {
            if (statManager == null)
            {
                statManager = collision.transform.GetComponent<PlayerControls>().statManager;
            }
            statManager.changeHP(-damage);
        }
    }
}
