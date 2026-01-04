using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public int StartNum;
    public int EndNum;
    private bool playerInRange = false;
    [SerializeField] private DialogManager dialogManager;
    private bool canTalk = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }

    private void Update()
    {
        if (!playerInRange) return;
        if (dialogManager.isTalking)
        {
            canTalk = false;
            return;
        }

        // Enterを離したら再びOK
        if (!Input.GetKey(KeyCode.Return))
        {
            canTalk = true;
        }

        if (canTalk && Input.GetKeyDown(KeyCode.Return))
        {
            dialogManager.StartDialog(StartNum, EndNum);
        }
    }
}
