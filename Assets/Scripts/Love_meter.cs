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
       currentRate = Mathf.Clamp01(_loveChara.savedLoveRate); // ����
        SetGauge(currentRate);//�X�^�[�g�����ɃQ�[�W�����̃Q�[�W�ɂ���B
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//�f�o�b�N�p�̃A�h���u
        {
            AddLove(debugAddLoveRate);
        }
    }

    public void SetGauge(float targetrate) // �Q�[�W���Z�b�g����֐��B
    {
        healthImage.DOFillAmount(targetrate, duration);//Dotween�ŃQ�[�W���グ��B

        currentRate = targetrate;

        // ��Ԃ�ۑ�
        _loveChara.savedLoveRate = currentRate;
    }
    public void AddLove(float rate)
    {
        float newRate = Mathf.Min(currentRate + rate, 1f);//1�ȏ�ɂȂ�Ȃ�
        SetGauge(newRate);//���݂̃Q�[�W�ɑ����̂𑗂�B
    }
}
