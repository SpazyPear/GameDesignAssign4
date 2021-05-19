using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private LevelManager levelManager;
    private SFXManager SFX;
    public Text text;
    public Image state;
    public Sprite[] hoverStates;
    private int[] levels = { 1, 2, 3, 4, 5 };
    private int index = 0;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
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
        levelManager.clean = true;
        levelManager.LoadSceneByIndex(levels[index % levels.Length]);
        Destroy(this);
    }

    private void OnMouseExit()
    {
        state.sprite = hoverStates[0];
    }

    public void changeIndex(int amount)
    {
        index += amount;
        index = (index < 0) ? 4 : index;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = "Start Level " + ((index % levels.Length) + 1);
    }
}
