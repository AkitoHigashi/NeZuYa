using UnityEngine;
using UnityEngine.XR;

public class Area_Bath : MonoBehaviour
{
    private DragWithMouse2D DragWithMouse2D;
    private StateManeger StateManeger;
    private SpriteRenderer _SR;
    [SerializeField] private Sprite clean;


    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        StateManeger = other.GetComponent<StateManeger>();//other��statemane���擾
        if (StateManeger._currentstate == StateManeger.IngameState.StayBath && other.CompareTag("Nezumi"))
        //�Ԃ������I�u�W�F�N�g�̃X�e�[�^�X��StayWash�ł���A�l�Y�~�̃^�O�̃I�u�W�F�N�g��������
        {

            Transform Fukisashi = other.transform.Find("Fukidashi");//other�̎q�I�u�W�F�N�g��Fukidasi���݂���
            _SR = Fukisashi.GetComponent<SpriteRenderer>();//�����o���̃X�v���C�g���Q�b�g


            Invoke(nameof(WashChangeState), 5f);//5�b�x�点��
            StateManeger._currentstate = StateManeger.IngameState.Bath;//�X�e�[�^�X��Bath�ɕύX

        }

    }
    void WashChangeState()//�X�e�[�^�X��ύX���A�����o���C���X�g���ϊ�����B
    {
        if (clean != null)//�o�X���w�肳��Ă���Ƃ�
        {
            _SR.sprite = clean;
            Debug.Log("�X�v���C�g��ύX���܂���");
        }
        else
        {
            Debug.LogWarning("clean��������܂���");
        }
        StateManeger._currentstate = StateManeger.IngameState.StayClean;

    }
}
