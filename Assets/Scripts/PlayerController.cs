using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SPUM_Prefabs spum;   // SPUM 캐릭터 컨트롤

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spum = GetComponent<SPUM_Prefabs>();

        spum.OverrideControllerInit(); // ✅ 반드시 초기화 먼저
        spum.PopulateAnimationLists(); // ✅ 애니메이션 리스트 채우기
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize(); // 대각선 이동 속도 보정

        if (moveInput.sqrMagnitude > 0)
            spum.PlayAnimation(PlayerState.MOVE, 0);   // 이동 애니메이션
        else
            spum.PlayAnimation(PlayerState.IDLE, 0);   // 대기 애니메이션

        // 🔄 좌우 반전 처리
        if (moveInput.x > 0.1f)
            transform.localScale = new Vector3(-1, 1, 1);   // 오른쪽
        else if (moveInput.x < -0.1f)
            transform.localScale = new Vector3(1, 1, 1);  // 왼쪽
    }
    void FixedUpdate()
    {
        // Rigidbody를 이용해 이동
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
