using UnityEngine;

public class DragWithMouse2D : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera cam;
    [SerializeField] LayerMask _catch= 0;//���C���[����I���@���̏ꍇ�l�Y�~
    StateManeger StateManeger;


    public bool isLocked = false;

    void Start()
    {
        cam = Camera.main;
        StateManeger = GetComponent<StateManeger>();
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (isLocked == false)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            // �}�E�X���������u��
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D hit = Physics2D.OverlapPoint(mousePos,_catch);
                //�}�E�X�̃|�C���^�[�̈ʒu�ɃR���C�_�[������̂��m�F���A���C���[�����̏ꍇ�l�Y�~�Ȃ�擾
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
                Debug.Log("�h���b�O��");
                transform.position = mousePos + offset;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isLocked = true;
        Invoke(nameof(LockChanged), 5f);
        Debug.Log("���b�N�J�n");
        if (isDragging == true)//�h���b�O�ł���̂��ł��Ȃ��悤�ɂ���B
        {
            isDragging = false;
         Debug.Log("�h���b�O�ł��Ȃ���");
        }
        
        transform.localPosition = collision.transform.localPosition;//�Ԃ������R���C�_�[�̈ʒu�ɋz����B
    }

    private void LockChanged()
    {
        isLocked = false;
        Debug.Log("���b�N����");
    }
}


