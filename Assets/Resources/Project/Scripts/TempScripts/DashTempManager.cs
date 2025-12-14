using Unity.VisualScripting;
using UnityEngine;
public class DashTempManager : MonoBehaviour
{
    [SerializeField] private float LimitTime = 3f;
    [SerializeField] private PlayerMovement playermovement;

    private float firstActionTime;   // 1回目の入力時間
    private bool lastDashState = false;
    private float lastHeatTime;
    private float heatInterval = 1f; // 温度上昇の間隔

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
                    GetComponent<TempManager>().temp++;
                    lastHeatTime = now;
                    Debug.Log("Temperature +1");
                }
            }
        }
        else
        {
            // ダッシュ解除 → リセット
            firstActionTime = 0f;
            lastHeatTime = 0f;
        }

        lastDashState = playermovement.isDashing;

    }


}