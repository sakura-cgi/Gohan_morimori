using UnityEngine;

public class FootSound : MonoBehaviour
{
    private AudioSource footstepSource;
    private PlayerMovement playerMovement;
    [SerializeField] private AudioClip walkClip1;
    [SerializeField] private AudioClip walkClip2;
    [SerializeField]private AudioClip JumpClip;

    void Start()
    {
        footstepSource = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void PlayWalk1()
    {
        if (playerMovement.isGrounded)
        {
            footstepSource.PlayOneShot(walkClip1);
        }
    }
    public void PlayWalk2()
    {
        if (playerMovement.isGrounded)
        {
            footstepSource.PlayOneShot(walkClip2);
        }
    }
    public void PlayJump()
    {
        footstepSource.PlayOneShot(JumpClip);
    }

}
