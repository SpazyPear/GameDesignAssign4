using UnityEngine;
using UnityEngine.UI;

public class ReturnToTitle : MonoBehaviour
{
    public PlayerControls playerControls;
    public LevelManager levelManager;
    private Image state;
    public Sprite[] hoverStates;

    private void Start()
    {
        state = GetComponent<Image>();
        state.sprite = hoverStates[0];
    }
    private void OnMouseEnter()
    {
        state.sprite = hoverStates[1];
    }

    private void OnMouseDown()
    {
        levelManager.LoadSceneByIndex(0);
        playerControls.DoPause();
    }

    private void OnMouseExit()
    {
        state.sprite = hoverStates[0];
    }
}
