using UnityEngine;

public class AttackSensor : MonoBehaviour
{
    public int attackmode = 0; // 0:火炎攻撃 1:冷凍攻撃
    private string GenseiEnemyTag = "Enemy_Gensei";
    private string RobotEnemyTag = "Enemy_Robot";

    public AudioClip genseiHitSE;
    public AudioClip robotHitSE;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GenseiEnemyTag))
        {
            if (attackmode == 0)
            {
                Debug.Log("原生生物を攻撃した！");
                Destroy(other.gameObject);
                audioSource.PlayOneShot(genseiHitSE);

            }
            else if (attackmode == 1)
            {
                Debug.Log("原生生物に効果はないようだ…");
            }
        }

        if (other.CompareTag(RobotEnemyTag))
        {
            if (attackmode == 1)
            {
                Debug.Log("ロボットを攻撃した！");
                Destroy(other.gameObject);
                audioSource.PlayOneShot(robotHitSE);
            }
            else if (attackmode == 0)
            {
                Debug.Log("ロボットに効果はないようだ…");
            }
        }
    }
}
