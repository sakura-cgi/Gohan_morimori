using UnityEngine;
public class AttackTempManager : MonoBehaviour
{
    private int AttackCount = 0;
    [SerializeField] private float LimitTime = 3f; 

    private float firstActionTime;   // 1回目の入力時間
    private float lastInputTime;     // 最後に入力された時間
    private bool isHeatMode = false;


    public void OnAttack()
    {
        CountAttack();
        Debug.Log("Attack action registered to HeatManager.");

    }

     private void CountAttack()
    {
        float now = Time.time;
        if(AttackCount == 0)
        {
            firstActionTime = now;
        }
        AttackCount++;
        lastInputTime = now;
        if (now - firstActionTime > LimitTime)
        {
            firstActionTime = now;
            AttackCount = 1;
        }
         if (AttackCount >= 3 && !isHeatMode)
        {
            isHeatMode = true;
            Debug.Log("Heat Mode ON");
        }
        if (isHeatMode)
        {
            GetComponent<TempManager>().temp ++;
            Debug.Log("Temperature +1");
        }
    }
    private void Update()
    {
        if(!isHeatMode) return;
        if (Time.time - lastInputTime > LimitTime)
        {
            AttackCount = 0;
            isHeatMode = false;
            Debug.Log("Attack Heat Mode OFF");
        }

    }


}