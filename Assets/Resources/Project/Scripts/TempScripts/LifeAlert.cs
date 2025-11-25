using NUnit.Framework.Constraints;
using UnityEngine;

public class LifeAlert : TriggerBase
{
    private int pastlife = 0;
    [SerializeField] private GameObject LifeEffect;

    void Update()
    {
        if (GetComponent<LifeManager>().life <= 4  && pastlife > 4)
        {
            LifelowAlert();
        }

        if (GetComponent<LifeManager>().life <= 4)
        {
           LifeEffect.SetActive(true);
        }
        else
        {
            LifeEffect.SetActive(false);
        }
        pastlife = GetComponent<LifeManager>().life;
    }

    void LifelowAlert()
    {
        Debug.Log("Warning:Too low life!");
        action.Invoke();
    }
    
        
}
