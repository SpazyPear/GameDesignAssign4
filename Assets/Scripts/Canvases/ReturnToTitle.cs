using UnityEngine;
using UnityEngine.UI;

public class ReturnToTitle : MonoBehaviour
{
    public LevelManager levelManager;
    private Image state;
    public Sprite[] states;

    private void Start()
    {
        state = GetComponent<Image>();
        state.sprite = states[0];
    }
    private void OnMouseEnter()
    {
        state.sprite = states[1];
    }

    private void OnMouseDown()
    {
        levelManager.LoadSceneByIndex(0);
        levelManager.playerControls.DoPause();
    }

    private void OnMouseExit()
    {
        state.sprite = states[0];
    }
}