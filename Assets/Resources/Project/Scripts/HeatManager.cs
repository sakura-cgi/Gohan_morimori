using UnityEngine;

public class HeatManager : MonoBehaviour
{
    public float bodyTemp = 38.0f; // 現在の体温

    public void AddHeat(float value)
    {
        bodyTemp += value;
        Debug.Log("体温: " + bodyTemp);
    }

    public void ReduceHeat(float value)
    {
        bodyTemp -= value;
        Debug.Log("体温: " + bodyTemp);
    }
}
