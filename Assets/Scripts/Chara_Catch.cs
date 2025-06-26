using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Chara_Catch : MonoBehaviour
{
    [Header("�ߊl���̊G")]
    [SerializeField] Sprite _HandcuffSP_Ne;
    [SerializeField] Sprite _HandcuffSP_King;
    [SerializeField] Sprite _HandcuffSP_Wo;
    [SerializeField] GameObject Love;
    private Image LoveImage;
    private Love_meter _love_Meter;
    private GameObject _target;
    private SpriteRenderer _SR;
    private bool hasProcessed = false; // ������1�񂾂����s�����悤�ɂ��邽�߂̃t���O
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Handcuffs")&&_love_Meter.currentRate >= 1f)//love��Max�̎�
        {
            GameObject cleanChara = GameObject.FindWithTag("CleanChara");//��ʏ�̃N���[���L�����^�O�̃I�u�W�F�N�g���擾
            if (cleanChara != null)
            {
                Debug.Log("CleanChara ��������: " + cleanChara.name);
                _SR = cleanChara.GetComponentInChildren<SpriteRenderer>();//�X�v���C�g���擾
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
                Debug.LogWarning("Love_meter ��������܂���ł���");
            }
        }
    }
    public void CleanSetLove()
    {
       LoveImage = Love.GetComponent<Image>();
        LoveImage.DOFillAmount(_love_Meter.currentRate,0.5f);
    }
}
