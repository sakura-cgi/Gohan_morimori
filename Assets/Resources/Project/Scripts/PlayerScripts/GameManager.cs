using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Player Status")]
    public int temp = 35;
    public int basic_temp = 35;
    public int life = 20;
    public int clothes = 0;
    private static bool initialized = false;
    public int def_temp;
   private int def_basic_temp;
    private int def_life;
    private int def_clothes;

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
        if (!initialized)
        {
            def_temp = temp;
            def_basic_temp = basic_temp;
            def_life = life;
            def_clothes = clothes;

            initialized = true;
        }


    }

    public void ResetAll()
    {
        Debug.Log("Reseting...");
        temp = def_temp;
        basic_temp = def_basic_temp;
        life = def_life;
        clothes = def_clothes;
    }
}
