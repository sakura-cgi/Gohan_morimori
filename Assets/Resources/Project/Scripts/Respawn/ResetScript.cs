using UnityEngine;

public class ResetScript : MonoBehaviour
{
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        RespawnManager.Instance.Register(gameObject);
    }

    public void ResetState()
    {
        transform.position = startPos;
    }
}
