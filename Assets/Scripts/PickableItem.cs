using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] public ItemData itemData;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.gameObject.GetComponent<PlayerInventory>();
            if(playerInventory != null)
            {
                if(playerInventory.TryAddItem(itemData))
                {
                    Destroy(gameObject);
                }
            }     
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.gameObject.GetComponent<PlayerInventory>();
            if(playerInventory != null)
            {
                if(playerInventory.TryAddItem(itemData))
                {
                    Destroy(gameObject);
                }
            }     
        }
    }
}
