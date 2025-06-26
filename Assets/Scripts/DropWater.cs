using UnityEngine;

public class DropWater : MonoBehaviour
{
    [Header("消えるまでの拭き回数")]
    [SerializeField] int rubsToDisappear = 10; // 消えるまでの拭き回数
    private int currentRubs = 0;

    private SpriteRenderer _SR;
    private CleanManeger _CleanManeger;


    private void Awake()
    {
        // シーン内のBodyCleanerコンポーネントを探す（1つだけならFindObjectOfTypeでOK）
        _CleanManeger = FindFirstObjectByType<CleanManeger>();
        if (_CleanManeger == null)
        {
            Debug.LogWarning("BodyCleanerがシーンに存在しません！");
        }

        _SR = GetComponent<SpriteRenderer>();
        if (_SR == null)
        {
            Debug.LogError("SpriteRenderer が見つかりません！");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Towel"))
        {
            if (_CleanManeger != null && _CleanManeger.AllCleanBubble())
            {
                currentRubs++;
                Debug.Log($"拭かれた！今の回数: {currentRubs}");

                // アルファ値下げる。
                float alpha = Mathf.Lerp(1f, 0f, (float)currentRubs / rubsToDisappear);
                Color newColor = _SR.color;
                newColor.a = alpha;
                _SR.color = newColor;

                if (currentRubs >= rubsToDisappear)
                {
                    Debug.Log("水滴が消えた！");
                    Destroy(gameObject);
                }

            }
        }
    }
}
