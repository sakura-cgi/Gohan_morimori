using UnityEngine;

public class RecoverySound : MonoBehaviour
{
    public static RecoverySound Instance;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySE()
    {
        audioSource.Play();
    }
}
