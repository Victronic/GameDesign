using UnityEngine;
using Victor.CharacterStats;

public class StatPanel : MonoBehaviour
{
    [SerializeField] StatDisplay[] statDisplays;
    [SerializeField] string[] statNames;

    private CharacterStat[] stats;

    private void OnValidate()
    {
        statDisplays = GetComponentsInChildren<StatDisplay>();
        UpdateStatName();
    }

    public void SetStats(params CharacterStat[] charStats)
    {
        stats = charStats;

        if(stats.Length > statDisplays.Length)
        {
            Debug.LogError("Not Enough Stat Display");
            return;
        }

        for (int i = 0; i < statDisplays.Length; i++)
        {
            statDisplays[i].gameObject.SetActive(i < stats.Length);

            if (i < stats.Length)
            {
                statDisplays[i].Stat = stats[i];
            }    
        }
    }

    public void UpdateStatValue()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            statDisplays[i].UpdateStatValue();
        }
    }

    public void UpdateStatName()
    {
        for (int i = 0; i < statNames.Length; i++)
        {
            statDisplays[i].Name = statNames[i];
        }
    }
}
