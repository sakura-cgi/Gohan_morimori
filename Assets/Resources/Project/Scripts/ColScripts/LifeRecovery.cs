using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeRecovery : MonoBehaviour
{
    [SerializeField] private LifeManager lifeManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lifeManager.life ++;
            RecoverySound.Instance.PlaySE();
            Debug.Log("ライフを回復した！");
            SceneManager.LoadScene("scene2");
            gameObject.SetActive(false);
        }
    }
}
