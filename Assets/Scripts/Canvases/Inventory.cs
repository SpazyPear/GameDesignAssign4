using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<UpgradeChip> allChips = new List<UpgradeChip>();

    public void Obtain(UpgradeChip newChip)
    {
        foreach (UpgradeChip chip in GetChips())
        {
            if (chip.name.Equals(newChip.name))
            {
                return;
            }
        }
        allChips.Add(newChip);
    }

    public List<UpgradeChip> GetChips()
    {
        return allChips;
    }

    public void Clear()
    {
        allChips.Clear();
    }
}
