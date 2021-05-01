using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private PlayerControls playerControls;
    private GameObject HPArea;
    private MusicManager musicManager;
    private Animator anim;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerControls = player.GetComponent<PlayerControls>();
        HPArea = GameObject.FindGameObjectWithTag("HP Area");

        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        updateStuff(SceneManager.GetActiveScene().buildIndex);

        anim = GameObject.FindGameObjectWithTag("Loading Screen").GetComponent<Animator>();
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
        playerControls.CannotMove();
        anim.SetTrigger("Next");
        yield return new WaitForEndOfFrame();
        yield return new WaitForSecondsRealtime(transitionLength());

        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        while (!loadingOperation.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        anim.SetTrigger("Next");
        updateStuff(SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForEndOfFrame();
        yield return new WaitForSecondsRealtime(transitionLength());
        playerControls.allowBtnPress = true;
    }

    private float transitionLength()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        return info.length + info.normalizedTime;
    }

    private void updateStuff(int ID)
    {
        musicManager.playTrack(ID);
        playerControls.SetActive(ID != 0);
        HPArea.SetActive(ID != 0);
    }
}
