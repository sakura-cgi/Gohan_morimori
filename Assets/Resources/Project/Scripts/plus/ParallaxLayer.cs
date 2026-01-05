using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [Range(0f, 1f)]
    public float parallaxStrength = 0.5f;

    [Range(0.1f, 3f)]
    public float transitionMultiplier = 1f;

    Transform cam;
    Vector3 lastCamPos;

    void Start()
    {
        cam = Camera.main.transform;
        lastCamPos = cam.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cam.position - lastCamPos;

        Vector3 move = new Vector3(
            delta.x * parallaxStrength,
            delta.y * parallaxStrength,
            0f
        );

        transform.position += move * transitionMultiplier;
        lastCamPos = cam.position;
    }
}
