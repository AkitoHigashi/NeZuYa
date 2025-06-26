using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Love_meter : MonoBehaviour
{
    [SerializeField] private Image healthImage;

    public float duration = 0.5f;

    public float debugAddLoveRate = 0.2f;
    public float currentRate = 0f;
    private void Start()
    {
        SetGauge(0f);//スタート同時にゲージを0にする。
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//デバック用のアドラブ
        {
            AddLove(debugAddLoveRate);
        }
    }

    public void SetGauge(float targetrate)　//ゲージをセットする変数。
    {
        healthImage.DOFillAmount(targetrate, duration);//Dotweenでゲージを上げる。
        
        currentRate = targetrate;
        
    }
    public void AddLove(float rate)
    {
        SetGauge(currentRate + rate);//現在のゲージに足すのを送る。
    }
}
