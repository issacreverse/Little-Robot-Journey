using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = true;
    public string keyId;

    public void Unlock()
    {
        isLocked = false;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && isLocked)
        {
            PlayerInventory playerInventory = other.gameObject.GetComponent<PlayerInventory>();
            if(playerInventory != null)
            {
                for(int i=0; i<playerInventory.slots.Length; i++)
                {
                    var slot = playerInventory.slots[i];
                    if(!slot.isEmpty && slot.item.category == ItemCategory.Key && slot.item.keyId == keyId)
                    {
                        playerInventory.TryRemoveAt(i, 1);
                        Unlock();
                        break;
                    }
                }
            }     
        }
    }

}
