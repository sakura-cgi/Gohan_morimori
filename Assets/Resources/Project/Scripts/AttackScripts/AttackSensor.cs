using UnityEngine;

public class AttackSensor : MonoBehaviour
{
    public int attackmode; // 0:火炎攻撃 1:冷凍攻撃
    private string GenseiEnemyTag = "Enemy_Gensei";
    private string RobotEnemyTag = "Enemy_Robot";


    // Update is called once per frame
private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Enemy_Gensei"))
    {
        Debug.Log("原生生物を攻撃した！");
        Destroy(other.gameObject);
    }

    if (other.CompareTag("Enemy_Robot"))
    {
        Debug.Log("ロボットを攻撃した！");
        Destroy(other.gameObject);
    }
}
}
