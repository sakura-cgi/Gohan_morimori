using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DieSensor : MonoBehaviour
{
    private string rakka = "Rakka";

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag(rakka))
        {
            Debug.Log("死んだ");
            LifeManager.Instance.life = 0;
        }
    }
}
