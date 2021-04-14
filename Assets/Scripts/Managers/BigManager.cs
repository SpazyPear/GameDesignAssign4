using UnityEngine;

public class BigManager : MonoBehaviour
{
    //Allows the GUI/Player/Stats stay consistent between scenes.
    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("BigManager") == null)
        {
            DontDestroyOnLoad(gameObject);
            gameObject.tag = "BigManager";
            GameObject.FindGameObjectWithTag("MainCamera").AddComponent<AudioListener>();
            Destroy(this);
            return;
        }
        Destroy(gameObject);
    }
}
