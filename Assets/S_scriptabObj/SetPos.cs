using UnityEngine;

public class SetPos : MonoBehaviour
{
    [SerializeField] S GetS;

    private Vector2 pos;

    private void Start()
    {
        this.transform.position = GetS.EndPlaypos;
        //�w�肵���I�u�W�F�N�g�̃V�[���̍ŏI�ʒu���L�^�����̃I�u�W�F�W�F�N�g�̈ʒu�ɏ㏑��
    }
    private void Update()
    {
        pos = this.transform.position;
        GetS.EndPlaypos = pos;
        //���̃I�u�W�F�N�g�̈ʒu����ɃX�N���v�^�u���ɑ���B
    }

}
