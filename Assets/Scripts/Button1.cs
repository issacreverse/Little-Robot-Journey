using UnityEngine;

public class Button1 : MonoBehaviour
{
   [SerializeField] GameObject movingPlatform;

    public bool isPressed = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(isPressed) return;
        if(other.gameObject.CompareTag("Player"))
        {
            transform.position -= new Vector3(0,0.1f,0);
            isPressed = true;
            movingPlatform.GetComponent<Animator>().SetTrigger("Down");
        }
    }
}
