using UnityEngine;
using UnityEngine.UI;

public class HintUI : MonoBehaviour
{
    private DialogManager dialogManager;
    [SerializeField] GameObject tempslider;
    [SerializeField] GameObject tempimage;

    void Start()
    {
        dialogManager = GetComponent<DialogManager>();
    }
    void Update()
    {
        if(dialogManager.currentIndex < 2) //体温バーの出現
        {
            tempslider.SetActive(false);
            tempimage.SetActive(false);
        }else
        {
            tempslider.SetActive(true);
            tempimage.SetActive(true);
        }
        
    }

}
