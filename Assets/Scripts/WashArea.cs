using Unity.VisualScripting;
using UnityEngine;

public class WashArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private DragWithMouse2D DragWithMouse2D;
    private Love_meter love_Meter;
    private StateManeger StateManeger;
    private SpriteRenderer _SR;
    [SerializeField] private Sprite bath;


    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        StateManeger = other.GetComponent<StateManeger>();//other��statemane���擾
        if (StateManeger._currentstate == StateManeger.IngameState.StayWash && other.CompareTag("Nezumi"))
        //�Ԃ������I�u�W�F�N�g�̃X�e�[�^�X��StayWash�ł���A�l�Y�~�̃^�O�̃I�u�W�F�N�g��������
        {
            Transform Fukisashi = other.transform.Find("Fukidasi");//other�̎q�I�u�W�F�N�g��Fukidasi���݂���
            _SR = Fukisashi.GetComponent<SpriteRenderer>();//�����o���̃X�v���C�g���Q�b�g
            love_Meter = other.GetComponentInChildren<Love_meter>();//���̃l�Y�~�̃��u���[�^�[�X�N���v�g����������
            Invoke(nameof(CallmethodLove), 5f);//5�b�x�点��B
            Invoke(nameof(WashChangeState), 5f);

        }

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
            StateManeger._currentstate = StateManeger.IngameState.StayBath;

    }

}
