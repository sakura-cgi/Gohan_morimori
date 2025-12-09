using UnityEngine;

public class HeatManager : MonoBehaviour
{
    [Header("設定")]
    public float heat;       // 現在体温
    public float heatPerAction = 1f; // 3回後の行動ごとの上昇値

    public float windowTime = 5f;    // 5秒以内に3回の条件
    public float resetTime = 3f;     // 3秒間入力がなければリセット

    private int actionCount = 0;     // 何回入力されたか
    private float firstActionTime;   // 1回目の入力時間
    private float lastInputTime;     // 最後に入力された時間

    private bool inHeatMode = false; // 3回達成後モード

    void Update()
    {
        // 一定時間入力されなかったらリセット
        if (Time.time - lastInputTime > resetTime)
        {
            ResetHeatCounter();
        }
    }

    
    public void RegisterAction()
    {
        float now = Time.time;

        // 1回目
        if (actionCount == 0)
        {
            firstActionTime = now;
        }

        actionCount++;
        lastInputTime = now;

        Debug.Log($"🔥入力 {actionCount} 回目");

        // まだ3回未満 → チェックだけ
        if (actionCount < 3)
            return;

        // 3回以上の処理 -----------------------------
        if (!inHeatMode)
        {
            // 5秒以内の3回なら加熱モード突入
            if (now - firstActionTime <= windowTime)
            {
                inHeatMode = true;
                Debug.Log("🔥🔥 加熱モード突入！（3回達成）");
            }
            else
            {
                // 5秒超えてたらやり直し
                ResetHeatCounter();
                return;
            }
        }

        // 加熱モード中は 1 行動ごとに体温上昇
        AddHeat(heatPerAction);
    }

    public void AddHeat(float amount)
    {
        heat += amount;
        Debug.Log($"🌡体温上昇: +{amount}℃ → 現在 {heat}℃");
    }

    private void ResetHeatCounter()
    {
        if (actionCount > 0 || inHeatMode)
            Debug.Log("❄ 入力なし → カウントリセット");

        actionCount = 0;
        inHeatMode = false;
    }
}
