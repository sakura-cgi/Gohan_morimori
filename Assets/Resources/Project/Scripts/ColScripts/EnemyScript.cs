using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private string GenseiEnemyTag = "Enemy_Gensei";
    private string RobotEnemyTag = "Enemy_Robot";

    [SerializeField] private LifeManager lifeManager;

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == GenseiEnemyTag)
        {
            Debug.Log("原生生物と接触した！");
            lifeManager.life -= 4;
        }
    
        if (collision.collider.tag == RobotEnemyTag)
        {
            Debug.Log("ロボットと接触した！");
            lifeManager.life -= 4;
        }
    }
    #endregion
}