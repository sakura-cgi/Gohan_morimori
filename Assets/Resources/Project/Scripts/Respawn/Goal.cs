using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int goalnum;
    [SerializeField] Image Stagetext;
    [SerializeField] Image fadeImage;
    public float fadeSpeed = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Goal Reached");
            if (goalnum == 1)
            {
                StartCoroutine(NextStage());
                Debug.Log("to2");
                SceneManager.LoadScene("stage2");
            }
            if (goalnum == 2)
            {
                StartCoroutine(NextStage());
                SceneManager.LoadScene("Stage3");
            }
            if (goalnum == 3)
            {
                StartCoroutine(NextStage());
                SceneManager.LoadScene("Stage3");
            }
            else
            {
                return;
            }
        }
    }
    public IEnumerator NextStage()
    {
        DialogManager.Instance.isTalking = true;
        yield return StartCoroutine(FadeOut());
        Stagetext.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Stagetext.gameObject.SetActive(false);
        DialogManager.Instance.isTalking = false;
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
