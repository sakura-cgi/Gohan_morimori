
using UnityEngine;

[System.Serializable]
public class SceneCameraSetting
{
    public SceneId sceneId;

    public bool followPlayer;

    [Header("Follow Settings")]
    public Vector2 followMin;
    public Vector2 followMax;

    [Header("Fixed Camera")]
    public Transform fixedPoint;

    [Header("Transition")]
    public float transitionTime;
}
