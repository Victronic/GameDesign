using Victor.CharacterStats;
using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class StatBuffItemEffect : UsableItemEffect
{
    public int AgilityBuff;
    public float Duration;
    public override void ExecuteEffect(UsableItem parentItem, Character character)
    {
        StatModifier statModifier = new StatModifier(AgilityBuff, StatModType.Flat, parentItem);
        
        character.ChopPower.AddModifier(statModifier);
        character.StartCoroutine(RemoveBuff(character, statModifier, Duration));
        character.UpdateStatValues();
    }

    public override string GetDescription()
    {
        return "Grant " + AgilityBuff + " Agility for " + Duration + " seconds.";
    }

    public static IEnumerator RemoveBuff(Character character, StatModifier statModifier, float duration)
    {
        yield return new WaitForSeconds(duration);
        character.ChopPower.RemoveModifier(statModifier);
        character.UpdateStatValues();
    }
}
