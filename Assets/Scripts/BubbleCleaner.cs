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

            // �k������
            float shrinkAmount = shrinkSpeed * Time.deltaTime;
            float newX = Mathf.Max(currentScale.x - shrinkAmount, 0f);
            float newY = Mathf.Max(currentScale.y - shrinkAmount, 0f);

            transform.localScale = new Vector3(newX, newY, currentScale.z);

            // ���S��0�ɂȂ�����I�u�W�F�N�g���폜
            if (newX <= 0f && newY <= 0f)
            {
                Destroy(gameObject);
                Debug.Log("�����܂����I�I");
            }
        }
    }
}

