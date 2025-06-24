using System.Collections;
using UnityEngine;

public class WashArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private DragWithMouse2D DragWithMouse2D;
    private Love_meter love_Meter;
    private StateManeger _StateManeger;
    private SpriteRenderer _SR;
    [SerializeField] private Sprite bath;


    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nezuking") || other.CompareTag("Nezumi"))
        {
            StateManeger _state = other.GetComponent<StateManeger>();
            if (_state != null && _state._currentstate == StateManeger.IngameState.StayWash)
            {
                StartCoroutine(WashProcess(other.gameObject, _state));
                _state._currentstate = StateManeger.IngameState.Wash;//�X�e�[�^�X��Wash�ɕύX
            }
        }
        /*StateManeger = other.GetComponent<StateManeger>();//other��statemane���擾
        if (StateManeger._currentstate == StateManeger.IngameState.StayWash && other.CompareTag("Nezumi"))
        //�Ԃ������I�u�W�F�N�g�̃X�e�[�^�X��StayWash�ł���A�l�Y�~�̃^�O�̃I�u�W�F�N�g��������
        {
           
            Transform Fukisashi = other.transform.Find("Fukidashi");//other�̎q�I�u�W�F�N�g��Fukidasi���݂���
            _SR = Fukisashi.GetComponent<SpriteRenderer>();
            love_Meter = other.GetComponentInChildren<Love_meter>();//���̃l�Y�~�̃��u���[�^�[�X�N���v�g����������
            Invoke(nameof(CallmethodLove),  5f);//5�b�x�点��B
            Invoke(nameof(WashChangeState), 5f);
            StateManeger._currentstate = StateManeger.IngameState.Wash;//�X�e�[�^�X��Wash�ɕύX

        }*/

    }
    private IEnumerator WashProcess(GameObject target, StateManeger state)
    {
        yield return new WaitForSeconds(5f);//5�b�҂@NEW���ĉ��H

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

        love_Meter = target.GetComponentInChildren<Love_meter>();//���̃l�Y�~�̃��u���[�^�[�X�N���v�g����������
        if (love_Meter != null)
        {
            love_Meter.AddLove(0.2f);
            Debug.Log($"{target.name} �̃��u��2��������I");
        }

        state._currentstate = StateManeger.IngameState.StayBath;//5�b��X�e�[�^�X��StayBath�ɕύX

    }
    void CallmethodLove()
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

    }

}
