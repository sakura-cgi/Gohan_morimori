using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject HighTempGameOver;
    [SerializeField] private GameObject DieGameOver;
    [SerializeField] string MainMenu;
    private bool hasExecuted = false;

    void Start()
    {
        HighTempGameOver.SetActive(false);
        DieGameOver.SetActive(false);
    }
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
            HighTempGameOver.SetActive(true);
            hasExecuted = true;
            StartCoroutine(HandleGameOver(HighTempGameOver));
        }
    }
    private void GameOver_Die()
    {
        if (!hasExecuted)
        {
            Debug.Log("Game Over: Life Depleted");
            DieGameOver.SetActive(true);
            hasExecuted = true;
            StartCoroutine(HandleGameOver(DieGameOver));
        }
    }

        private IEnumerator HandleGameOver(GameObject gameOverImage)
    {
        yield return new WaitForSeconds(1f); // 1秒間待機
        gameOverImage.SetActive(false); // ゲームオーバー画像を非表示
        ProceedToNextStep(); // 次の処理を呼び出す
    }

    private void ProceedToNextStep()
    {
        Debug.Log("Proceeding to the next step...");
        SceneManager.LoadScene(MainMenu);
    }
}
