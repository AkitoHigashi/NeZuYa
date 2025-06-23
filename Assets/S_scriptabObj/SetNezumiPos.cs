using UnityEngine;

public class SetNezumiPos : MonoBehaviour
{
    [SerializeField] CharaPosition _PositoinDate;

    private Vector2 Nezumipos;

    private void Start()
    {
        if (_PositoinDate.hasSavedPosition == true)//�|�W�V�������L�^����Ă���Ύ��s
        {
        this.transform.position = _PositoinDate.EndNezumiPos;
        //�w�肵���I�u�W�F�N�g�̃V�[���̍ŏI�ʒu���L�^�����̃I�u�W�F�W�F�N�g�̈ʒu�ɏ㏑��
        }
    }

    private void OnDisable()
    {
        Nezumipos = this.transform.position;
        _PositoinDate.EndNezumiPos = Nezumipos;
        _PositoinDate.hasSavedPosition = true;//�|�W�V�������Z�[�u���������L�^
        //���̃I�u�W�F�N�g�̍ŏI�ʒu����ɃX�N���v�^�u���ɑ���B
    }
}
