using UnityEngine;

public class EnemyAIMove : MonoBehaviour
{
    [Header("移動速度")]
    [SerializeField] private float Speed = 2f;


    [Header("停止距離")]
    [SerializeField] private float stopRange = 1.2f;

    private Transform player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        //カメラ外の場合は停止
        if (!sr.isVisible)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            return;
        }

        // プレイヤー方向
        float dir = player.position.x > transform.position.x ? 1f : -1f;

        // 一定距離まで来たら止まる
        if (distance > stopRange)
        {
            rb.linearVelocity = new Vector2(dir * Speed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        // 向き
        sr.flipX = dir > 0;
    }
}