using UnityEngine;

public class Haikei : MonoBehaviour
{

    float speed = 1f;
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
