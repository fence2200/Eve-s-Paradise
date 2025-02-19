using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어 이동속도
    private Rigidbody rb; // 플레이어 RigidBody
    private Vector3 moveInput; // 플레이어 이동Input
    private Animator animator; // 플레이어 애니메이터

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // private RigidBody 컴포넌트 스크립트로 가져오기
        animator = GetComponent<Animator>(); // private Animator 컴포넌트 스크립트로 가져오기
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // GetKey()를 사용해서 이동 입력 감지
        if (Input.GetKey(KeyCode.D)) moveX = 1f;  // 오른쪽 이동
        if (Input.GetKey(KeyCode.A)) moveX = -1f; // 왼쪽 이동
        if (Input.GetKey(KeyCode.W)) moveZ = 1f;  // 앞으로 이동
        if (Input.GetKey(KeyCode.S)) moveZ = -1f; // 뒤로 이동

        moveInput = new Vector3(moveX, 0f, moveZ).normalized;

        // 이동 방향으로 캐릭터 회전 (애니메이션이 하나만 있어도 해결 가능)
        if (moveInput != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // 걷는 애니메이션 적용 (움직일 때만 실행)
        animator.SetBool("isRunning", moveInput.magnitude > 0);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
