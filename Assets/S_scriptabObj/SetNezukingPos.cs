using UnityEngine;

public class SetNezukingPos : MonoBehaviour
{
    [SerializeField] CharaPosition CharaPosition;

    private Vector2 Nezukingpos;

    private void Start()
    {
        this.transform.position = CharaPosition.EndNezukingPos;
        //�w�肵���I�u�W�F�N�g�̃V�[���̍ŏI�ʒu���L�^�����̃I�u�W�F�W�F�N�g�̈ʒu�ɏ㏑��
    }

    public void SavePositionNezuking()
    {
        Nezukingpos = this.transform.position;
        CharaPosition.EndNezukingPos = Nezukingpos;
        //���̃I�u�W�F�N�g�̈ʒu����ɃX�N���v�^�u���ɑ���B
    }
}
