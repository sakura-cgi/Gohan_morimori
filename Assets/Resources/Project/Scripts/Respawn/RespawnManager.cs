using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;
    public List<GameObject> respawnables = new List<GameObject>();
    private Vector3 currentCheckpoint;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

     public void Register(GameObject obj)
    {
        if (!respawnables.Contains(obj))
            respawnables.Add(obj);
    }


public void ResetAll()
    {
        foreach (var obj in respawnables)
        {
            if (obj == null) continue;

            obj.SetActive(true);

            // 位置リセット
            var reset = obj.GetComponent<ResetScript>();
            if (reset != null)
            {
                reset.ResetState();
            }
        }
        // プレイヤーをチェックポイントに移動
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = currentCheckpoint;
            player.transform.localScale = Vector3.one;
        }
    }
    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        currentCheckpoint = checkpointPosition;
    }
}
