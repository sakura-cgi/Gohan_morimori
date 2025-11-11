using UnityEngine;
using UnityEngine.UI;

public class SliderColorCtrl : MonoBehaviour
{
    [SerializeField] private Slider slider; // スライダーの参照
    [SerializeField] private Color startColor; // 開始色
    [SerializeField] private Color midColor; // 中間色
    [SerializeField] private Color endColor; // 終了色
    [SerializeField] private Image fillImage; // Fill部分のImageコンポーネントの参照

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (slider != null)
        {
            slider.onValueChanged.AddListener(UpdateFillColor); // スライダーの値変更時に色を更新
        }
    }

    private void UpdateFillColor(float value)
    {
        if (fillImage != null && slider != null)
        {
            // スライダーの値を0~1に正規化
            float normalizedValue = (value - slider.minValue) / (slider.maxValue - slider.minValue);
            if(normalizedValue < 0.5f)
            {
                // 0.0から0.5の範囲ではstartColorからmidColorへ補間
                normalizedValue = normalizedValue * 2.0f; // 0.0から1.0に
                fillImage.color = Color.Lerp(startColor, midColor, normalizedValue);
                return;
            }
            else
            {
                // 0.5から1.0の範囲ではmidColorからendColorへ補間
                normalizedValue = (normalizedValue - 0.5f) * 2.0f; // 0.0から1.0に
                fillImage.color = Color.Lerp(midColor, endColor, normalizedValue);
                return;
            }
        }
    }
}
