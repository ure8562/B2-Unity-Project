using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // ���� ��� (Player)
    public float smoothSpeed = 5f;  // �ε巴�� ���󰡴� �ӵ�

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
