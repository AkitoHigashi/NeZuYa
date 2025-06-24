using UnityEngine;

public class ShowerCleaner : MonoBehaviour
{
    [SerializeField] private string targetTag = "Shower";
    [SerializeField] private float shrinkSpeed = 0.5f;//�k�����x
    [SerializeField] private float minScale = 0.001f;
    [Header("���Ŏ��ɐ������鐅�H")]
    [SerializeField] GameObject DropToSpawn;

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

            if (newX <= minScale && newY <= minScale)
            {
                // ������O�ɐ���
                if (DropToSpawn != null)
                {
                    Instantiate(DropToSpawn, transform.position, Quaternion.identity);
                }
            // �ڂŌ����Ȃ��Ȃ�����I�u�W�F�N�g���폜
                Destroy(gameObject);
                Debug.Log("�����܂����I�I");
            }
           
        }
    }
}

