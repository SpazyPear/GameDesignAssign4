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
        playerControls.allowPause = SceneManager.GetActiveScene().buildIndex != 1;
        playerControls.canJump(SceneManager.GetActiveScene().buildIndex != 1);
        playerControls.allowClick = SceneManager.GetActiveScene().buildIndex != 1;
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
                screens.inventory.Obtain(createChip(0));
                screens.maxMem = 80;
                break;
            case 3:
                screens.inventory.Obtain(createChip(0));
                screens.inventory.Obtain(createChip(1));
                screens.maxMem = 70;
                break;
            case 4:
                screens.inventory.Obtain(createChip(0));
                screens.inventory.Obtain(createChip(1));
                screens.maxMem = 50;
                break;
            case 5:
                screens.UnequipAllChips();
                screens.maxMem = 0;
                break;
        }
    }

    private UpgradeChip createChip(int index)
    {
        return new UpgradeChip(uChips[index].chipName, uChips[index].description, uChips[index].weight, uChips[index].effects);
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
