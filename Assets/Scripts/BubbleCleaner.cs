using UnityEngine;

public class ShowerCleaner : MonoBehaviour
{
    [SerializeField] private string targetTag = "Shower";
    [SerializeField] private float shrinkSpeed = 0.5f;//縮小速度
    //[SerializeField] private float minScale = 0.001f;
    [Header("縮小開始時に生成する水滴")]
    [SerializeField] GameObject DropToSpawn;

    private bool hasSpawned = false;//一度だけ生成するためのフラグ
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            if (!hasSpawned && DropToSpawn != null)
            {
                Instantiate(DropToSpawn, transform.position, Quaternion.identity);
                hasSpawned = true;
                Debug.Log("生成しました！");
            }

            Vector3 currentScale = transform.localScale;

            // 縮小処理
            float shrinkAmount = shrinkSpeed * Time.deltaTime;
            float newX = Mathf.Max(currentScale.x - shrinkAmount, 0f);
            float newY = Mathf.Max(currentScale.y - shrinkAmount, 0f);

            transform.localScale = new Vector3(newX, newY, currentScale.z);

            if (newX <= 0f && newY <= 0f)
            {

                // 0になったらオブジェクトを削除
                Destroy(gameObject);
                Debug.Log("消えました！！");
            }
        }


    }
}

