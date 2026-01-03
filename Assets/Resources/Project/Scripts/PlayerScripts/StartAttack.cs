using System.Collections;
using UnityEngine;

public class StartAttack : MonoBehaviour
{
    float starttime;
    float now;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        now = Time.time;
        if(GetComponent<Animator>().GetInteger("Motion") == 3)
        {
            StartCoroutine(StartFireAttack());
        }
        
    }
    public IEnumerator StartFireAttack()
    {
        starttime = Time.time;
        if(now - starttime > 1f)
        {
            GetComponent<Animator>().SetInteger("Motion",4);
        }
        yield break;
    }
}
