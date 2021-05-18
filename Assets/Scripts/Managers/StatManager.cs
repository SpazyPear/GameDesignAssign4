using UnityEngine;

public class StatManager : MonoBehaviour
{
    public HeartSprite hearts;
    public LevelManager levelManager;
    public GameObject MC;
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
        if (HP < 1)
        {
            HP = MaxHP;
            hearts.updateHearts(MaxHP);
            MC.transform.position = levelManager.spawnPoint;
        }
        return HP; //Returns HP in case it is needed
    }
}
