using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public PlayerControls playerControls;
    public MusicManager musicManager;
    public Transitions transition;
    public PauseManager pauseManager;
    public GameObject HPArea;
    GhostTrackManager ghostTrackManager;

    public bool isLoading;
    private void Start()
    {
        ghostTrackManager = GameObject.Find("SpectrualAnalyser").GetComponent<GhostTrackManager>();
        UpdateStuff(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Change the scene by String. Will initiate fade transition.
    /// </summary>
    /// <param name="sceneName">Name of the scene in string</param>
    public void LoadScene(string sceneName)
    {
        StartCoroutine("LoadingScene", sceneName);
    }

    IEnumerator LoadingScene(string sceneName)
    {
        isLoading = true;
        playerControls.AllowInput(false);

        transition.Play();
        while (transition.isOn)
        {
            yield return new WaitForEndOfFrame();
        }

        pauseManager.Clean();
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        while (!loadingOperation.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        UpdateStuff(SceneManager.GetActiveScene().buildIndex);

        transition.Play();
        while (transition.isOn)
        {
            yield return new WaitForEndOfFrame();
        }

        playerControls.allowBtnPress = true;
        playerControls.allowClick = SceneManager.GetActiveScene().buildIndex != 1;
        isLoading = true;
    }

    public bool LoadingStatus()
    {
        return isLoading;
    }

    private void UpdateStuff(int ID)
    {
        ghostTrackManager.playGhostTrack(ID);
        musicManager.playTrack(ID);
        playerControls.SetActive(ID != 0);
        HPArea.SetActive(ID != 0);
    }
}
