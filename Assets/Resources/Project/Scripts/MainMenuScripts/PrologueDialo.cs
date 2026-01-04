using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrologueDialog : MonoBehaviour
{
    public Sprite[] Dialogs;
    [SerializeField] private Image dialogUI;
    private int currentIndex;
    [SerializeField] private Image fadeImage;
    public float fadeSpeed = 1f;
    private float waitTimer = 0f;
    private float inputCooldown = 1f; // 1秒
    private float inputTimer = 0f;
    private bool inputLocked = false;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip warningSE;
    [SerializeField] private AudioClip crashSE;
    [SerializeField] private AudioClip NoticeSE;
    [SerializeField] private AudioClip SnowSE;


    void Awake()
    {
        dialogUI.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        HandleStep();
    }

    // Update is called once per frame
    void Update()
    {
        waitTimer += Time.deltaTime;
        if (inputLocked)
        {
            inputTimer += Time.deltaTime;
            if (inputTimer >= inputCooldown)
            {
                inputLocked = false;
                inputTimer = 0f;
            }
            return;
        }
        if (waitTimer > 5f)
        {
            HandleStep();
            waitTimer = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            HandleStep();
        }


    }

    private void HandleStep()
    {
        inputLocked = true;
        switch (currentIndex)
        {
            case 0:
                audioSource.PlayOneShot(warningSE);
                break;

            case 1:
                audioSource.PlayOneShot(crashSE);
                break;

            case 2:
                ShowDialog(0); // 主人公「……」
                break;

            case 3:
                ShowDialog(1); // 「………寒い」
                break;

            case 4:
                ShowDialog(2);
                break;

            case 5:
                ShowDialog(3);
                break;

            case 6:
                ShowDialog(4);
                break;

            case 7:
                ShowDialog(5);
                break;

            case 8:
                ShowDialog(6);
                break;

            case 9:
                audioSource.PlayOneShot(NoticeSE);
                break;

            case 10:
                ShowDialog(7); // 主人公「…!!!」
                break;

            case 11:
                ShowDialog(8); // 主人公「ここは…」
                break;

            case 12:
                StartCoroutine(FadeIn());
                break;

            case 13:
                ShowDialog(9); // 【地球】
                break;

            case 14:
                ShowDialog(10);
                break;

            case 15:
                ShowDialog(11);
                break;

            case 16:
                ShowDialog(12);
                break;

            case 17:
                StartCoroutine(FadeOut());
                StartCoroutine(TextFadeOut());
                break;

            case 18:
                audioSource.PlayOneShot(SnowSE);
                break;
            default:
                EndDialog();
                return;
        }
        Debug.Log(currentIndex);
        currentIndex++;

    }

    void ShowDialog(int index)
    {
        dialogUI.gameObject.SetActive(true);
        dialogUI.sprite = Dialogs[index];
    }

    void EndDialog()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ver.1");
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

    public IEnumerator TextFadeOut()
    {
        float alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            dialogUI.color = new Color(265, 265, 265, alpha);
            yield return null;
        }
    }
    public IEnumerator FadeIn()
    {
        float alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
    }

}






