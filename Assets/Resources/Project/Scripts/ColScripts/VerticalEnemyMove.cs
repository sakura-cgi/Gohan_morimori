using UnityEngine;

public class VerticalEnemyMove : MonoBehaviour
{
    [Header("上下移動の速さ")]
    [SerializeField] private float speed = 2f;

    [Header("移動距離（片道）")]
    [SerializeField] private float moveRange = 2f;

    private Vector2 startPos;

    void Start()
    {
        // 初期位置を記憶
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        float y = startPos.y + Mathf.Sin(Time.time * speed) * moveRange;
        transform.position = new Vector2(startPos.x, y);
    }
}
