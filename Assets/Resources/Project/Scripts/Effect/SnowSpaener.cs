using UnityEngine;

public class SnowSpaener : MonoBehaviour
{
    [SerializeField] private GameObject snowEffectPrefab;
    private float spawnInterval = 0.5f;
    private Vector3 Snow;
    Camera cam;
    public Sprite[] snowSprites = new Sprite[3];


    void Start()
    {
        InvokeRepeating(nameof(SpawnSnow), 0f, spawnInterval);
        cam = Camera.main;
    }

    void SpawnSnow()
    {
        float camHeight = cam.orthographicSize * 2f;
        float camWidth = camHeight * cam.aspect;

        float x = Random.Range(
            cam.transform.position.x - camWidth / 2f,
            cam.transform.position.x + camWidth / 2f
        );

        float y = cam.transform.position.y + camHeight / 2f + 1f;

        Snow = new Vector3(x, y, 0f);
        GameObject snowEffect = Instantiate(snowEffectPrefab, Snow, Quaternion.identity);
        snowEffect.GetComponent<SpriteRenderer>().sprite = snowSprites[Random.Range(0, snowSprites.Length)];
    }
}
