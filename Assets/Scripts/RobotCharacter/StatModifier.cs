using UnityEngine;
using System;
public enum StatType
{
    MoveSpeed,
    JumpPower,
    ClimbSpeed,
}
public enum ModType
{
    Add, 
    Mul,
}
[Serializable]
public struct StatModifier
{
    public StatType statType;
    public ModType modType;
    public float value;
}
