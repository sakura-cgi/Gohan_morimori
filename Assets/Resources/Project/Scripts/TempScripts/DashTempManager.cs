using Unity.VisualScripting;
using UnityEngine;

/// 体温の減少処理はDashTempManagerが担当する
public class DashTempManager : MonoBehaviour
{
    [SerializeField] private float LimitTime = 3f;
    [SerializeField] private PlayerMovement playermovement;
    [SerializeField] private JumpTempManager jumpTempManager;
    [SerializeField] private AttackTempManager attackTempManager;

    private float firstActionTime;   // 1回目の入力時間
    private bool lastDashState = false;
    private float lastHeatTime;
    private float heatInterval = 1f; // 温度上昇の間隔
    private float dashendtime;
    private float lastcooltime;
    private float lasthottime; ///基本体温以下の際の温度上昇用

    private TempManager tempManager;
    private void Awake()
    {
        tempManager = GetComponent<TempManager>();
    }

    private void Update()
    {
        float now = Time.time;
        if (!lastDashState && playermovement.isDashing)
        {
            firstActionTime = now;
            Debug.Log("Dash started, timer reset.");
        }
        if (playermovement.isDashing)
        {
            if (now - firstActionTime > LimitTime)
            {
                if (now - lastHeatTime >= heatInterval)
                {
                    tempManager.temp++;
                    lastHeatTime = now;
                    Debug.Log("Temperature +1");
                }
            }
            dashendtime = now; // ダッシュ中は終了時間を更新しない
        }
        else
        {
            // ダッシュ解除 → リセット
            firstActionTime = 0f;
            lastHeatTime = 0f;
        }

        if (lastDashState && !playermovement.isDashing)
        {
            dashendtime = now;
            lastcooltime = now;
            Debug.Log("Dash end");
        }

        if (now - dashendtime >= heatInterval)
        {
            if (tempManager.temp > tempManager.basic_temp)
            {
                if (now - lastcooltime >= heatInterval)
                {
                    if (!jumpTempManager.isHeatMode && !attackTempManager.isHeatMode)

                    {
                        tempManager.temp--;
                        lastcooltime = now;
                        Debug.Log("Cooling -1");
                    }
                }
            }
        }
        if (tempManager.temp < tempManager.basic_temp)
        {
            if (now - lasthottime >= heatInterval)
            {
                tempManager.temp++;
                lasthottime = now;
                Debug.Log("Heating +1");
            }
        }

        lastDashState = playermovement.isDashing;

    }


}