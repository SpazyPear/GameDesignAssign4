public class UpgradeChip
{
    public string name;
    public string desc;
    public int weight;
    public string[] effects;
    public bool equipped = false;

    public UpgradeChip(string name, string desc, int weight, string[] effects)
    {
        this.name = name;
        this.desc = desc;
        this.weight = weight;
        this.effects = effects;
    }
}
