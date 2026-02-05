using UnityEngine;

public class Button2 : MonoBehaviour
{
    [SerializeField] GameObject smasher;
    [SerializeField] GameObject part1;
    [SerializeField] Color pressedColor = Color.red; // 눌렀을 때 적용할 색상 (인스펙터에서 변경 가능)

    public bool isPressed = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(isPressed) return;
        if(other.gameObject.CompareTag("Player"))
        {
            transform.position -= new Vector3(0,0.1f,0);
            isPressed = true;
            smasher.GetComponent<Animator>().SetTrigger("Off");
            part1.tag = "Untagged";

            // part1의 SpriteRenderer 색을 변경합니다 (null 체크 포함)
            if (part1 != null)
            {
                var sr = part1.GetComponent<SpriteRenderer>();
                if (sr != null) sr.color = pressedColor;
            }
        }
    }
}
