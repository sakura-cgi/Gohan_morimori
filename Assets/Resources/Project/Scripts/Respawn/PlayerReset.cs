using UnityEngine;

public class PlayerReset : MonoBehaviour
{
[SerializeField] private RespawnManager respawnManager;

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
        }
    }
}
