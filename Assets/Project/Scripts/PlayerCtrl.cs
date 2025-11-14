using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float dashForce = 12.0f;
    [SerializeField] float jumpForce = 7f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private bool isDashing = false;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // --- 入力処理 ---
        moveInput = Input.GetAxisRaw("Horizontal");

        // --- ジャンプ ---
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // --- ダッシュ入力 ---
        if (Input.GetKeyDown(KeyCode.LeftShift) && Mathf.Abs(moveInput) > 0.1f)
        {
            isDashing = true;
            anim.SetBool("isDashing", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isDashing = false;
        }

        // --- 向き反転 ---
        if (moveInput > 0)
            transform.localScale = new Vector2(1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector2(-1, 1);

        // --- Animatorへの値反映 ---
        bool isWalking = Mathf.Abs(moveInput) > 0.1f && !isDashing;
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isDashing", isDashing);
    }

    void FixedUpdate()
    {
        // --- 通常移動 or ダッシュ移動 ---
        float currentSpeed = isDashing ? dashForce : moveSpeed;
        rb.linearVelocity = new Vector2(moveInput * currentSpeed, rb.linearVelocity.y);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = false;
    }
}



// using UnityEngine;

// [RequireComponent(typeof(Rigidbody2D))]
// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f;     // 左右移動速度
//     public float jumpForce = 10f;    // ジャンプの強さ
//     private Rigidbody2D rb;
//     private bool isGrounded = false;
//     private float moveInput;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     void Update()
//     {
//         // 左右移動入力
//         moveInput = Input.GetAxisRaw("Horizontal");

//         // ジャンプ
//         if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
//         {
//             rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
//         }
//     }

//     void FixedUpdate()
//     {
//         // 移動反映
//         rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
//     }

//     // 地面接触判定
//     void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.collider.CompareTag("Ground"))
//         {
//             isGrounded = true;
//         }
//     }

//     void OnCollisionExit2D(Collision2D collision)
//     {
//         if (collision.collider.CompareTag("Ground"))
//         {
//             isGrounded = false;
//         }
//     }
// }
