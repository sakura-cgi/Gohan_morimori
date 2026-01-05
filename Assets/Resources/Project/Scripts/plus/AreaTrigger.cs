using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    [SerializeField] SceneId targetScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        SceneContext.Instance.SetScene(targetScene);
    }
}
