using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Player Status")]
    public int temp = 35;
    public int basic_temp = 35;
    public int life = 20;
    public int clothes = 0;

    [Header("Checkpoint")]
    public Vector3 checkpointPosition;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
