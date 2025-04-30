using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TPSPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // ���� ��Ҵ��� �˻�
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // ��¦ �����ִ� �뵵 (����)
        }

        // �̵� �Է�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = (camForward * v + camRight * h).normalized;

        if (moveDir.magnitude >= 0.1f)
        {
            // ���� ȸ��
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }

        // ���� �Է�
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // ���� ���� ����
        }

        // �߷� ����
        velocity.y += gravity * Time.deltaTime;

        // ���� �̵� ó�� (���� + ����)
        Vector3 totalMove = moveDir * moveSpeed + velocity;
        controller.Move(totalMove * Time.deltaTime);
    }
}
