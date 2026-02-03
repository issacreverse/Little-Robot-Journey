using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] Text coinText;
    [SerializeField] Text lifeText;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] Image[] inventorySlots;
    [SerializeField] Text[] inventorySlotTexts;

    public static UIManager instance;
    [SerializeField] PlayerInventory PlayerInventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if(PlayerInventory != null)
        {
            PlayerInventory.OnInventoryChanged += UpdateInventory;
            // ensure UI reflects current inventory at start
            UpdateInventory();
        }
    }
    void OnDestroy()
    {
        if(PlayerInventory != null)
        {
            PlayerInventory.OnInventoryChanged -= UpdateInventory;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(coinText != null)
        {
            coinText.text = "Coins: " + GameManager.instance.coinCount;
        }
        if(lifeText != null)
        {
            lifeText.text = "Lives: " + GameManager.instance.lifeCount;
        }
    }
    public void ToggleInventory()
    {
        if(inventoryPanel != null)
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }
    public void UpdateInventory()
    {
        for(int i=0; i<inventorySlots.Length; i++)
        {
            if(!PlayerInventory.slots[i].isEmpty)
            {
                Sprite itemSprite = PlayerInventory.slots[i].item.Icon;
                inventorySlots[i].sprite = itemSprite;
                inventorySlots[i].enabled = true;
                inventorySlotTexts[i].text = PlayerInventory.slots[i].count.ToString();
            }
            else
            {
                inventorySlots[i].sprite = null;
                inventorySlots[i].enabled = false;
                inventorySlotTexts[i].text = "";
            }
        }
    }
}
