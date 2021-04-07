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
        AddStat(item.ChoppBonus, "Chopp");
        AddStat(item.CutBonus, "Mining");
        AddStat(item.MiningBonus, "Cut");
        AddStat(item.HuntBonus, "Hunt");
        AddStat(item.FishingBonus, "Fishing");

        AddStat(item.StrengthPrecentBonus, "Strength", isPrecent: true);
        AddStat(item.CutPrecentBonus, "Mining", isPrecent: true);
        AddStat(item.MiningPrecentBonus, "Cut", isPrecent: true);
        AddStat(item.HuntPrecentBonus, "Hunt", isPrecent: true);
        AddStat(item.FishingPrecentBonus, "Fishing", isPrecent: true);

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
