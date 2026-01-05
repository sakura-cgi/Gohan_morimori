using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class MenuScript : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private GameObject TitleAudio;
    [SerializeField] private AudioClip StartClip;
    private AudioSource audioSource;
    public float fadeSpeed = 1f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndGame();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
    public void StartGame()
    {
        if(GameManager.Instance)
        GameManager.Instance.ResetAll();
        TitleAudio.SetActive(false);
        audioSource.PlayOneShot(StartClip);
        StartCoroutine(StartGameCoroutine());
    }

    public IEnumerator StartGameCoroutine()
    {
        yield return StartCoroutine(FadeOut());
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Prologue");
    }

    public IEnumerator FadeOut()
    {
        fadeImage.gameObject.SetActive(true);
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
