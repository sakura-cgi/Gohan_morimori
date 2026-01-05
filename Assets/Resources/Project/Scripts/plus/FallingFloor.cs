using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingFloor : MonoBehaviour
{
    public float fallDelay = 3f;
    public float respawnDelay = 4f;

    Rigidbody2D rb;
    Vector3 startPos;
    Quaternion startRot;

    bool triggered = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        startPos = transform.position;
        startRot = transform.rotation;

        // 初期状態：完全な床
        rb.bodyType = RigidbodyType2D.Static;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (triggered) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(FallSequence());
        }
    }

    IEnumerator FallSequence()
    {
        // ★ Staticのまま待機（物理計算ゼロ）
        yield return new WaitForSeconds(fallDelay);

        // ★ 落下開始
        rb.bodyType = RigidbodyType2D.Dynamic;

        yield return new WaitForSeconds(respawnDelay);
        Respawn();
    }

    void Respawn()
    {
        // ★ 一度Dynamicに戻して速度リセット
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // ★ 位置を戻す
        transform.position = startPos;
        transform.rotation = startRot;

        // ★ 再び床へ
        rb.bodyType = RigidbodyType2D.Static;

        triggered = false;
    }
}
