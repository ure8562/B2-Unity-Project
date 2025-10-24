using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // 따라갈 대상 (Player)
    public float smoothSpeed = 5f;  // 부드럽게 따라가는 속도

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
