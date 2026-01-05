using UnityEngine;
using UnityEngine.UI;

/// 体温の減少処理はDashTempManagerが担当する

public class TempManager : MonoBehaviour
{
    public static TempManager Instance;
    public int temp;
    public int basic_temp;
    public Slider temp_slider = null; // Sliderオブジェクト

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        // Sliderの初期値を設定
        if (temp_slider != null)
        {
            temp_slider.value = temp;
        }
        temp =  GameManager.Instance.temp;
        basic_temp =  GameManager.Instance.basic_temp;

    }

    // Update is called once per frame
    void Update()
    {

        // Sliderの値を更新
        if (temp_slider != null)
        {
            temp_slider.value = temp;
        }
        GameManager.Instance.temp = temp;
        GameManager.Instance.basic_temp = basic_temp;
    }
}
