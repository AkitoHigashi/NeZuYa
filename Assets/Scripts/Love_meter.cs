using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Love_meter : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private LoveChara _loveChara;
    

    public float duration = 0.5f;

    public float debugAddLoveRate = 0.2f;
    public float currentRate = 0f;
    private void Start()
    {
       currentRate = Mathf.Clamp01(_loveChara.savedLoveRate); // 復元
        SetGauge(currentRate);//スタート同時にゲージを今のゲージにする。
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//デバック用のアドラブ
        {
            AddLove(debugAddLoveRate);
        }
    }

    public void SetGauge(float targetrate) // ゲージをセットする関数。
    {
        healthImage.DOFillAmount(targetrate, duration);//Dotweenでゲージを上げる。

        currentRate = targetrate;

        // 状態を保存
        _loveChara.savedLoveRate = currentRate;
    }
    public void AddLove(float rate)
    {
        float newRate = Mathf.Min(currentRate + rate, 1f);//1以上にならない
        SetGauge(newRate);//現在のゲージに足すのを送る。
    }
}
