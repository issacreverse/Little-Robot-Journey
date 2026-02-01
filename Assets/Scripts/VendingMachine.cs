using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public int price {get; private set;} = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DispenseItem()
    {
        Debug.Log("Item Dispensed!");
        //아이템 지급 로직 추가
    }
}
