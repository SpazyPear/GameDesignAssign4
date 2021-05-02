using UnityEngine;

public class CameraFind : MonoBehaviour
{
    void Start()
    {
        Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        gameObject.GetComponent<Canvas>().worldCamera = cam;
        Destroy(this);
    }
}
