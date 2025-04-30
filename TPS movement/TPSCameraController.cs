using UnityEngine;

public class TPSCameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -5);
    public float mouseSensitivity = 3f;
    public float distance = 5f;
    public float height = 2f;

    private float yaw = 0f;
    private float pitch = 10f;

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -30f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 targetPosition = target.position + Vector3.up * height;
        Vector3 cameraPosition = targetPosition + rotation * new Vector3(0, 0, -distance);

        transform.position = cameraPosition;
        transform.LookAt(targetPosition);
    }
}
