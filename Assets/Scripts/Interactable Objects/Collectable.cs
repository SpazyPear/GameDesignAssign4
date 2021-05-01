using UnityEngine;

public class Collectable : MonoBehaviour
{
    private float delta;
    private Vector3 rot;

    public string upgradeName;

    [TextArea(5, 20)]
    public string desc;
    public float spinSpd;
    void Update()
    {

        //Spin
        delta = Time.deltaTime;
        rot = transform.rotation.eulerAngles;
        transform.eulerAngles = new Vector3(rot.x, rot.y + (spinSpd * delta), rot.z);
    }
}
