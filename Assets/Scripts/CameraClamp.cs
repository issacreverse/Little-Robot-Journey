using UnityEngine;

public class CameraClamp : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] BoxCollider2D cameraBounds;

    Camera mainCamera;

    float nextPosX;
    float nextPosY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }

    void LateUpdate() 
    {
        Vector3 desiredPos = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);

        float halfH = mainCamera.orthographicSize;
        float halfW = mainCamera.aspect * halfH;

        float minX = cameraBounds.bounds.min.x + halfW;
        float maxX = cameraBounds.bounds.max.x - halfW;
        float minY = cameraBounds.bounds.min.y + halfH;
        float maxY = cameraBounds.bounds.max.y - halfH;

        Vector3 clampedPos = desiredPos;
        clampedPos.x = Mathf.Clamp(desiredPos.x, minX, maxX);
        clampedPos.y = Mathf.Clamp(desiredPos.y, minY, maxY);

        bool hitEdgeX = Mathf.Abs(clampedPos.x - desiredPos.x) > 0.0001f;
                         
        bool hitEdgeY = Mathf.Abs(clampedPos.y - desiredPos.y) > 0.0001f;

        if(hitEdgeX)
        {
            nextPosX = transform.position.x;
        }
        else
        {
            nextPosX = clampedPos.x;
        }
        if(hitEdgeY)
        {
            nextPosY = transform.position.y;
        }
        else
        {
            nextPosY = clampedPos.y;
        }

        transform.position = new Vector3(nextPosX, nextPosY, transform.position.z);
    }
}
