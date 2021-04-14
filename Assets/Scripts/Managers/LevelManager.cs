using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private PlayerControls playerControls;
    private MusicManager musicManager;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerControls = player.GetComponent<PlayerControls>();

        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        updateStuff(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Change the scene by String. Will initiate fade transition.
    /// </summary>
    /// <param name="sceneName">Name of the scene in string</param>
    public void loadScene(string sceneName)
    {
        StartCoroutine("loadingScene", sceneName);
    }

    IEnumerator loadingScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
        updateStuff(SceneManager.GetActiveScene().buildIndex);
    }

    private void updateStuff(int ID)
    {
        musicManager.playTrack(ID);
        playerControls.setActive(ID != 0);
    }
}
