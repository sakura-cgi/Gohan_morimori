using UnityEngine;
using UnityEngine.Analytics;

public class AttackScript : MonoBehaviour
{
    private AttackSensor attackSensor;
    [SerializeField] private GameObject AttackSensorObject;
    [SerializeField] private TempManager tempManager;
    private static int overHeatTemp = 40;
    private static int overCoolTemp = 30;
    public int attackAnim; // 0: 火炎放射 1: 冷凍光線 2:攻撃していない
    private void Awake()
    {
        attackSensor = AttackSensorObject.GetComponent<AttackSensor>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (tempManager.temp <= overHeatTemp && tempManager.temp >= overCoolTemp)
        {
            AttackSensorObject.SetActive(false);
            attackAnim = 2;
            return;
        }
        if (Input.GetMouseButton(0))
        {
            if (tempManager.temp >= 41)
            {
                attackSensor.attackmode = 0; // 火炎放射
                attackAnim = 0;
                AttackSensorObject.SetActive(true);
            }
            else if (tempManager.temp <= 29)
            {
                attackSensor.attackmode = 1; // 冷凍光線
                attackAnim = 1;
                AttackSensorObject.SetActive(true);
            }
            else
            {
                return;
            }
        }
        else
        {
            attackAnim = 2;
            AttackSensorObject.SetActive(false);
        }

    }
}
