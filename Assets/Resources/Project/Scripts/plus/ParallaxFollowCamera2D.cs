using UnityEngine;

public class ParallaxFollowCamera2D : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;

    [Range(-1f, 1f)]
    [SerializeField] float parallaxX = 0.5f;

    [Range(-1f, 1f)]
    [SerializeField] float parallaxY = 0.2f;

    Vector3 previousCameraPosition;

    void Start()
    {
        previousCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cameraTransform.position - previousCameraPosition;

        transform.position += new Vector3(
            delta.x * parallaxX,
            delta.y * parallaxY,
            0f
        );

        previousCameraPosition = cameraTransform.position;
    }
}
