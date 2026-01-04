using UnityEngine;
using System.Collections;

public class EnemyCollisionScript : MonoBehaviour
{
    private string GenseiEnemyTag = "Enemy_Gensei";
    private string RobotEnemyTag = "Enemy_Robot";

    public bool isInvincible = false;

    [SerializeField] private LifeManager lifeManager;

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == GenseiEnemyTag)
        {
            if (isInvincible) return;
            Debug.Log("原生生物と接触した！");
            StartCoroutine(GenseiDamageCoroutine(collision.collider));
        }

        if (collision.collider.tag == RobotEnemyTag)
        {
            if (isInvincible) return;
            Debug.Log("ロボットと接触した！");
            StartCoroutine(RobotDamageCoroutine(collision.collider));
        }
    }
    #endregion

    private IEnumerator GenseiDamageCoroutine(Collider2D enemy)
    {
        isInvincible = true;

        // ダメージ処理
        lifeManager.life -= 4;

        // ノックバック（2D）
        var rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;

        float direction = transform.position.x < enemy.transform.position.x ? -1f : 1f;

        Vector2 knockback = new Vector2(direction * 6f, 2f);
        rb.AddForce(knockback, ForceMode2D.Impulse);

        // 無敵時間
        Debug.Log("無敵時間開始");
        yield return new WaitForSeconds(1f);
        Debug.Log("無敵時間終了");

        isInvincible = false;
    }

        private IEnumerator RobotDamageCoroutine(Collider2D enemy)
    {
        isInvincible = true;

        // ダメージ処理
        lifeManager.life -= 4;

        // ノックバック（2D）
        var rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;

        float direction = transform.position.x < enemy.transform.position.x ? -1f : 1f;

        Vector2 knockback = new Vector2(direction * 6f, 2f);
        rb.AddForce(knockback, ForceMode2D.Impulse);

        // 無敵時間
        Debug.Log("無敵時間開始");
        yield return new WaitForSeconds(1f);
        Debug.Log("無敵時間終了");

        isInvincible = false;
    }
}