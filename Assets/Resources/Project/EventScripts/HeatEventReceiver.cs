using UnityEngine;

public class HeatEventReceiver : MonoBehaviour
{
    public HeatManager heatManager;

    public void OnJump()
    {
        heatManager.RegisterAction();
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
