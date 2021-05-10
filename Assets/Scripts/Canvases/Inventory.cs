using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<UpgradeChip> allChips = new List<UpgradeChip>();

    public void Obtain(UpgradeChip newChip)
    {
        allChips.Add(newChip);
    }

    public List<UpgradeChip> GetChips()
    {
        return allChips;
    }
}
