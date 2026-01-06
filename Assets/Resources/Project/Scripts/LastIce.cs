using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LastIce : MonoBehaviour
{
    public float timer;
    private bool melting;
    [SerializeField] private Image fadeImage;
    public float fadeSpeed = 1f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AttackSensor"))
        {
            if (other.GetComponent<AttackSensor>().attackmode == 0)
            {
                melting = true;
                Debug.Log("Melting");
            }
            else
            {
                melting = false;
            }
        }
        else
        {
            melting = false;
        }
    }

    void Update()
    {
        if (melting == true)
        {
            timer += Time.deltaTime;
        }

        if (timer > 5f)
        {
            timer = 0f;
            GetComponent<AudioSource>().Play();
            StartCoroutine(LoadEnd());
        }
    }

    private IEnumerator LoadEnd()
    {
        fadeImage.gameObject.SetActive(true);
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(265, 265, 265, alpha);
            yield return SceneManager.LoadSceneAsync("Ending");
        }
    }
}
