using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public static SceneContext Instance;

    public SceneId CurrentScene { get; private set; }

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

    public void SetScene(SceneId id)
    {
        CurrentScene = id;
        Debug.Log($"Scene Changed: {id}");
    }
}
