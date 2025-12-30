using UnityEngine;

public class clothesChanger : MonoBehaviour
{
    public SpriteRenderer clothesRenderer;

    // clothSprites[motion][cloth][frame]
    public Sprite[][][] clothSprites;

    // AnimatorのMotion
    private string[] motions = { "idle", "walk", "dash", "FireAttack", "IceAttack" };

    private Animator animator;

    public int currentClothes = 0;
    [SerializeField] private TempManager tempManager;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        int clothesCount = 5;
        int motionCount = motions.Length;

        clothSprites = new Sprite[motionCount][][];

        for (int m = 0; m < motionCount; m++)
        {
            clothSprites[m] = new Sprite[clothesCount][];

            for (int c = 0; c < clothesCount; c++)
            {
                // 例：Resources/Clothes/0_idle
                string path = $"Clothes/{c}_{motions[m]}";

                Sprite[] frames = Resources.LoadAll<Sprite>(path);

                if (frames.Length == 0)
                {
                    Debug.LogWarning($"⚠ 何も読み込めなかった: {path}");
                }

                clothSprites[m][c] = frames;
            }
        }

        Debug.Log("ロード完了！");
    }

    void Update()
    {
        var info = animator.GetCurrentAnimatorStateInfo(0);
        int motion = animator.GetInteger("Motion");

        var frames = clothSprites[motion][currentClothes];

        int frame = (int)(info.normalizedTime * frames.Length) % frames.Length;

        clothesRenderer.sprite = frames[frame];
    }

    public void Wear()
    {
        if (currentClothes >= 4) return;
        currentClothes += 1;
        tempManager.basic_temp += 3;
    }
    public void Undress()
    {
        if (currentClothes <= 0) return;
        currentClothes -= 1;
        tempManager.basic_temp -= 3;
    }

}