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
    public Vector3 spawnPoint;
    public Screens screens;
    public bool clean;

    public Collectable[] uChips;

    private void Start()
    {
        UpdateStuff(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (playerControls.transform.position.y < -200)
        {
            playerControls.StopVerticalMovement();
            Restart();
        }
    }

    public void Restart()
    {
        playerControls.statManager.ResetHP();
        playerControls.transform.position = spawnPoint;
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
        playerControls.transform.position = new Vector3(0, 0, 0);
        AsyncOperation loadingOperation = (index == -1) ? SceneManager.LoadSceneAsync(sceneName) : SceneManager.LoadSceneAsync(index);

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
        playerControls.allowPause = allowControls();
        playerControls.canJump(allowControls());
        playerControls.allowClick = allowControls();
    }

    private bool allowControls()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        return 1 < index && index < 6;
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

        if (clean)
        {
            screens.CleanInventory();
            clean = false;
        }

        switch (ID)
        {
            case 1:
                screens.maxMem = 100;
                break;
            case 2:
                screens.inventory.Obtain(uChips[0].getChip());
                screens.maxMem = 80;
                break;
            case 3:
                screens.inventory.Obtain(uChips[0].getChip());
                screens.inventory.Obtain(uChips[1].getChip());
                screens.maxMem = 70;
                break;
            case 4:
                screens.inventory.Obtain(uChips[0].getChip());
                screens.inventory.Obtain(uChips[1].getChip());
                screens.maxMem = 50;
                break;
            case 5:
                screens.UnequipAllChips();
                screens.maxMem = 0;
                break;
        }
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
