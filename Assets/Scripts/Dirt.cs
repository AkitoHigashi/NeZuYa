using DG.Tweening;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    [SerializeField]int rubsToDisappear = 10; // 消えるまでのこすり回数
    private int currentRubs = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Brush"))
        {
            currentRubs++;
            AudioManager.Instance.PlaySE("Brush");//音再生
            Debug.Log($"こすられた！今の回数: {currentRubs}");

            // 大きさを少し小さく
            float scaleFactor = Mathf.Lerp(1f, 0f, (float)currentRubs / rubsToDisappear);
            // DOTweenでスケールをアニメーション（0.1秒かけて）
            transform.DOScale(Vector3.one * scaleFactor, 0.1f);
            

            if (currentRubs >= rubsToDisappear)
            {
                Debug.Log("汚れが消えた！");
                Destroy(gameObject);
            }
        }
    }
}
