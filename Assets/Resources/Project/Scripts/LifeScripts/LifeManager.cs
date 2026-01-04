using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeManager : MonoBehaviour
{
     public static LifeManager Instance;
    public int life = 20;
    public GameObject[] LifeDisplay = new GameObject[5];
    public Sprite[] lifequrter = new Sprite[5];
    private int currentlife;
    public int displayLife;
    public int qurterlife;

    public bool isDead = false;

    private float damageTimer = 0f; // ダメージを与えるためのタイマー
    private float damageInterval = 3f; // ダメージを与える間隔

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
        life = GameManager.Instance.life;
        currentlife = life;
        Updatelife();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            life++;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            life--;
        }

        if (GetComponent<TempManager>().temp > 40)
        {
            damageTimer += Time.deltaTime; // タイマーを進める
            if (damageTimer >= damageInterval)
            {
                life--; // ライフを1減らす
                damageTimer = 0f; // タイマーをリセット
            }
        }
        else
        {
            damageTimer = 0f; // 温度が41度以下の場合、タイマーをリセット
        }

        if (life < 0)
        {
            life = 0;
        }
        else if (life > 20)
        {
            life = 20;
        }

        if (currentlife != life)
        {
            Updatelife();
        }

        if (life <= 0 && !isDead)
        {
            Die();
        }
        GameManager.Instance.life = life;


    }


    private void Updatelife()
    {
        currentlife = life;
        displayLife = (life + 3) / 4; ///ライフを4/1ずつ分割するための処理
        qurterlife = life % 4;
        for (int i = 0; i < LifeDisplay.Length; i++)
        {
            if (i == displayLife)
            {
                LifeDisplay[i].GetComponent<Image>().sprite = lifequrter[4];
            }


            if (i == displayLife - 1)
            {
                switch (qurterlife)
                {
                    case 0:
                        LifeDisplay[i].GetComponent<Image>().sprite = lifequrter[0];
                        break;
                    case 1:
                        LifeDisplay[i].GetComponent<Image>().sprite = lifequrter[3];
                        break;
                    case 2:
                        LifeDisplay[i].GetComponent<Image>().sprite = lifequrter[2];
                        break;
                    case 3:
                        LifeDisplay[i].GetComponent<Image>().sprite = lifequrter[1];
                        break;
                }
            }
            else if (i < displayLife - 1)
            {
                LifeDisplay[i].GetComponent<Image>().sprite = lifequrter[0];
            }
        }


    }

    private void Die()
    {
        StartCoroutine(DeadSequence());
        Debug.Log("Game Over: Life Depleted");
    }
    private IEnumerator DeadSequence()
    {
        isDead = true;

        // 操作停止
        DialogManager.Instance.isTalking = true; 


        // フェードアウト
        yield return StartCoroutine(RespawnManager.Instance.FadeOut());

        // --- ここでリスポーン処理 ---
        TempManager.Instance.temp = 35;
        life = 20;
        Updatelife();
        RespawnManager.Instance.ResetAll();

        // フェードイン
        yield return StartCoroutine(RespawnManager.Instance.FadeIn());

        // 操作再開
        DialogManager.Instance.isTalking = false;
        isDead = false;
    }
}
