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
    public bool isDashing = false;

    private bool isAttacking = false;
    private float moveInput;

    [SerializeField] float maxJumpHeight = 3f; // 最大ジャンプ高度
    private float jumpStartY;                  // ジャンプ開始時のY座標
    private bool isJumping = false;            // ジャンプ中かどうか

   [SerializeField] public JumpTempManager jumptempmanager;

    [SerializeField]private AttackTempManager attacktempmanager;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // --- 入力処理 ---
        moveInput = Input.GetAxisRaw("Horizontal");

        // --- ジャンプ開始 ---
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            jumpStartY = transform.position.y;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

           jumptempmanager.OnJump();
        }

        // --- ジャンプ中の処理 ---
        if (isJumping)
        {
            // Spaceを押している間 & 上限高度未満なら上昇
            if (Input.GetKey(KeyCode.Space) && (transform.position.y - jumpStartY) < maxJumpHeight)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
                // Debug.Log("ジャンプ中: " + (transform.position.y - jumpStartY));
            }
            else
            {
                isJumping = false;
            }
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

        // --- 攻撃 ---
        if (Input.GetKeyDown(KeyCode.LeftControl)&& !isAttacking)
        {
            isAttacking = true;
            anim.SetTrigger("Attack");

            attacktempmanager.OnAttack();
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isAttacking = false;
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
        anim.SetBool("isAttacking", isAttacking);


        // Motionの反映
        if (isDashing)
            anim.SetInteger("Motion", 2);
        else if (isWalking)
            anim.SetInteger("Motion", 1);
        else
            anim.SetInteger("Motion", 0);

    }

    void FixedUpdate()
    {
        if (!isJumping)
        {
            float currentSpeed = isDashing ? dashForce : moveSpeed;
            rb.linearVelocity = new Vector2(moveInput * currentSpeed, rb.linearVelocity.y);
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")){
            isGrounded = true;
        }
            
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = false;
    }
}