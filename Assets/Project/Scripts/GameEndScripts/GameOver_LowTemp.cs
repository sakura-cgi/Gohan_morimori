using UnityEngine;
using UnityEngine.UI;

public class GameOver_LowTemp : MonoBehaviour
{
    private bool hasExecuted = false;
    void Update()
    {
        if (GetComponent<TempManager>().temp >= 50)
        {
            GameOver_High();
        }
        if( GetComponent<LifeManager>().life <= 0)
        {
            GameOver_Die();
        }
    }



    private void GameOver_High()
    {
        if (!hasExecuted)
        {
            Debug.Log("Game Over: High Temperature");
            hasExecuted = true;
        }
    }
    private void GameOver_Die()
    {
        if (!hasExecuted)
        {
            Debug.Log("Game Over: Life Depleted");
            hasExecuted = true;
        }
    }
}
