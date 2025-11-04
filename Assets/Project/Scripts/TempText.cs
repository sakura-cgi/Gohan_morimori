using UnityEngine;
using UnityEngine.UI;

public class TempText : MonoBehaviour
{
    [SerializeField] private TempManager targetScript;
    [SerializeField] private Image TempTextImage;  // 表示するImage（UI）
    [SerializeField] private Sprite[] TempSprites;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TempSprites != null && TempSprites.Length != 0){
            int i = targetScript.temp;
            TempTextImage.sprite = TempSprites[i];
        } 
    }
}
