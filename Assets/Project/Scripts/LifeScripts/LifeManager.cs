using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int life = 20;
    public GameObject[] LifeDisplay = new GameObject[5];
    public Sprite[] lifequrter = new Sprite[4];
    private int currentlife;
    public int displayLife;
    public int qurterlife;

    private float damageTimer = 0f; // ダメージを与えるためのタイマー
    private float damageInterval = 3f; // ダメージを与える間隔

    void Start()
    {
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
        
        if(life < 0)
        {
            life = 0;
        }else if(life > 20)
        {
            life = 20;
        }

        if (currentlife != life)
        {
            Updatelife();
        }

   
    }

    
    private void Updatelife()
    {
        currentlife = life;
        displayLife = (life + 3) / 4; ///ライフを4/1ずつ分割するための処理
        qurterlife = life % 4;
        for (int i = 0; i < LifeDisplay.Length; i++)
        {

            if (i < displayLife)
            {
                LifeDisplay[i].SetActive(true);
            }
            else
            {
                LifeDisplay[i].SetActive(false);
            }

            if (i == displayLife - 1)
            {
                switch (qurterlife)
                {
                    case 0:
                        LifeDisplay[i].GetComponent<Image>().sprite = lifequrter[0];
                        break;
                    case 1:
                        LifeDisplay[i].GetComponent<Image>().sprite = lifequrter[1];
                        break;
                    case 2:
                        LifeDisplay[i].GetComponent<Image>().sprite = lifequrter[2];
                        break;
                    case 3:
                        LifeDisplay[i].GetComponent<Image>().sprite = lifequrter[3];
                        break;
                }
            }
        }

     
    }
}
