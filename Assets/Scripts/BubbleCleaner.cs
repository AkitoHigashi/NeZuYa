using UnityEngine;

public class ShowerCleaner : MonoBehaviour
{
    [SerializeField] private string targetTag = "Shower";
    [SerializeField] private float shrinkSpeed = 0.5f;//縮小速度
    [SerializeField] private float minScale = 0.001f;
    [Header("消滅時に生成する水滴")]
    [SerializeField] GameObject DropToSpawn;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            Vector3 currentScale = transform.localScale;

            // 縮小処理
            float shrinkAmount = shrinkSpeed * Time.deltaTime;
            float newX = Mathf.Max(currentScale.x - shrinkAmount, 0f);
            float newY = Mathf.Max(currentScale.y - shrinkAmount, 0f);

            transform.localScale = new Vector3(newX, newY, currentScale.z);

            if (newX <= minScale && newY <= minScale)
            {
                // 消える前に生成
                if (DropToSpawn != null)
                {
                    Instantiate(DropToSpawn, transform.position, Quaternion.identity);
                }
            // 目で見えなくなったらオブジェクトを削除
                Destroy(gameObject);
                Debug.Log("消えました！！");
            }
           
        }
    }
}

