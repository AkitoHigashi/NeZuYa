using UnityEngine;

public class DropWater : MonoBehaviour
{
    [Header("������܂ł̐@����")]
    [SerializeField] int rubsToDisappear = 10; // ������܂ł̐@����
    private int currentRubs = 0;

    private SpriteRenderer _SR;


    private void Awake()
    {
        _SR = GetComponent<SpriteRenderer>();
        if (_SR == null)
        {
            Debug.LogError("SpriteRenderer ��������܂���I");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Towel"))
        {
            currentRubs++;
            Debug.Log($"�@���ꂽ�I���̉�: {currentRubs}");

            // �A���t�@�l������B
            float alpha = Mathf.Lerp(1f, 0f, (float)currentRubs / rubsToDisappear);
            Color newColor = _SR.color;
            newColor.a = alpha;
            _SR.color = newColor;

            if (currentRubs >= rubsToDisappear)
            {
                Debug.Log("���H���������I");
                Destroy(gameObject);
            }
        }
    }
}
