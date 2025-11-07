using UnityEngine;
using UnityEngine.UI;

public class GameOver_LowTemp : MonoBehaviour,ActionBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TempManager temp_manager = GetComponent<TempManager>();
        if (temp_manager.temp <= 5)
        {

        }

    }
    
    public void Action()
    {
        Debug.Log("Game Over: Low Temperature");
    }
}
