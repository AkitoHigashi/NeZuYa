using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Love_meter : MonoBehaviour
{
    [SerializeField] private Image healthImage;

    public float duration = 0.5f;

    public float debugAddLoveRate = 0.2f;
    public float currentRate = 0f;

    public void SetGauge(float targetrate)�@//�Q�[�W���Z�b�g����ϐ��B
    {
        healthImage.DOFillAmount(targetrate, duration);//Dotween�ŃQ�[�W���グ��B
        
        currentRate = targetrate;
        
    }
    public void AddLove(float rate)
    {
        SetGauge(currentRate + rate);//���݂̃Q�[�W�ɑ����̂𑗂�B
    }
    private void Start()
    {
        SetGauge(0f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddLove(debugAddLoveRate);
        }
    }
}
