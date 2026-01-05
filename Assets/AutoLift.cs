using System.Collections.Generic;
using UnityEngine;

public class AutoLift : MonoBehaviour
{
    public float moveSpeed = 3f;
    public List<Transform> targetPoints;
    public float reachThreshold = 0.05f;

    public enum LoopMode
    {
        Always,         // 常時ループ
        PlayerTrigger,  // プレイヤーが乗ったら開始（降りたら停止）
        Toggle          // 乗るたびにON / OFF切り替え
    }

    public LoopMode loopMode = LoopMode.Always;
    public string playerTag = "Player";

    private int currentIndex = 0;
    private bool isMoving = false;

    void Start()
    {
        if (targetPoints == null || targetPoints.Count == 0)
        {
            Debug.LogWarning("ターゲットポイントが設定されていません");
            enabled = false;
            return;
        }

        // 常時ループなら最初から動かす
        if (loopMode == LoopMode.Always)
        {
            isMoving = true;
        }
    }

    void Update()
    {
        if (!isMoving) return;

        Transform target = targetPoints[currentIndex];
        if (target == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < reachThreshold)
        {
            currentIndex = (currentIndex + 1) % targetPoints.Count;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        switch (loopMode)
        {
            case LoopMode.PlayerTrigger:
                isMoving = true;
                break;

            case LoopMode.Toggle:
                isMoving = !isMoving;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        if (loopMode == LoopMode.PlayerTrigger)
        {
            isMoving = false;
        }
    }
}

// using System.Collections.Generic;
// using UnityEngine;

// public class AutoLift : MonoBehaviour
// {
//     public float moveSpeed = 3f;                  // 移動速度
//     public List<Transform> targetPoints;          // 移動先リスト
//     public float reachThreshold = 0.05f;          // 到達判定の誤差

//     private int currentIndex = 0;

//     void Start()
//     {
//         if (targetPoints == null || targetPoints.Count == 0)
//         {
//             Debug.LogWarning("ターゲットポイントが設定されていません");
//             enabled = false;
//             return;
//         }

//         // 最初のターゲットに一番近い位置から始めたい場合はここを拡張できる
//     }

//     void Update()
//     {
//         Transform target = targetPoints[currentIndex];
//         if (target == null) return;

//         transform.position = Vector3.MoveTowards(
//             transform.position,
//             target.position,
//             moveSpeed * Time.deltaTime
//         );

//         // 到達判定
//         if (Vector3.Distance(transform.position, target.position) < reachThreshold)
//         {
//             currentIndex = (currentIndex + 1) % targetPoints.Count;
//         }
//     }
// }
