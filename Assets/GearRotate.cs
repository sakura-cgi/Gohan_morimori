using UnityEngine;

public class GearRotate : MonoBehaviour
{
    public enum RotateDirection
    {
        Clockwise,        // 時計回り
        CounterClockwise  // 反時計回り
    }

    [Header("回転設定")]
    [SerializeField] private RotateDirection direction;
    [SerializeField] private float rotateSpeed = 90f;

    void Update()
    {
        float dir = direction == RotateDirection.Clockwise ? -1f : 1f;
        transform.Rotate(0f, 0f, rotateSpeed * dir * Time.deltaTime);
    }
}
