using NUnit.Framework.Constraints;
using UnityEngine;

public class TempAlert : TriggerBase
{
    private int pasttemp = 0;
    [SerializeField] private GameObject HighTempEffect;
    [SerializeField] private GameObject LowTempEffect;

    void Update()
    {
        ///1フレーム前の体温が40度以下で、現在の体温が41度以上になったら高温アラート
        if (GetComponent<TempManager>().temp >= 41 && pasttemp < 41)
        {
            TempHighAlert();
        }
        if (GetComponent<TempManager>().temp <= 29 && pasttemp > 29)
        {
            TempLowAlert();
        }

        if (GetComponent<TempManager>().temp >= 41)
        {
            HighTempEffect.SetActive(true);
        }
        else
        {
            HighTempEffect.SetActive(false);
        }
        
        if( GetComponent<TempManager>().temp <= 29)
        {
            LowTempEffect.SetActive(true);
        }
        else
        {
            LowTempEffect.SetActive(false);
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
