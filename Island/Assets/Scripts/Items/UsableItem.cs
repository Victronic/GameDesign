using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class UsableItem : Item
{
    public bool IsConsumable;

    public List<UsableItemEffect> Effects;
   public virtual void Use(Character character)
    {
       foreach(UsableItemEffect effect in Effects)
        {
            effect.ExecuteEffect(this, character);
        }
    }

    public override string GetItemType()
    {
        return IsConsumable ? "Consumable" : "Usable";
    }

    public override string GetDescription()
    {
        sb.Length = 0;
        foreach(UsableItemEffect effect in Effects)
        {
            sb.Append(effect.GetDescription());
        }
        return sb.ToString();
    }
}
