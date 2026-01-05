using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public int goalnum;

    [SerializeField] Image stageText;
    [SerializeField] Image fadeImage;
    public float fadeSpeed = 1f;

    private bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (isTransitioning) return;

        isTransitioning = true;
        Debug.Log("Goal Reached");

        StartCoroutine(NextStage());
    }

    IEnumerator NextStage()
    {
        DialogManager.Instance.isTalking = true;

        yield return StartCoroutine(FadeOut());

        stageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        stageText.gameObject.SetActive(false);

        LoadNextScene();

        DialogManager.Instance.isTalking = false;
    }

    void LoadNextScene()
    {
        switch (goalnum)
        {
            case 1:
                SceneManager.LoadScene("Stage2");
                break;
            case 2:
                SceneManager.LoadScene("Stage3");
                break;
            case 3:
                SceneManager.LoadScene("Stage4");
                break;
            case 4:
                SceneManager.LoadScene("Stage5");
                break;
            default:
                Debug.LogWarning("無効な goalnum");
                break;
        }
    }

    IEnumerator FadeOut()
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

// using UnityEngine;
// using System.Collections;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class Goal : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     public int goalnum;
//     [SerializeField] Image Stagetext;
//     [SerializeField] Image fadeImage;
//     public float fadeSpeed = 1f;

//     private void OnTriggerEnter2D(Collider2D other)
//     {

//         if (other.CompareTag("Player"))
//         {
//             Debug.Log("Goal Reached");
//             if (goalnum == 1)
//             {
//                 StartCoroutine(NextStage());
//                 Debug.Log("to2");
//                 SceneManager.LoadScene("Stage2");
//             }
//             if (goalnum == 2)
//             {
//                 StartCoroutine(NextStage());
//                 SceneManager.LoadScene("Stage3");
//             }
//             if (goalnum == 3)
//             {
//                 StartCoroutine(NextStage());
//                 SceneManager.LoadScene("Stage4");
//             }
//             else
//             {
//                 return;
//             }
//         }
//     }
//     public IEnumerator NextStage()
//     {
//         DialogManager.Instance.isTalking = true;
//         yield return StartCoroutine(FadeOut());
//         Stagetext.gameObject.SetActive(true);
//         yield return new WaitForSeconds(1f);
//         Stagetext.gameObject.SetActive(false);
//         DialogManager.Instance.isTalking = false;
//     }

//     public IEnumerator FadeOut()
//     {
//         fadeImage.gameObject.SetActive(true);
//         float alpha = 0f;
//         while (alpha < 1f)
//         {
//             alpha += Time.deltaTime * fadeSpeed;
//             fadeImage.color = new Color(0, 0, 0, alpha);
//             yield return null;
//         }
//     }
// }
