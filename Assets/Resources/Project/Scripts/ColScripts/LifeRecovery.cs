using UnityEngine;

public class LifeRecovery : MonoBehaviour
{
    [SerializeField] private LifeManager lifeManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lifeManager.life ++;
            Debug.Log("ライフを回復した！");
            gameObject.SetActive(false);
        }
    }
}
