using UnityEngine;
using System.Collections.Generic;

public class changer : MonoBehaviour
{
     public SpriteRenderer clothesRenderer;      // 服を表示するSpriteRenderer
    public List<Sprite> clothesSprites;         // Resourcesから読み込んだ服
    private int currentIndex = 0;

    public void WearNext()
    {
        if (clothesSprites == null || clothesSprites.Count == 0) return;

        currentIndex++;
        if (currentIndex >= clothesSprites.Count)
            currentIndex = 0;

        clothesRenderer.sprite = clothesSprites[currentIndex];
    }
}