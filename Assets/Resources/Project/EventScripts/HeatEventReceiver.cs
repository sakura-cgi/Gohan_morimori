using UnityEngine;

public class HeatEventReceiver : MonoBehaviour
{
    public HeatManager heatManager;
    [SerializeField]  private GameObject TempManager;

    public void OnJump()
    {
        TempManager.temp ++;
        Debug.Log("Jump action registered to HeatManager.");

    }

    public void OnDash()
    {
        heatManager.RegisterAction();
        Debug.Log("Dash action registered to HeatManager.");
        
    }

    public void OnAttack()
    {
        heatManager.RegisterAction();
        Debug.Log("Attack action registered to HeatManager.");
    }
}
