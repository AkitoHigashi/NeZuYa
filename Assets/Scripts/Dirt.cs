using UnityEngine;

public class Dirt : MonoBehaviour
{
    [SerializeField]int rubsToDisappear = 10; // ������܂ł̂������
    private int currentRubs = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Towel"))
        {
            currentRubs++;
            Debug.Log($"������ꂽ�I���̉�: {currentRubs}");

            // �傫��������������
            float scaleFactor = Mathf.Lerp(1f, 0f, (float)currentRubs / rubsToDisappear);
            transform.localScale = Vector3.one * scaleFactor;

            if (currentRubs >= rubsToDisappear)
            {
                Debug.Log("���ꂪ�������I");
                Destroy(gameObject);
            }
        }
    }
}
