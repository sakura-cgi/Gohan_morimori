using UnityEngine;

public class WallSensor : MonoBehaviour
{
    private EnemyMove enemyMove;
    [Header("敵で跳ね返る")] public bool BoundEnemy = true;
    [Header("壁で跳ね返る")] public bool BoundWall = true;

    void Awake()
    {
        enemyMove = GetComponentInParent<EnemyMove>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy_Gensei") || other.CompareTag("Enemy_Robot"))
        {
            if (BoundEnemy) enemyMove.Turn();
        }
        else if (other.CompareTag("Ground"))
        {
            if (BoundWall) enemyMove.Turn();
        }
    }
}
