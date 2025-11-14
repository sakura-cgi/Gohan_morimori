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
