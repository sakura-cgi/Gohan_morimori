using UnityEngine;
using UnityEngine.Events;

public class TempTrigger : TriggerBase
{
    private TempManager targetScript; 
    private void Start()
    {
        targetScript = GetComponent<TempManager>();
    }

    private void OnTriggerEnter()
    {
        if (targetScript.temp <= 5)
        {
            action.Invoke();
        }
    }
}
