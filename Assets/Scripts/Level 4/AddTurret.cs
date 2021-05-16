using UnityEngine;

public class AddTurret : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("SpectrualAnalyser").GetComponent<EnvironmentTrigger>().addTurret(gameObject);
        Destroy(this);
    }
}
