using UnityEngine;

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

}
