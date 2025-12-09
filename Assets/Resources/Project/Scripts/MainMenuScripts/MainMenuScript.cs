using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
[SerializeField] private Button StartButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    private void StartGame()
    {
        Debug.Log("Game Started");
        SceneManager.LoadScene("ver.1");  
    }
}
