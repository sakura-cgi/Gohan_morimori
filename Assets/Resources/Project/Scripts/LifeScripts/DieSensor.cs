using UnityEngine;

public class DieSensor : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -15f)
        {
            LifeManager.Instance.life = 0;
        }
    }
}
