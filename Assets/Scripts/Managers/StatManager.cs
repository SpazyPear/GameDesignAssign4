using UnityEngine;

public class StatManager : MonoBehaviour
{
    public SFXManager sfxManager;
    public HeartSprite hearts;
    public LevelManager levelManager;
    public int MaxHP = 5;
    private int HP;

    void Awake()
    {
        HP = MaxHP;
    }

    private void Start()
    {
        hearts.ChangeHeartCount(HP);
    }

    /// <summary>
    /// Change the HP value, should change the slider and returns current HP.
    /// </summary>
    /// <param name="amount">Can either be positive or negative.</param>
    /// <returns></returns>
    public int changeHP(int amount)
    {
        HP += amount;
        if (HP < 1) //Set lower boundary
        {
            levelManager.Restart();
        } else
        {
            sfxManager.Play(3);
            HP = (HP > MaxHP) ? MaxHP : HP; //Set upper boundary
            hearts.ChangeHeartCount(amount);
        }
        return HP; //Returns HP in case it is needed
    }

    public void ResetHP()
    {
        HP = MaxHP;
        hearts.SetHeartCount(MaxHP);
    }
}
