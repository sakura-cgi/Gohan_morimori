using UnityEngine;
using System.Collections.Generic;

public class EnemyMove : MonoBehaviour
{
    private SpriteRenderer sr = null;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (sr.isVisible)
        {
            Debug.Log("画面に見えている");
        }
    }

}
