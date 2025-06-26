using DG.Tweening;
using UnityEngine;

public class Bubble_Spawn : MonoBehaviour
{
    [Header("生成する泡のプレハブ")]
    [SerializeField] GameObject _bubblePrefab;
    [Header("生成のスケールにかける時間")]
    [SerializeField] float scaleDuration = 0.3f; // 拡大にかける時間
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BBpos"))
        {
            if (_bubblePrefab != null)
            {
                // プレハブを小さなスケールで生成
                GameObject bubble = Instantiate(_bubblePrefab, other.transform.position, Quaternion.identity);
                bubble.transform.localScale = Vector3.zero;

                // DOTweenで拡大アニメーションを実行
                bubble.transform.DOScale(Vector3.one, scaleDuration).SetEase(Ease.OutBack);
            }
            else
            {
                Debug.LogWarning("プレハブが設定されていません");
            }
        }
;
    }
}
