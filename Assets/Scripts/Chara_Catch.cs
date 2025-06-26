using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Chara_Catch : MonoBehaviour
{
    [Header("捕獲時の絵")]
    [SerializeField] Sprite _HandcuffSP_Ne;
    [SerializeField] Sprite _HandcuffSP_King;
    [SerializeField] Sprite _HandcuffSP_Wo;
    [SerializeField] GameObject Love;
    private Image LoveImage;
    private Love_meter _love_Meter;
    private GameObject _target;
    private SpriteRenderer _SR;
    private bool hasProcessed = false; // 処理が1回だけ実行されるようにするためのフラグ
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Handcuffs")&&_love_Meter.currentRate >= 1f)//loveがMaxの時
        {
            GameObject cleanChara = GameObject.FindWithTag("CleanChara");//画面上のクリーンキャラタグのオブジェクトを取得
            if (cleanChara != null)
            {
                Debug.Log("CleanChara を見つけた: " + cleanChara.name);
                _SR = cleanChara.GetComponentInChildren<SpriteRenderer>();//スプライトを取得
                if (_target.CompareTag("Nezumi"))
                {
                    _SR.sprite = _HandcuffSP_Ne;
                }
                else if (_target.CompareTag("Nezuking"))
                {
                    _SR.sprite = _HandcuffSP_King;
                }
                else if(_target.CompareTag("Women"))
                {
                    _SR.sprite = _HandcuffSP_Wo;
                }
                AudioManager.Instance.PlaySE("Catch");
            }

        }
    }

    public void Chara_Catch_SetTarget(GameObject target)
    {
        _target = target;
        if (_target != null)
        {
            _love_Meter = _target.GetComponentInChildren<Love_meter>();

            if (_love_Meter == null)
            {
                Debug.LogWarning("Love_meter が見つかりませんでした");
            }
        }
    }
    public void CleanSetLove()
    {
       LoveImage = Love.GetComponent<Image>();
        LoveImage.DOFillAmount(_love_Meter.currentRate,0.5f);
    }
}
