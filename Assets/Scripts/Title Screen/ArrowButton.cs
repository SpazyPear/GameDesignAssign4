using UnityEngine;
using UnityEngine.UI;

public class ArrowButton : MonoBehaviour
{
    public Image state;
    public Sprite[] hoverStates;
    public StartGame startGame;
    public int amount;

    private void Start()
    {
        state.sprite = hoverStates[0];
    }
    private void OnMouseEnter()
    {
        state.sprite = hoverStates[1];
    }

    private void OnMouseDown()
    {
        startGame.changeIndex(amount);
    }

    private void OnMouseExit()
    {
        state.sprite = hoverStates[0];
    }
}
