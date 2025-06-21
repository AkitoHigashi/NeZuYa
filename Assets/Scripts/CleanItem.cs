using UnityEngine;

public class CleanItem : MonoBehaviour
{

    private bool isDragging = false;
    private Vector3 offset;
    private Camera cam;
    [SerializeField] LayerMask _item = 0;
    private bool isStop = false;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ItemMove();
    }
    void ItemMove()
    {
        if (!isStop)//�X�g�b�v���Ă��Ȃ��Ƃ��i�������鎞�j
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0)) //���N���b�N�����Ƃ�
            {
                Collider2D hit = Physics2D.OverlapPoint(mousePos, _item);//�}�E�X�̃|�C���g�ɂ���R���C�_�[���擾�B
                if (hit != null && hit.gameObject == this.gameObject)
                {
                    isDragging = true;
                    offset = this.transform.position - mousePos;
                }


            }
            if (Input.GetMouseButtonUp(0))//���N���b�N��������
            {
                isDragging = false;
            }
            if (isDragging)
            {
                transform.position = mousePos + offset;
                //Debug.Log("�A�C�e���h���b�O��");
            }
        }
    }
}
