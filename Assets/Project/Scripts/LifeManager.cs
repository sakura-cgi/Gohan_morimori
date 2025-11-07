using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private Image[] LifeImage;
    public int life = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < life; i++)
        {
            LifeImage[i].enabled = true;
            ///rect.localPosition += new Vector3(10, 0, 0);
        }
    }
}
