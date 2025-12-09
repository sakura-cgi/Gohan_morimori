using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject pauseMenuUI; 
    [SerializeField] private Button resumeButton;     
    [SerializeField] private Button quitButton;
    [SerializeField] string MainMenu;  
     private bool isPaused = false;
    void Start()
    {
        pauseMenuUI.SetActive(false);
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePause();
        }
        
    }

    void ChangePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

     private void PauseGame()
    {
        // ゲーム時間を停止
        Time.timeScale = 0f;

        // UIを表示
        pauseMenuUI.SetActive(true);

        // ポーズ状態を更新
        isPaused = true;
    }
    private void ResumeGame()
    {
        // ゲーム時間を再開
        Time.timeScale = 1f;

        // UIを非表示
        pauseMenuUI.SetActive(false);

        // ポーズ状態を更新
        isPaused = false;
    }
    private void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainMenu);
        Debug.Log("Game Quit");
    }
}
