using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 10f, -10f);
    public float rotateSpeed = 5f;

    private float currentRotationY = 0f;

    void LateUpdate()
    {
        // 마우스 X 이동으로 회전
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
        currentRotationY += mouseX;

        Quaternion rotation = Quaternion.Euler(45f, currentRotationY, 0f); // 45도 탑다운 각도
        transform.position = target.position + rotation * offset;
        transform.LookAt(target.position);
    }
}
