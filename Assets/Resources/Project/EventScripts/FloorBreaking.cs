using UnityEngine;

public class FloorBreaking : MonoBehaviour
{
    [SerializeField] private float disappearDelay = 3f; // 消滅までの時間
    [SerializeField] private float respawnDelay = 5f; // 復活までの時間
    private bool isBroken = false;
    private float timer = 0f;
    private new Collider2D collider;

    void Start()
    {
        collider = GetComponent<Collider2D>(); // Collider2Dを取得
    }

    void Update()
    {
        if (isBroken)
        {
            timer += Time.deltaTime;

            // 一定時間後にisTriggerをtrueにする
            if (timer >= disappearDelay && !collider.isTrigger)
            {
                collider.isTrigger = true; // すり抜け可能にする
            }

            // 復活タイミング
            if (timer >= disappearDelay + respawnDelay)
            {
                Respawn(); // リスポーン処理を呼び出す
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Playerタグのオブジェクトが触れた場合
        if (collision.collider.CompareTag("Player") && !isBroken)
        {
            isBroken = true; // break状態にする
            timer = 0f; // タイマーをリセット
        }
    }

    void Respawn()
    {
        collider.isTrigger = false; // すり抜けを無効化
        isBroken = false; // break状態をリセット
        timer = 0f; // タイマーをリセット
    }
}
