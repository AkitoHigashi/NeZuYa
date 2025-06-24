using UnityEngine;

public class ShowerCleaner : MonoBehaviour
{
    [SerializeField] private string targetTag = "Shower";
    [SerializeField] private float shrinkSpeed = 0.5f;//�k�����x
    //[SerializeField] private float minScale = 0.001f;
    [Header("�k���J�n���ɐ������鐅�H")]
    [SerializeField] GameObject DropToSpawn;

    private bool hasSpawned = false;//��x�����������邽�߂̃t���O
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            if (!hasSpawned && DropToSpawn != null)
            {
                Instantiate(DropToSpawn, transform.position, Quaternion.identity);
                hasSpawned = true;
                Debug.Log("�������܂����I");
            }

            Vector3 currentScale = transform.localScale;

            // �k������
            float shrinkAmount = shrinkSpeed * Time.deltaTime;
            float newX = Mathf.Max(currentScale.x - shrinkAmount, 0f);
            float newY = Mathf.Max(currentScale.y - shrinkAmount, 0f);

            transform.localScale = new Vector3(newX, newY, currentScale.z);

            if (newX <= 0f && newY <= 0f)
            {

                // 0�ɂȂ�����I�u�W�F�N�g���폜
                Destroy(gameObject);
                Debug.Log("�����܂����I�I");
            }
        }


    }
}

