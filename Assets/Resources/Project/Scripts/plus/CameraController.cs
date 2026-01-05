using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] SceneCameraSetting[] settings;

    SceneCameraSetting current;
    SceneId currentScene;
    Vector3 velocity;

    void LateUpdate()
    {
        var scene = SceneContext.Instance.CurrentScene;
        if (scene != currentScene)
        {
            ApplyScene(scene);
            currentScene = scene;
        }

        if (current == null) return;

        if (current.followPlayer)
            FollowPlayer();
        else
            FixedCamera();
    }

    void ApplyScene(SceneId scene)
    {
        foreach (var s in settings)
        {
            if (s.sceneId == scene)
            {
                current = s;
                velocity = Vector3.zero;
                return;
            }
        }
    }

    void FollowPlayer()
    {
        Vector3 target = player.position;

        target.x = Mathf.Clamp(target.x, current.followMin.x, current.followMax.x);
        target.y = Mathf.Clamp(target.y, current.followMin.y, current.followMax.y);
        target.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            target,
            ref velocity,
            current.transitionTime
        );
    }

    void FixedCamera()
    {
        if (current.fixedPoint == null) return;

        Vector3 target = current.fixedPoint.position;
        target.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            target,
            ref velocity,
            current.transitionTime
        );
    }
}
