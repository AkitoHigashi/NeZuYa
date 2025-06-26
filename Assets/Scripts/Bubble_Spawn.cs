using DG.Tweening;
using UnityEngine;

public class Bubble_Spawn : MonoBehaviour
{
    [Header("汚れがあるが判別するスクリプト")]
     private CleanManeger _CM;
    [Header("生成する泡のプレハブ")]
    [SerializeField] GameObject _bubblePrefab;
    [Header("生成のスケールにかける時間")]
    [SerializeField] float scaleDuration = 0.3f; // 拡大にかける時間
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        // シーン内のBodyCleanerコンポーネントを探す（1つだけならFindObjectOfTypeでOK）
        _CM = FindFirstObjectByType<CleanManeger>();
        if (_CM == null)
        {
            Debug.LogWarning("BodyCleanerがシーンに存在しません！");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Soap"))
        {
            if (_CM != null && _CM.AllCleanDirt())//_CMが入っていて汚れがない時
            {

                if (_bubblePrefab != null)
                {
                    // プレハブを小さなスケールで生成
                    GameObject bubble = Instantiate(_bubblePrefab, transform.position, Quaternion.identity);
                    bubble.transform.localScale = Vector3.zero;

                    // DOTweenで拡大アニメーションを実行
                    bubble.transform.DOScale(Vector3.one, scaleDuration).SetEase(Ease.OutBack);
                }
                else
                {
                    Debug.LogWarning("プレハブが設定されていません");
                }

            }
            else
            {
                Debug.Log("まだ汚れが残っているので泡は出せません！");
            }
        }
;
    }
}
