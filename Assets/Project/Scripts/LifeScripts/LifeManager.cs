using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int life = 5;
    public GameObject[] LifeDisplay = new GameObject[5];
    private int currentlife;
    
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
        for (int i = 0; i < LifeDisplay.Length; i++)
        {
            if (i < life)
            {
                LifeDisplay[i].SetActive(true);
            }
            else
            {
                LifeDisplay[i].SetActive(false);
            }
        }
     
    }
}
