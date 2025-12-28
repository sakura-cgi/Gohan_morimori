using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private bool hasExecuted = false;
    [SerializeField] private RespawnManager respawnManager;
    void Update()
    {
        if (GetComponent<TempManager>().temp >= 50)
        {
            GameOver_High();
        }
        if (GetComponent<LifeManager>().life <= 0)
        {
            GameOver_Die();
            GetComponent<LifeManager>().life = 20;
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
        Debug.Log("Game Over: Life Depleted");
        respawnManager.ResetAll();
    }
}
