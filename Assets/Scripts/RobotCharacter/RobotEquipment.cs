using System;
using System.Linq;
using UnityEngine;

public class RobotEquipment : MonoBehaviour
{
    public event Action OnChanged;

    [SerializeField] private PartItemSO legs;
    [SerializeField] private PartItemSO arms;
    [SerializeField] private PartItemSO head;

    [Header("Refs")]
    [SerializeField] private RobotStats stats;
    [SerializeField] private PlayerController movement;
    [SerializeField] private RobotCombat combat;
    [SerializeField] private RobotClimb climb;

    private void Awake()
    {
        if (stats == null) stats = GetComponent<RobotStats>();
        if (movement == null) movement = GetComponent<PlayerController>();
        if (combat == null) combat = GetComponent<RobotCombat>();
        if (climb == null) climb = GetComponent<RobotClimb>();
    }

    public void Equip(PartItemSO item)
    {
        switch (item.partType)
        {
            case PartType.Legs: 
                Swap(ref legs, item); 
                RemoveAbilities(legs);
                ApplyAbilities(item);
                break;
            case PartType.Arms: 
                Swap(ref arms, item); 
                RemoveAbilities(arms);
                ApplyAbilities(item);
                break;
            case PartType.Head: 
                Swap(ref head, item);
                RemoveAbilities(head);
                ApplyAbilities(item);
                break;
        }
        OnChanged?.Invoke();
    }

    private void Swap(ref PartItemSO slotItem, PartItemSO newItem)
    {
        if (slotItem != null) stats.RemoveModifiers(slotItem.statModifiers);

        slotItem = newItem;

        if (slotItem != null) stats.AddModifiers(slotItem.statModifiers);
    }

    private void ApplyAbilities(PartItemSO item)
    {
        if (item == null || item.abilities == null) return;

        foreach (var a in item.abilities)
        {
            a.OnEquip(GetComponent<Robot>());
        }
    }
    private void RemoveAbilities(PartItemSO item)
    {
        if (item == null || item.abilities == null) return;

        foreach (var a in item.abilities)
        {
            a.OnUnequip(GetComponent<Robot>());
        }
    }
}
