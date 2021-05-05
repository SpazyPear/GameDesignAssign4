using UnityEngine.UI;
using UnityEngine;

public class DisplayChip : MonoBehaviour
{
    private UpgradeChip upgradeChip;
    private Screens screen;
    public Text chipName;

    public void setScreen(Screens screen)
    {
        this.screen = screen;
    }

    public void setChip(UpgradeChip chip)
    {
        upgradeChip = chip;
        chipName.text = upgradeChip.name;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Ok");
        screen.changeDesc(upgradeChip.desc);
    }
}
