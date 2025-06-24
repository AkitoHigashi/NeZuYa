using System.Collections;
using UnityEngine;

public class Area_Wash : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private DragWithMouse2D DragWithMouse2D;
    //private Love_meter love_Meter;
    //private StateManeger _StateManeger;
    private SpriteRenderer _SR;
    private BoxCollider2D _boxCol2D;

    [SerializeField] private Sprite bath;
    [SerializeField] private float WashTime = 5f;


    void Start()
    {
        _boxCol2D = GetComponent<BoxCollider2D>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (_boxCol2D != null)
        {
            _boxCol2D.isTrigger = false;//�g���K�[�ƃI�t
            Debug.Log("WashArea����Ȃ���I�I");
        }

        if (other.CompareTag("Nezumi"))
        {
            StateManeger _state = other.GetComponent<StateManeger>();
            if (_state != null && _state._currentstate == StateManeger.IngameState.StayWash)
            {
                StartCoroutine(WashProcess(other.gameObject, _state));
                _state._currentstate = StateManeger.IngameState.Wash;//�X�e�[�^�X��Wash�ɕύX
            }
        }
    }

    private IEnumerator WashProcess(GameObject target, StateManeger state)
    {
        yield return new WaitForSeconds(WashTime);//5�b�҂@NEW���ĉ��H

        Transform fukidashi = target.transform.Find("Fukidashi");
        if (fukidashi != null)
        {
            _SR = fukidashi.GetComponent<SpriteRenderer>();//�����o���̃X�v���C�g���Q�b�g
            if (_SR != null && bath != null)
            {
                _SR.sprite = bath;
                Debug.Log($"{target.name} �̃X�v���C�g��ύX���܂���");
            }
            else
            {
                Debug.LogWarning("bath��������܂���");
            }
        }

        state._currentstate = StateManeger.IngameState.StayBath;//5�b��X�e�[�^�X��StayBath�ɕύX
        _boxCol2D.isTrigger = true;//�g���K�[���I��
        Debug.Log("WashArea�ɓ���܂��I");
    }
    /*void CallmethodLove()
    {
        love_Meter.AddLove(0.2f);//���[�^�[���Q���₷�B
        Debug.Log("2��������");
    }
    void WashChangeState()//�X�e�[�^�X��ύX���A�����o���C���X�g���ϊ�����B
    {
        if (bath != null)//�o�X���w�肳��Ă���Ƃ�
        {
            _SR.sprite = bath;
            Debug.Log("�X�v���C�g��ύX���܂���");
        }
        else
        {
            Debug.LogWarning("bath��������܂���");
        }
        _StateManeger._currentstate = StateManeger.IngameState.StayBath;

    }*/

}
