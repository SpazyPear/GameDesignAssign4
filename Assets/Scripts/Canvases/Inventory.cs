using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<UpgradeChip> unequippedChips = new List<UpgradeChip>();
    private List<UpgradeChip> equippedChips = new List<UpgradeChip>();

    public void obtain(UpgradeChip newChip)
    {
        unequippedChips.Add(newChip);
    }
}
