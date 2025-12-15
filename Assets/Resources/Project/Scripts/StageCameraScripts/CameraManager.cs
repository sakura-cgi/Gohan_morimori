using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    private const int stageMax = 100;
    private const float cameraWidth = 8.5f, cameraHeight = 4.5f;

    public int nowStage;

    private Vector2[] stageSizes;
    private float edgeRight, edgeLeft, edgeUp, edgeDown;
    private int tmp;

    private GameObject[] rawStages, stages;
    private GameObject chara;
    [SerializeField] private float followOffsetX = 2.5f;

    void Start()
    {
        rawStages = GameObject.FindGameObjectsWithTag("Stage");
        chara = GameObject.Find("Player");

        stages = new GameObject[stageMax];
        stageSizes = new Vector2[stageMax];

        for (int i = 0; i < rawStages.Length; i++)
        {

            tmp = rawStages[i].GetComponent<StageManager>().stageNum;

            if (tmp >= stageMax)
            {
                Debug.Log("Error! Please set stageNum below stageMax!");
                continue;
            }

            stages[tmp] = rawStages[i];
            stageSizes[tmp] = rawStages[i].GetComponent<BoxCollider2D>().size;
        }
    }

    void Update()
    {
        edgeLeft = stages[nowStage].transform.position.x - (stageSizes[nowStage].x / 2) + cameraWidth;
        edgeRight = stages[nowStage].transform.position.x + (stageSizes[nowStage].x / 2) - cameraWidth;
        edgeDown = stages[nowStage].transform.position.y - (stageSizes[nowStage].y / 2) + cameraHeight;
        edgeUp = stages[nowStage].transform.position.y + (stageSizes[nowStage].y / 2) - cameraHeight;

        // カメラの横方向ワープ移動
        if (edgeLeft >= transform.position.x)
        {
            transform.position += (edgeLeft - transform.position.x) * Vector3.right;
        }
        else if (edgeRight <= transform.position.x)
        {
            transform.position += (edgeRight - transform.position.x) * Vector3.right;
        }

        // カメラの縦方向ワープ移動
        if (edgeDown >= transform.position.y)
        {
            transform.position += (edgeDown - transform.position.y) * Vector3.up;
        }
        else if (edgeUp <= transform.position.y)
        {
            transform.position += (edgeUp - transform.position.y) * Vector3.up;
        }

        // カメラのキャラ追従移動
        float camX = transform.position.x;
        float playerX = chara.transform.position.x;

        // プレイヤーが画面右側に行ったら追従
        if (playerX > camX + followOffsetX)
        {
            camX = playerX - followOffsetX;
        }

        // プレイヤーが画面左側に行ったら追従（必要なら）
        else if (playerX < camX - followOffsetX)
        {
            camX = playerX + followOffsetX;
        }

        // ステージ端で制限
        camX = Mathf.Clamp(camX, edgeLeft, edgeRight);

        transform.position = new Vector3(camX, transform.position.y, transform.position.z);
    }
}