using UnityEngine;

public class LockCursor : MonoBehaviour
{
    void Start()
    {
        // �J�[�\�������b�N����
        Cursor.lockState = CursorLockMode.Confined;

        // �J�[�\����\������i��\���ɂ������ꍇ�� false�j
        Cursor.visible = true;
    }
}
