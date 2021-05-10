using UnityEngine;

public class SpinEffect : MonoBehaviour
{
    private float delta;
    private Vector3 rot;

    public float spinSpd = 100;

    void Update()
    {
        delta = Time.deltaTime;
        rot = transform.rotation.eulerAngles;
        transform.eulerAngles = new Vector3(rot.x, rot.y + (spinSpd * delta), rot.z);
    }
}
