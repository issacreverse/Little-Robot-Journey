using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            GameManager.instance.AddCoin();
            Destroy(other.gameObject);
        }
    }
}
