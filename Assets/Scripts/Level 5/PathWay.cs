using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PathWay : MonoBehaviour
{
    public doorButton button;
    [SerializeField]
    private bool isVisable;
    [SerializeField]
    private bool isCollider;

    // Start is called before the first frame update
    void Start()
    {
        button = FindObjectOfType<doorButton>();
        GetComponent<Collider2D>().enabled = isCollider;
        GetComponent<TilemapRenderer>().enabled = isVisable;
    }

    // Update is called once per frame
    void Update()
    {
        if (button.pressed)
        {
                GetComponent<Collider2D>().enabled = !isCollider;
                GetComponent<TilemapRenderer>().enabled = !isVisable;
        }
    }
}
