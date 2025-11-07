using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TempShow : MonoBehaviour
{
    public GameObject temp_object = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Text temp_text = temp_object.GetComponent<Text>();
       TempManager temp_manager = GetComponent<TempManager>();
        temp_text.text = temp_manager.temp.ToString();
        if(Input.GetKey(KeyCode.Space)){
            temp_manager.temp = 27;
        }
        else
        {
            temp_manager.temp = 26;
        }
    }
}
