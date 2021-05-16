using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private LevelManager levelManager;
    private CanvasManager canvasManager;
    private SFXManager SFX;
    public Text text;
    public Image state;
    public Sprite[] hoverStates;
    private int[] levels = { 1, 2, 3, 4, 5 };
    private int index = 0;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
        canvasManager = GameObject.FindGameObjectWithTag("Canvas Manager").GetComponent<CanvasManager>();
        SFX = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<SFXManager>();
        state.sprite = hoverStates[0];
        UpdateText();
    }

    private void OnMouseEnter()
    {
        state.sprite = hoverStates[1];
    }

    private void OnMouseDown()
    {
        SFX.Play(0);
        levelManager.LoadSceneByIndex(levels[index]);
        canvasManager.MouseVisibility(false);
        Destroy(this);
    }

    private void OnMouseExit()
    {
        state.sprite = hoverStates[0];
    }

    public void changeIndex(int amount)
    {
        index = (index + amount) % levels.Length;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = "Start Level " + (index + 1);
    }
}