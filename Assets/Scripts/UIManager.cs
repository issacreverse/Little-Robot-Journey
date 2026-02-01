using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] Text coinText;
    [SerializeField] Text lifeText;

    public static UIManager instance;
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
}
