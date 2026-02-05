using UnityEngine;

public class PlayerVendingMachine : MonoBehaviour
{
    /*
    [SerializeField] bool touchVendingMachine = false;
    GameObject currentVendingMachine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(touchVendingMachine && Input.GetKeyDown(KeyCode.V))
        {
            int price = currentVendingMachine.GetComponent<VendingMachine>().price;

            if(GameManager.instance.UseCoin(price))
            {
                Debug.Log("Vending machine used!");
                currentVendingMachine.GetComponent<VendingMachine>().DispenseItem();
            }
            else
            {
                Debug.Log("Not enough coins!");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("VendingMachine"))
        {
            touchVendingMachine = true;
            currentVendingMachine = collision.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("VendingMachine"))
        {
            touchVendingMachine = false;
            currentVendingMachine = null;
        }
    }
    */
}
