using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.LoseLife(1);
        }
        else if(collision.gameObject.CompareTag("Hazard"))
        {
            GameManager.instance.LoseLife(3);
        }
    }
}
