using UnityEngine;
using System;

public enum PartType
{
    Head,
    Arms,
    Legs
}
public abstract class PartItemSO : ScriptableObject
{
    public string partName;
    public PartType partType;
    public StatModifier[] statModifiers;
    public AbilitySO[] abilities;

}
