using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using NUnit.Framework;

public class SceneChange : MonoBehaviour,ActionBase
{
    [SerializeField] string sceneName;  
    [SerializeField] Image fadeImage;
    private float fadeSpeed = 1f;
    public void Action()
    {
        Debug.Log("SceneChange");
        StartCoroutine(FadeOut());
        SceneManager.LoadScene(sceneName);
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
