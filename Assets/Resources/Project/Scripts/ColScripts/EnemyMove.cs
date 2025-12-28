using UnityEngine;
using System.Collections.Generic;

public class EnemyMove : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

void FixedUpdate()
{
    if (sr.isVisible || nonVisibleAct)
    {
        float x = rightTleftF ? speed : -speed;

        rb.linearVelocity = new Vector2(x, rb.linearVelocity.y);

        if (rightTleftF)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }
    else
    {
        rb.Sleep();
    }
}

    public void Turn()
    {
        rightTleftF = !rightTleftF;
    }


}
