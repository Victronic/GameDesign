using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class ItemToolTip : MonoBehaviour
{
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ItemSlotText;
    [SerializeField] Text ItemStatsText;

    private StringBuilder sb = new StringBuilder();
    public void ShowTooltip(EquippableItem item)
    {
        ItemNameText.text = item.ItemName;
        ItemSlotText.text = item.EquipmentType.ToString();

        sb.Length = 0;
        AddStat(item.StrengthBonus, "Strength");
        AddStat(item.IntelligenceBonus, "Intelligence");
        AddStat(item.AgilityBonus, "Agility");
        AddStat(item.VitalityBonus, "Vitality");

        AddStat(item.StrengthPrecentBonus, "Strength", isPrecent: true);
        AddStat(item.IntelligencePrecentBonus, "Intelligence", isPrecent: true);
        AddStat(item.AgilityPrecentBonus, "Agility", isPrecent: true);
        AddStat(item.VitalityPrecentBonus, "Vitality", isPrecent: true);

        ItemStatsText.text = sb.ToString();

        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    private void AddStat(float value, string statName, bool isPrecent = false)
    {
        if (value != 0)
        {
            if (sb.Length > 0)
                sb.AppendLine();

            if (value > 0)
                sb.Append("+");

            if (isPrecent)
            {
                sb.Append(value * 100);
                sb.Append("% ");
            }
            else
            {
                sb.Append(value);
                sb.Append(" ");
            }

            sb.Append(statName);
        }
    }
}
