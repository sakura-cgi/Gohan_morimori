using UnityEngine;

public class LiftPlatform : MonoBehaviour
{
    public float moveSpeed = 2f;            // 移動速度
    public Transform upperLimitPoint;       // 上限オブジェクト

    private Vector3 startPos;
    private bool isPlayerOn = false;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 targetPos;

        if (isPlayerOn && upperLimitPoint != null)
        {
            // Yだけ上限オブジェクトに合わせる
            targetPos = new Vector3(
                transform.position.x,
                upperLimitPoint.position.y,
                transform.position.z
            );
        }
        else
        {
            targetPos = startPos;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOn = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOn = false;
        }
    }
}
