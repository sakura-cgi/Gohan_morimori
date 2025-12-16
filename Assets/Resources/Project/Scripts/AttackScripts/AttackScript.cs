using UnityEngine;
using UnityEngine.Analytics;

public class AttackScript : MonoBehaviour
{
    private AttackSensor attackSensor;
    [SerializeField] private GameObject AttackSensorObject;
    [SerializeField] private TempManager tempManager;
    private void Awake()
    {
        attackSensor = GetComponent<AttackSensor>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(tempManager.temp >= 41)
            {
                attackSensor.attackmode = 0; // 冷凍攻撃
                AttackSensorObject.SetActive(true);
            }
            else if(tempManager.temp <= 29)
            {
                attackSensor.attackmode = 1; // 火炎攻撃
                AttackSensorObject.SetActive(true);
            }
            else
            {
                return;
            }
        }
        else
        {
            AttackSensorObject.SetActive(false);
        }

    }
}
