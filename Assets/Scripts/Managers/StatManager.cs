using UnityEngine;

public class StatManager : MonoBehaviour
{
    public float MaxHP = 100;
    private float HP;

    void Awake()
    {
        HP = MaxHP;
    }

    /// <summary>
    /// Change the HP value, should change the slider and returns current HP.
    /// </summary>
    /// <param name="amount">Can either be positive or negative.</param>
    /// <returns></returns>
    public float changeHP(float amount)
    {
        HP += amount;
        HP = (HP < 0) ? 0 : HP; //Set lower boundary
        HP = (HP > MaxHP) ? MaxHP : HP; //Set upper boundary
        return HP; //Returns HP in case it is needed
    }
}
