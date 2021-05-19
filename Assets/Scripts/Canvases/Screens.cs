using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Screens : MonoBehaviour
{
    public Inventory inventory;
    public int maxMem;
    public int usedMem { get; private set; } = 0;
    public Text[] textboxes;
    public Image back;
    public Sprite[] sprites;

    public Slider capacity;
    public Image used;
    public Gradient gradient;

    public GameObject chipArea;
    public GameObject chip;
    private List<GameObject> instantiated = new List<GameObject>();

    public ChipEffects chipEffects;

    public void Reset(bool doClean)
    {
        if (doClean)
        {
            ClearScreen();
            return;
        }
        capacity.maxValue = maxMem;
        UpdateSlider();
        changeDesc();
        ShowInventory();
    }

    public void ClearScreen()
    {
        foreach (GameObject obj in instantiated)
        {
            Destroy(obj);
        }
        instantiated.Clear();
    }

    public void ChangeMemory(int amount, string[] effects)
    {
        usedMem += amount;
        UpdateSlider();

        if (amount > 0)
        {
            foreach (string effect in effects)
            {
                chipEffects.ApplyEffect(effect);
            }
            return;
        }
        foreach (string effect in effects)
        {
            chipEffects.UnapplyEffect(effect);
        }
    }

    public void UnequipAllChips()
    {
        foreach (UpgradeChip chip in inventory.GetChips())
        {
            if (chip.equipped)
            {
                ChangeMemory(-chip.weight, chip.effects);
            }
        }
    }

    public void CleanInventory()
    {
        UnequipAllChips();
        inventory.Clear();
    }

    /// <summary>
    /// Change the description at the bottom of the pause screen.
    /// </summary>
    /// <param name="newDesc"></param>
    public void changeDesc(string newDesc = "")
    {
        textboxes[0].text = newDesc;
    }

    public void ShowInventory()
    {
        int index = 0;
        foreach (UpgradeChip upgradeChip in inventory.GetChips())
        {
            GameObject obj = Instantiate(chip, chipArea.transform);
            RectTransform rect = obj.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(80 * (index % 7), -110 * Mathf.Floor(index / 7));
            DisplayChip uChip = obj.GetComponent<DisplayChip>();
            uChip.setScreen(this);
            uChip.setChip(upgradeChip);
            instantiated.Add(obj);
            index++;
        }
    }

    private void UpdateSlider()
    {
        capacity.value = (usedMem < maxMem) ? usedMem : maxMem;
        used.color = gradient.Evaluate(capacity.normalizedValue);
        textboxes[1].text = usedMem + "/" + maxMem;
        back.sprite = sprites[(usedMem > maxMem) ? 1 : 0];
    }
}
