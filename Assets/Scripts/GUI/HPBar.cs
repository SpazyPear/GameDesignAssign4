using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private StatManager statManager;
    private Image fill;
    private Slider HP;
    private Text text;

    //Can be adjusted on Unity
    public Gradient colour;
    public float regenPercent;

    void Start()
    {
        statManager = GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>();
        text = gameObject.transform.parent.GetComponentInChildren<Text>();
        HP = gameObject.GetComponent<Slider>();
        fill = gameObject.GetComponentInChildren<Image>();

        HP.maxValue = statManager.MaxHP;
        changeHP(HP.maxValue * (regenPercent / 100));
    }

    /// <summary>
    /// Change HP value. Updates GUI HP Bar.
    /// </summary>
    /// <param name="amount">Can either be positive or negative.</param>
    public void changeHP(float amount)
    {
        HP.value = statManager.changeHP(amount);
        text.text = "HP: " + HP.value + "/" + statManager.MaxHP;
        fill.color = colour.Evaluate(HP.normalizedValue);
    }
}
