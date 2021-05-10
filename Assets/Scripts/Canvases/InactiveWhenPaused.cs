using UnityEngine;

public class InactiveWhenPaused : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("Pause Manager").GetComponent<PauseManager>().Add(gameObject);
    }
}
