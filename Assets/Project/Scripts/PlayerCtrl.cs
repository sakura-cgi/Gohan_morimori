//using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 7f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    void Start() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
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
