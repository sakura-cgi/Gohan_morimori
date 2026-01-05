using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;
    public Sprite[] Dialogs;
    public bool isTalking;
    [SerializeField] private Image dialogUI;
    public int currentIndex = 0;
    private int endIndex;
    private bool JustStart;
    private AudioSource audioSource;
    //音を鳴らしたくない番号
    private static readonly HashSet<int> noSEIndexes = new HashSet<int>
    {
        3939,
        100,
        200
    };

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
        dialogUI.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTalking) return;
        if (JustStart)
        {
            JustStart = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Next();
        }
    }

    public void StartDialog(int start, int end)
    {
        isTalking = true;
        currentIndex = start;
        endIndex = end;
        JustStart = true;

        dialogUI.gameObject.SetActive(true);
        dialogUI.sprite = Dialogs[currentIndex];
        if (!noSEIndexes.Contains(currentIndex))
        {
            audioSource.Play();
        }

        Time.timeScale = 0f; // ゲームを一時停止
        Debug.Log("Dialog Started");
    }

    private void Next()
    {

        currentIndex++;
        Debug.Log("Next");


        if (currentIndex > endIndex)
        {
            EndDialog();
        }
        else
        {
            if (!noSEIndexes.Contains(currentIndex))
            {
                audioSource.Play();
            }
            dialogUI.sprite = Dialogs[currentIndex];
        }
    }

    private void EndDialog()
    {
        isTalking = false;
        dialogUI.gameObject.SetActive(false);
        Time.timeScale = 1f; // ゲームを再開
        Debug.Log("Dialog Ended");
    }

}
