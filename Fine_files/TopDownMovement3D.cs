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
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D 또는 ←/→
        float vertical = Input.GetAxisRaw("Vertical");     // W/S 또는 ↑/↓

        // XZ 평면 기준 이동 방향 설정
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (moveDirection != Vector3.zero)
        {
            // 이동 방향으로 캐릭터 회전 (즉시 방향 전환)
            transform.forward = moveDirection;
        }

        // 이동 처리
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
