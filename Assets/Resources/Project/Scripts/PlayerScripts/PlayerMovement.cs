using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Analytics;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float dashForce = 12.0f;
    [SerializeField] float jumpForce = 10f;

    private Rigidbody2D rb;
    private Animator anim;
    private clothesChanger clothes;
    public bool isGrounded;
    public bool isDashing = false;
    public bool isWalking = false;

    private float moveInput;

    public bool isKnockback;
    private bool jumpPressed;   // ジャンプ入力があったか
    private bool jumpHeld;      // ジャンプを押し続けているか

    [SerializeField] float maxJumpHeight = 3f; // 最大ジャンプ高度
    private float jumpStartY;                  // ジャンプ開始時のY座標
    public bool isJumping = false;            // ジャンプ中かどうか

    [SerializeField] public JumpTempManager jumptempmanager;

    [SerializeField] private AttackTempManager attacktempmanager;
    private FootSound footsound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        clothes = GetComponent<clothesChanger>();
        footsound = GetComponent<FootSound>();
    }

    void Update()
    {
        if (LifeManager.Instance.isDead)
        {
            anim.SetInteger("Motion", 0);
            isDashing = false;
            jumpHeld = false;
            return;
        }
        if (DialogManager.Instance.isTalking) return;
        if (GetComponent<AttackScript>().isAttacking) return;

        // ステータス計算
        moveSpeed = 5f - 0.5f * clothes.currentClothes;
        dashForce = 10f - 1f * clothes.currentClothes;
        jumpForce = 15f - 1f * clothes.currentClothes;
        maxJumpHeight = 15f - 1f * clothes.currentClothes;

        // 入力
        moveInput = Input.GetAxisRaw("Horizontal");

        // ジャンプ入力
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpPressed = true;
            jumpHeld = true;
            jumpStartY = transform.position.y;
            jumptempmanager.OnJump();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpHeld = false;
        }

        // ダッシュ入力
        if (Input.GetKeyDown(KeyCode.LeftShift) && Mathf.Abs(moveInput) > 0.1f)
            isDashing = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            isDashing = false;

        // 向き
        if (moveInput > 0) transform.localScale = new Vector2(1, 1);
        else if (moveInput < 0) transform.localScale = new Vector2(-1, 1);

        // Animator
        isWalking = Mathf.Abs(moveInput) > 0.1f && !isDashing;
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isDashing", isDashing);

        // 攻撃以外のMotionの反映

        if (isDashing)
            anim.SetInteger("Motion", 2);
        else if (isWalking)
            anim.SetInteger("Motion", 1);
        else
        {
            if(anim.GetInteger("Motion") != 5 && anim.GetInteger("Motion") != 8) {
            anim.SetInteger("Motion", 0);
            }
        }

    }

    void FixedUpdate()
    {
        if (LifeManager.Instance.isDead)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        if (DialogManager.Instance.isTalking) return;
        if (GetComponent<AttackScript>().attackAnim < 2) return;
        if(GetComponent<EnemyCollisionScript>().isInvincible == true) return;

        // 横移動
        float speed = isDashing ? dashForce : moveSpeed;
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // ジャンプ開始（Impulseは1回だけ）
        if (jumpPressed)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            footsound.PlayJump();
            isJumping = true;
            jumpPressed = false;
        }

        // ジャンプ中の上昇（一定時間 or 高さ制限）
        if (isJumping && jumpHeld)
        {
            float height = transform.position.y - jumpStartY;
            if (height < maxJumpHeight)
            {
                rb.AddForce(Vector2.up * jumpForce * 0.5f, ForceMode2D.Force);
            }
            else
            {
                isJumping = false;
            }
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}