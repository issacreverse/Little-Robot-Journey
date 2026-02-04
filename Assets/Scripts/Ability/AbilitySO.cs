using UnityEngine;
using System;

public abstract class AbilitySO : ScriptableObject
{
    public abstract void OnEquip(Robot robot);
    public abstract void OnUnequip(Robot robot);
}
