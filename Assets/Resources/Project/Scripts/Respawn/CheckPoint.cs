using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private RespawnManager respawnManager;
    [SerializeField] private LifeManager lifeManager;

    private bool NearFire = false;
    private float healTimer = 0f;
    private float healInterval = 1f; // 1秒

    void Start()
    {
        respawnManager.SetCheckpoint(transform.position);
        Debug.Log("Initial Checkpoint Set at: " + transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            respawnManager.SetCheckpoint(other.transform.position);
            NearFire = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            NearFire = false;
        }
    }
    void Update()
    {
        if (NearFire)
        {
            healTimer += Time.deltaTime;

            if (healTimer >= healInterval)
            {
                lifeManager.life += 1;
                healTimer = 0f;
            }
        }
        else
        {
            healTimer = 0f;
        }
    }
}
