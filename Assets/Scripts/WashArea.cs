using Unity.VisualScripting;
using UnityEngine;

public class WashArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private DragWithMouse2D DragWithMouse2D;
    private Love_meter love_Meter;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nezumi"))//�l�Y�~�̃^�O�̃I�u�W�F�N�g��������
        {
            love_Meter = other.GetComponentInChildren<Love_meter>();//���̃l�Y�~�̃��u���[�^�[�X�N���v�g����������
            Invoke(nameof(CallmethodLove), 5f);//5�b�x�点��B

        }

    }
    void CallmethodLove()
    {
        love_Meter.AddLove(0.2f);//���[�^�[���Q���₷�B
        Debug.Log("2��������");
    }


}
