using UnityEngine;

public class BigManager : MonoBehaviour
{

    //Allows the GUI/Player/Stats stay consistent between scenes.
    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Big Manager") == null)
        {
            DontDestroyOnLoad(gameObject);
            gameObject.tag = "Big Manager";
            GameObject.FindGameObjectWithTag("MainCamera").AddComponent<AudioListener>();
            Destroy(this);
            return;
        }
        Destroy(gameObject);
    }
}
