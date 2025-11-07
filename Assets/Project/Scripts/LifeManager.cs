using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private Image LifeImage;
     [SerializeField] private RectTransform canvas;
    public int life = 5;
    void Start()
    {
         for (int i = 0; i < life; i++)
        {
            Image newLife = Instantiate(LifeImage,canvas);
            RectTransform rect = newLife.GetComponent<RectTransform>();
            rect.anchorMin = rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = new Vector2(i * 40 - 370, 130);

        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
