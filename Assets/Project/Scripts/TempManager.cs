using UnityEngine;
using UnityEngine.UI;

public class TempManager : MonoBehaviour
{
    public int temp = 100; // 現在の体温
    public GameObject temp_object = null; // Textオブジェクト
    public Slider temp_slider = null; // Sliderオブジェクト

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Sliderの初期値を設定
        if (temp_slider != null)
        {
            temp_slider.value = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Text temp_text = temp_object.GetComponent<Text>();
        temp_text.text = "Temp:" + temp;

        // Sliderの値を更新
        if (temp_slider != null)
        {
            temp_slider.value = temp;
        }

        temp += 1;
    }
}
