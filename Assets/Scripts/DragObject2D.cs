using UnityEngine;

public class DragWithMouse2D : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // �}�E�X���������u��
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = Physics2D.OverlapPoint(mousePos);//�}�E�X�̃|�C���^�[�̈ʒu�ɃR���C�_�[������̂��m�F
            if (hit != null && hit.gameObject == this.gameObject)//�R���C�_�[����������A���̃I�u�W�F�N�g�����̃I�u�W�F�N�g��������
            {
                isDragging = true;
                offset = transform.position - mousePos;
                //�R���C�_�[�ƃ}�E�X�|�C���^�[�̋������擾���A�|�C���^�[�ɋz��ꂸ���̂܂܃I�u�W�F�N�g���ړ��ł���悤�ɂ���
            }
        }

        // �}�E�X�𗣂����u��
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // �h���b�O���̓���
        if (isDragging)
        {
            transform.position = mousePos + offset;
        }
    }
}
