using UnityEngine.UI;
using UnityEngine;

public class DisplayChip : MonoBehaviour
{
    private UpgradeChip upgradeChip;
    private Screens screen;
    public Image backgroundImage;
    public Text chipName;

    public void setScreen(Screens screen)
    {
        this.screen = screen;
    }

    public void setChip(UpgradeChip chip)
    {
        upgradeChip = chip;
        chipName.text = upgradeChip.name;
        SwitchColour(new float[] { 36, 36, 36 }, new float[] { 51, 255, 51 }); //#242424, #33FF33
    }

    private void OnMouseEnter()
    {
        screen.changeDesc(upgradeChip.desc + "\nWeight: " + upgradeChip.weight);
        SwitchColour(new float[] { 107, 107, 107 }, new float[] { 69, 246, 246 }); //#6B6B6B, #45F6F6
    }

    private void OnMouseDown()
    {
        upgradeChip.equipped = !upgradeChip.equipped;
        int weight = upgradeChip.weight * (upgradeChip.equipped ? 1 : -1);
        screen.ChangeMemory(weight, upgradeChip.effects);
        SwitchColour(new float[] { 107, 107, 107 }, new float[] { 69, 246, 246 }); //#6B6B6B, #45F6F6
    }

    private void OnMouseExit()
    {
        screen.changeDesc();
        SwitchColour(new float[] { 36, 36, 36 }, new float[] { 51, 255, 51 }); //#242424, #33FF33
    }

    private void SwitchColour(float[] rgb1, float[] rgb2)
    {
        if (upgradeChip.equipped)
        {
            ColourIt(rgb2[0], rgb2[1], rgb2[2]);
            return;
        }
        ColourIt(rgb1[0], rgb1[1], rgb1[2]);
    }

    private void ColourIt(float r, float g, float b)
    {
        backgroundImage.color = new Color(r/255, g/255, b/255);
    }
}
