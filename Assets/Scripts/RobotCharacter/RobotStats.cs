using UnityEngine;
using System.Collections.Generic;

public class RobotStats : MonoBehaviour
{
    //base stats
    [SerializeField] private float baseMoveSpeed = 4f;
    [SerializeField] private float baseClimbSpeed = 0.4f;
    [SerializeField] private float baseJumpPower = 5f;

    private readonly List<StatModifier> mods = new();

    public void AddModifiers(IEnumerable<StatModifier> add)
    {
        if(add == null) return;
        mods.AddRange(add);
    }
    public void RemoveModifiers(IEnumerable<StatModifier> remove)
    {
        if(remove == null) return;
        foreach(var mod in remove)
        {
            mods.Remove(mod);
        }
    }
    public float Get(StatType statType)
    {
        float baseValue = statType switch
        {
            StatType.MoveSpeed => baseMoveSpeed,
            StatType.ClimbSpeed => baseClimbSpeed,
            StatType.JumpPower => baseJumpPower,
            _ => 0f
        };

        float add = 0f;
        float mul = 1f;

        foreach(var m in mods)
        {
            if(m.statType != statType) continue;

            if(m.modType == ModType.Add) add += m.value;
            else if(m.modType == ModType.Mul) mul *= m.value;
        }
        return (baseValue + add) * mul;
    }
}
