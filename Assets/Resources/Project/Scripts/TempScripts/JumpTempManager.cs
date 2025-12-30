using UnityEngine;
public class JumpTempManager : MonoBehaviour
{
    private int jumpCount = 0;
    [SerializeField] private float LimitTime = 5f; 

    private float firstActionTime;   // 1回目の入力時間
    private float lastInputTime;     // 最後に入力された時間
    public bool isHeatMode = false;


    public void OnJump()
    {
        if (Time.timeScale == 0f) return; // ポーズ中は処理しない
        CountJump();
        Debug.Log("Jump action registered to HeatManager.");

    }

     private void CountJump()
    {
        float now = Time.time;
        if(jumpCount == 0)
        {
            firstActionTime = now;
        }
        jumpCount++;
        lastInputTime = now;
        if (now - firstActionTime > LimitTime)
        {
            firstActionTime = now;
            jumpCount = 1;
        }
         if (jumpCount >= 3 && !isHeatMode)
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
            jumpCount = 0;
            isHeatMode = false;
            Debug.Log("Jump Heat Mode OFF");
        }

    }


}