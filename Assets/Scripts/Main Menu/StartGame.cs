using UnityEngine;

public class StartGame : MonoBehaviour
{
    private LevelManager levelManager;
    private SFXManager SFX;
    public string sceneName;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        SFX = GameObject.FindGameObjectWithTag("SFXManager").GetComponent<SFXManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SFX.Play(0);
            levelManager.loadScene(sceneName);
        }
    }
}
