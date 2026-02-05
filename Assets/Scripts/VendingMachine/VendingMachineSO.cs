using UnityEngine;

[CreateAssetMenu(menuName = "Game/VendingMachine Data", fileName = "NewVendingMachine")]
public class VendingMachineSO : ScriptableObject 
{
    public int price;
    public GameObject item;
}
