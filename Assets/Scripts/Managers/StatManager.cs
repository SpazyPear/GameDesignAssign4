using UnityEngine;

public class StatManager : MonoBehaviour
{
    public HeartSprite hearts;
    public int MaxHP = 5;
    private int HP;

    void Awake()
    {
        HP = MaxHP;
    }

    private void Start()
    {
        hearts.updateHearts(HP);
    }

    /// <summary>
    /// Change the HP value, should change the slider and returns current HP.
    /// </summary>
    /// <param name="amount">Can either be positive or negative.</param>
    /// <returns></returns>
    public int changeHP(int amount)
    {
        HP += amount;
        HP = (HP < 0) ? 0 : HP; //Set lower boundary
        if (HP > MaxHP) //Set upper boundary
        {
            HP = MaxHP;
        } else
        {
            hearts.updateHearts(amount);
        }
        return HP; //Returns HP in case it is needed
    }
}
