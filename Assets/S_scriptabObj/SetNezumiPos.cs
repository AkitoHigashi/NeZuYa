using UnityEngine;

public class SetNezumiPos : MonoBehaviour
{
    [SerializeField] S GetS;

    private Vector2 Nezumipos;

    private void Start()
    {
        this.transform.position = GetS.EndNezumiPos;
        //�w�肵���I�u�W�F�N�g�̃V�[���̍ŏI�ʒu���L�^�����̃I�u�W�F�W�F�N�g�̈ʒu�ɏ㏑��
    }

    private void OnDisable()
    {
        Nezumipos = this.transform.position;
        GetS.EndNezumiPos = Nezumipos;
        //���̃I�u�W�F�N�g�̈ʒu����ɃX�N���v�^�u���ɑ���B
    }
}
