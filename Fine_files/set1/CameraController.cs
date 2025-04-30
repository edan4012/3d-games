using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 10f, -10f);
    public float rotateSpeed = 5f;

    private float currentRotationY = 0f;

    void LateUpdate()
    {
        // ���콺 X �̵����� ȸ��
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
        currentRotationY += mouseX;

        Quaternion rotation = Quaternion.Euler(45f, currentRotationY, 0f); // 45�� ž�ٿ� ����
        transform.position = target.position + rotation * offset;
        transform.LookAt(target.position);
    }
}
