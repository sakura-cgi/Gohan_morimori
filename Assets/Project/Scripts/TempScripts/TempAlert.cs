using NUnit.Framework.Constraints;
using UnityEngine;

public class TempAlert : TriggerBase
{
    private int pasttemp = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ///1フレーム前の体温が44度以下で、現在の体温が45度以上になったら高温アラート
        if (GetComponent<TempManager>().temp >= 45 && pasttemp < 45)
        {
            TempHighAlert();
        }
        if (GetComponent<TempManager>().temp <= 25 && pasttemp > 25)
        {
            TempLowAlert();
        }
        pasttemp = GetComponent<TempManager>().temp;
    }

    void TempHighAlert()
    {
        Debug.Log("Warning: High Temperature!");
        action.Invoke();
    }
    
    void TempLowAlert()
    {
        Debug.Log("Warning: Low Temperature!");
        action.Invoke();
    }
        
}
