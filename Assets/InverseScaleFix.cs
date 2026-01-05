using UnityEngine;

public class InverseScaleFix : MonoBehaviour
{
    void LateUpdate()
    {
        if (transform.parent == null) return;

        Vector3 parentScale = transform.parent.lossyScale;

        transform.localScale = new Vector3(
            1f / parentScale.x,
            1f / parentScale.y,
            1f / parentScale.z
        );
    }
}
