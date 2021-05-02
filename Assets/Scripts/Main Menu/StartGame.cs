using System.Collections;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private LevelManager levelManager;
    private SFXManager SFX;
    public string sceneName;

    private bool canClick = true;
    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
        SFX = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<SFXManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            canClick = false;
            SFX.Play(0);
            levelManager.LoadScene(sceneName);
        }
    }
}
