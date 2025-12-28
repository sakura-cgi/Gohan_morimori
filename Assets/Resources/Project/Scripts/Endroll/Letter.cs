using UnityEngine;

public class Letter : MonoBehaviour
{
    public int maxHP = 5;   // 文字の耐久値
    private int currentHP;

    public float moveSpeed = -0.01f;   // 左にスクロール
    public float stopX = 0;         // 文字を止める位置
    [SerializeField]private Shooting shooting;
    public int LetterNum;
    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        if(shooting.DisplayNum == LetterNum){
        // 左に移動し、stopXで止まる
        Vector3 pos = transform.position;
        pos.x += moveSpeed;
        if (pos.x < stopX){ 
            pos.x = stopX;
            shooting.ismoving = false;
            }
            else
            {
                shooting.ismoving = true;
            }
        transform.position = pos;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);              // 弾1発で1ダメージ
            Destroy(other.gameObject);  // 弾を消す
        }
    }

    void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        shooting.DisplayNum++; //次の文字を動かす
        Destroy(gameObject); // 文字を消す
    }
}
