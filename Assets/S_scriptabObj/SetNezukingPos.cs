using UnityEngine;

public class SetNezukingPos : MonoBehaviour
{
    [SerializeField] S GetS;

    private Vector2 Nezukingpos;

    private void Start()
    {
        this.transform.position = GetS.EndNezukingPos;
        //�w�肵���I�u�W�F�N�g�̃V�[���̍ŏI�ʒu���L�^�����̃I�u�W�F�W�F�N�g�̈ʒu�ɏ㏑��
    }

    private void OnDisable()
    {
        Nezukingpos = this.transform.position;
        GetS.EndNezukingPos = Nezukingpos;
        //���̃I�u�W�F�N�g�̈ʒu����ɃX�N���v�^�u���ɑ���B
    }
}
