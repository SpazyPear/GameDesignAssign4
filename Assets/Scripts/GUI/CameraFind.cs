using UnityEngine;

public class CameraFind : MonoBehaviour
{
    private Canvas GUI;
    void Start()
    {
        GUI = gameObject.GetComponent<Canvas>();
        GUI.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Destroy(this);
    }
}
