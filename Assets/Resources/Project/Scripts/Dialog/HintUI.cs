using UnityEngine;
using UnityEngine.UI;

public class HintUI : MonoBehaviour
{
    private DialogManager dialogManager;
    [SerializeField] GameObject tempslider;
    [SerializeField] GameObject Kabe;

    void Start()
    {
        dialogManager = GetComponent<DialogManager>();
    }
    void Update()
    {
        if (tempslider != null)
        {
            if (dialogManager.currentIndex < 13) //体温バーの出現
            {
                tempslider.SetActive(false);
            }
            else
            {
                tempslider.SetActive(true);
            }
        }
        if(Kabe != null)
        {
            if (dialogManager.currentIndex == 1)
            {
                Kabe.SetActive(false);
            }
        }

    }

}
