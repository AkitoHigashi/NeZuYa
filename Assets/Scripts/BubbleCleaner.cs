using UnityEngine;

public class ShowerCleaner : MonoBehaviour
{
    [SerializeField] private string targetTag = "Shower";
    [SerializeField] private float shrinkSpeed = 0.5f;

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

            // 完全に0になったらオブジェクトを削除
            if (newX <= 0f && newY <= 0f)
            {
                Destroy(gameObject);
                Debug.Log("消えました！！");
            }
        }
    }
}

