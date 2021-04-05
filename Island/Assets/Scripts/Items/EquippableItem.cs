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
    public int StrengthBonus;
    public int AgilityBonus;
    public int IntelligenceBonus;
    public int VitalityBonus;
    [Space]
    public int StrengthPrecentBonus;
    public int AgilityPrecentBonus;
    public int IntelligencePrecentBonus;
    public int VitalityPrecentBonus;
    [Space]
    public EquipmentType EquipmentType;

    public void Equip(Character c)
    {
        if (StrengthBonus != 0)
            c.Strength.AddModifier(new StatModifier(StrengthBonus, StatModType.Flat, this));
        if (AgilityBonus != 0)
            c.Agility.AddModifier(new StatModifier(AgilityBonus, StatModType.Flat, this));
        if (IntelligenceBonus != 0)
            c.Intelligence.AddModifier(new StatModifier(IntelligenceBonus, StatModType.Flat, this));
        if (VitalityBonus != 0)
            c.Vitality.AddModifier(new StatModifier(VitalityBonus, StatModType.Flat, this));

        if (StrengthPrecentBonus != 0)
            c.Strength.AddModifier(new StatModifier(StrengthPrecentBonus, StatModType.PrecentMult, this));
        if (AgilityPrecentBonus != 0)
            c.Agility.AddModifier(new StatModifier(AgilityPrecentBonus, StatModType.PrecentMult, this));
        if (IntelligencePrecentBonus != 0)
            c.Intelligence.AddModifier(new StatModifier(IntelligencePrecentBonus, StatModType.PrecentMult, this));
        if (VitalityPrecentBonus != 0)
            c.Vitality.AddModifier(new StatModifier(VitalityPrecentBonus, StatModType.PrecentMult, this));
    }

    public void Unequip(Character c)
    {
        c.Strength.RemoveAllModifiersFromSource(this);
        c.Agility.RemoveAllModifiersFromSource(this);
        c.Intelligence.RemoveAllModifiersFromSource(this);
        c.Vitality.RemoveAllModifiersFromSource(this);
    }

}
