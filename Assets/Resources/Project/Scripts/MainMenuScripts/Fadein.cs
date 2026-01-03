using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fadein : MonoBehaviour
{

    [SerializeField] Image fadeImage;
    private float fadeSpeed = 1f;
    void Start()
    {
        StartCoroutine(FadeIn());
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
