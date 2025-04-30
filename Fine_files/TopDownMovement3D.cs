using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TopDownMovement3D : MonoBehaviour
{
    public float moveSpeed = 5f;

    private CharacterController controller;
    private Vector3 moveDirection;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D �Ǵ� ��/��
        float vertical = Input.GetAxisRaw("Vertical");     // W/S �Ǵ� ��/��

        // XZ ��� ���� �̵� ���� ����
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (moveDirection != Vector3.zero)
        {
            // �̵� �������� ĳ���� ȸ�� (��� ���� ��ȯ)
            transform.forward = moveDirection;
        }

        // �̵� ó��
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
