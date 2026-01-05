using UnityEngine;

public class AutoLiftPlatform : MonoBehaviour
{
    public float moveSpeed = 2f;            // 移動速度
    public Transform upperLimitPoint;       // 上限
    public Transform lowerLimitPoint;       // 下限

    private bool movingUp = true;

    void Update()
    {
        if (upperLimitPoint == null || lowerLimitPoint == null)
            return;

        float targetY = movingUp
            ? upperLimitPoint.position.y
            : lowerLimitPoint.position.y;

        Vector3 targetPos = new Vector3(
            transform.position.x,
            targetY,
            transform.position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );

        // 到達判定（誤差対策）
        if (Mathf.Abs(transform.position.y - targetY) < 0.01f)
        {
            movingUp = !movingUp;
        }
    }
}
