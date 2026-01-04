using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartFade : MonoBehaviour
{

    [SerializeField] private Image fadeImage;
    public float fadeSpeed = 1f;
    void Start()
    {
        StartCoroutine(FadeIn());
    }
    public IEnumerator FadeOut()
    {
        fadeImage.gameObject.SetActive(true);
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(265, 265, 265, alpha);
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        fadeImage.gameObject.SetActive(true);
        float alpha = 1f;
        fadeImage.color = new Color(0, 0, 0, alpha);
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
    }
}
