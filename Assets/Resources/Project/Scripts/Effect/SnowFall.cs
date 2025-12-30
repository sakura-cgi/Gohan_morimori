using UnityEngine;

public class SnowFall : MonoBehaviour
{
    public float fallSpeed = 5f;
    public float rotateSpeed = 50f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        if (transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize - 1f)
        {
            Destroy(gameObject);
        }
    }


}
