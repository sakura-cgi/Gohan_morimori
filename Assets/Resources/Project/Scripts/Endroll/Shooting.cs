using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;  // 弾のPrefab
    [SerializeField] private float bulletSpeed = 10f;  // 弾の速度
    [SerializeField] private Transform firePoint;      // 発射位置

    public float moveSpeed = 5f;

    public bool ismoving;
    public int DisplayNum = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ismoving) // 左クリック

        {
            Shoot();
        }
        float vertical = 0f;
        if (Input.GetKey(KeyCode.W)) vertical = 1f;
        else if (Input.GetKey(KeyCode.S)) vertical = -1f;

        Vector3 move = new Vector3(0, vertical * moveSpeed * Time.deltaTime, 0);
        transform.position += move;
    }

    private void Shoot()
    {
        // 弾を生成
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Rigidbody2Dがあれば速度を設定
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.right * bulletSpeed; // 右方向に飛ばす
        }
    }
}
