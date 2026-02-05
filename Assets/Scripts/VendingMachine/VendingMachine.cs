using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    [SerializeField] VendingMachineSO machine;
    [SerializeField] PlayerInput playerInput;

    public bool itemLeft = true;
    public bool touchingVendingMachine = false;
    
    void Start()
    {
        playerInput.TryVending += DispenseItem;
    }
    void OnDestroy() 
    {
        if(playerInput != null)
            playerInput.TryVending -= DispenseItem;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            touchingVendingMachine = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            touchingVendingMachine = false;
        }
    }
    public void DispenseItem()
    {
        if(touchingVendingMachine && itemLeft)
        {
            if(GameManager.instance.UseCoin(machine.price))
            {
                Debug.Log("Item Dispensed!");
                var spawnPos = transform.position + Vector3.right * 1.0f;
                GameObject item = Instantiate(machine.item, spawnPos, Quaternion.identity);
                item.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 0.5f, ForceMode2D.Impulse);
                itemLeft = false;
            }
        }
    }
}
