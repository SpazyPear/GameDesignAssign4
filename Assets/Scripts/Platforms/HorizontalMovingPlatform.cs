using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HorizontalMovingPlatform : MonoBehaviour
{
    private Vector3 startPos;
    public Transform target;
    public float speed;
    private bool moveRight;
    void Start()
    {
        startPos = transform.position;
        moveRight = true;
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (transform.position == target.position)
        {
            moveRight = false;
        }
        else if (transform.position == startPos)
        {
            moveRight = true;
        }
        if (moveRight == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
        else if (moveRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}