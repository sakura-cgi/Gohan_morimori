using UnityEngine;

public class CliffSensor : MonoBehaviour
{
    private EnemyMove enemyMove;

    void Awake()
    {
        enemyMove = GetComponentInParent<EnemyMove>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            enemyMove.Turn();
        }
    }
}
