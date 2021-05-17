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
    public GhostTrackManager ghostTrackManager;
    private Vector3 spawnPoint;

    private void Start()
    {
        ghostTrackManager = GameObject.Find("SpectrualAnalyser").GetComponent<GhostTrackManager>();
        UpdateStuff(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (playerControls.transform.position.y < -200)
        {
            playerControls.StopVerticalMovement();
            playerControls.transform.position = spawnPoint;
        }
    }

    /// <summary>
    /// Change the scene by String or index. Will initiate fade transition.
    /// </summary>
    /// <param name="sceneName">Name of the scene in string</param>
    public void LoadScene(string sceneName, int index = -1)
    {
        StartCoroutine(LoadingScene(sceneName, index));
    }

    /// <summary>
    /// Change the scene by index. Will initiate fade transition.
    /// </summary>
    /// <param name="index">The scene index number</param>
    public void LoadSceneByIndex(int index)
    {
        LoadScene("", index);
    }

    /// <summary>
    /// Switch to the next scene, goes by index.
    /// </summary>
    public void LoadNextScene()
    {
        LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadingScene(string sceneName, int index)
    {
        playerControls.AllowInput(false);

        transition.Play();
        while (transition.isOn)
        {
            yield return new WaitForEndOfFrame();
        }

        pauseManager.Clean();
        AsyncOperation loadingOperation;
        loadingOperation = (index == -1) ? SceneManager.LoadSceneAsync(sceneName) : SceneManager.LoadSceneAsync(index);

        while (!loadingOperation.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        UpdateStuff(SceneManager.GetActiveScene().buildIndex);
        playerControls.transform.position = this.spawnPoint;

        transition.Play();
        while (transition.isOn)
        {
            yield return new WaitForEndOfFrame();
        }

        playerControls.allowBtnPress = true;
        playerControls.canJump(SceneManager.GetActiveScene().buildIndex != 1);
        playerControls.allowClick = SceneManager.GetActiveScene().buildIndex != 1;
        Cursor.visible = SceneManager.GetActiveScene().buildIndex == 0;
    }

    /// <summary>
    /// Update many things according to the scene.
    /// </summary>
    /// <param name="ID">Scene ID</param>
    public void UpdateStuff(int ID)
    {
        ghostTrackManager.playGhostTrack(ID);
        musicManager.playTrack(ID);
        playerControls.SetActive(ID != 0);
        HPArea.SetActive(ID != 0);
        SetSpawnPoint(new Vector3(0, 0, 0));
    }

    /// <summary>
    /// Change the spawnpoint of the player, when they get out of bounds.
    /// </summary>
    /// <param name="spawnPoint"></param>
    public void SetSpawnPoint(Vector3 spawnPoint)
    {
        this.spawnPoint = spawnPoint;
    }
}
