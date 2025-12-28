using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public int StartNum;
    public int EndNum;
    private bool playerInRange = false;
    [SerializeField] private DialogManager dialogManager;

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
        if(dialogManager.isTalking) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogManager.StartDialog(StartNum, EndNum);
        }
    }
}
