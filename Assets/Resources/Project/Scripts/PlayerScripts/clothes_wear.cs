using UnityEngine;

public class PlayerClothes : MonoBehaviour
{
    [SerializeField] SpriteRenderer clothesRenderer;

    private bool isWearing = false;

    public void ToggleClothes()
    {
        isWearing = !isWearing;
        clothesRenderer.enabled = isWearing;
    }
}