using UnityEngine;
using System;

public class PlayerInventory : MonoBehaviour
{

    public struct InventoryItem
    {
        public int count;
        public ItemData item;
        
        public bool isEmpty => item == null || count <= 0;
        public void Clear()
        {
            item = null;
            count = 0;
        }
    };

    public event Action OnInventoryChanged;

    public InventoryItem[] slots;
    [SerializeField] int capacity = 7;

    // public InventoryItem[] GetSlots() => slots;

    void Start()
    {
        slots = new InventoryItem[capacity];
    }

    public bool TryAddItem(ItemData item, int amount = 1)
    {
        if(item == null || amount <= 0)
            return false;
        
        if(item.isStackable)
        {
            int idx = FindSlotWithItem(item);
            if(idx != -1)
            {
                slots[idx].count += amount;
                OnInventoryChanged?.Invoke();
                return true;
            }
        }
        int empty = FindEmptySlot();
        if(empty == -1)
            return false;
        
        slots[empty].item = item;
        slots[empty].count = amount;

        OnInventoryChanged?.Invoke();   
        return true;
    }

    public bool TryRemoveAt(int index, int amount = 1)
    {
        if(index < 0 || index >= slots.Length)
            return false;
        if(slots[index].isEmpty)
            return false;
        
        slots[index].count -= amount;
        if(slots[index].count <= 0)
            slots[index].Clear();
        
        OnInventoryChanged?.Invoke();
        return true;
    }

    int FindSlotWithItem(ItemData item)
    {
        for(int i=0; i<slots.Length; i++)
        {
            if(!slots[i].isEmpty && slots[i].item == item)
                return i;
        }
        return -1;
    }

    int FindEmptySlot()
    {
        for(int i=0; i<slots.Length; i++)
        {
            if(slots[i].isEmpty)
                return i;
        }
        return -1;
    }
}
