using UnityEngine;
using Victor.CharacterStats;
public enum EquipmentType
{
    Helmet,
    Chest,
    Gloves,
    Boots,
    Weapon1,
    Weapon2,
    Accessory1,
    Accessory2,

}
[CreateAssetMenu]
public class EquippableItem : Item
{
    public int ChoppBonus;
    public int MiningBonus;
    public int CutBonus;
    public int HuntBonus;
    public int FishingBonus;
    [Space]
    public int StrengthPrecentBonus;
    public int MiningPrecentBonus;
    public int CutPrecentBonus;
    public int HuntPrecentBonus;
    public int FishingPrecentBonus;
    [Space]
    public int Durability=10;
    public EquipmentType EquipmentType;

    public override Item GetCopy()
    {
        return Instantiate(this);
    }

    public override void Destroy()
    {
        Destroy(this);
    }

    public void Equip(Character c)
    {
        if (ChoppBonus != 0)
            c.ChopPower.AddModifier(new StatModifier(ChoppBonus, StatModType.Flat, this));
        if (MiningBonus != 0)
            c.MiningPower.AddModifier(new StatModifier(MiningBonus, StatModType.Flat, this));
        if (CutBonus != 0)
            c.CutPower.AddModifier(new StatModifier(CutBonus, StatModType.Flat, this));
        if (HuntBonus != 0)
            c.HuntPower.AddModifier(new StatModifier(HuntBonus, StatModType.Flat, this));
        if (FishingBonus != 0)
            c.FishingPower.AddModifier(new StatModifier(FishingBonus, StatModType.Flat, this));

        if (StrengthPrecentBonus != 0)
            c.ChopPower.AddModifier(new StatModifier(StrengthPrecentBonus, StatModType.PrecentMult, this));
        if (MiningPrecentBonus != 0)
            c.MiningPower.AddModifier(new StatModifier(MiningPrecentBonus, StatModType.PrecentMult, this));
        if (CutPrecentBonus != 0)
            c.CutPower.AddModifier(new StatModifier(CutPrecentBonus, StatModType.PrecentMult, this));
        if (HuntPrecentBonus != 0)
            c.HuntPower.AddModifier(new StatModifier(HuntPrecentBonus, StatModType.PrecentMult, this));
        if (FishingBonus != 0)
            c.FishingPower.AddModifier(new StatModifier(FishingPrecentBonus, StatModType.PrecentMult, this));
    }

    public void Unequip(Character c)
    {
        c.ChopPower.RemoveAllModifiersFromSource(this);
        c.MiningPower.RemoveAllModifiersFromSource(this);
        c.CutPower.RemoveAllModifiersFromSource(this);
        c.HuntPower.RemoveAllModifiersFromSource(this);
        c.FishingPower.RemoveAllModifiersFromSource(this);
    }
}
