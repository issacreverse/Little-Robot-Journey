using UnityEngine;

public enum ItemCategory
{
    Coin,
    Part,
    Key,
    Life
}
[CreateAssetMenu(menuName = "Game/Item Data", fileName = "NewItemData")]
public class ItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public ItemCategory category;
    public PartItemSO partItemData;   

    public Sprite Icon;
    [TextArea] public string description;

    public bool isStackable = false;

    //key 전용 정보 
    public string keyId;
    public bool unique = true;
}
