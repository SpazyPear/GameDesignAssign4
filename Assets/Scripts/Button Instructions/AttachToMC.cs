using UnityEngine;

public class AttachToMC : MonoBehaviour
{
    private Transform playerPos;
    public float[] offset = new float[2];
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 pPos = playerPos.position;
        transform.position = new Vector3(pPos.x + offset[0], pPos.y + offset[1], 0);
    }
}
