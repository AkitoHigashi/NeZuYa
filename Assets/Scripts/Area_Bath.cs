using System.Collections;
using UnityEngine;

public class Area_Bath : MonoBehaviour
{
    [Header("�ύX����ۂ�DWM2D��Invoke���Ԃ��ύX����")]
    [SerializeField] private float BathTime = 5f;
    [Header("���|�v���̐����o��")]
    [SerializeField] private Sprite clean;

    private DragWithMouse2D DragWithMouse2D;
    private StateManeger StateManeger;
    private SpriteRenderer _SR;
    private Collider2D _boxCol2D;


    void Start()
    {
        _boxCol2D = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_boxCol2D != null)
        {
            _boxCol2D.isTrigger = false;//�g���K�[�ƃI�t
            Debug.Log("BathArea����Ȃ���I�I");
        }

        if (other.CompareTag("Nezumi"))
        {
            StateManeger _state = other.GetComponent<StateManeger>();
            if (_state != null && _state._currentstate == StateManeger.IngameState.StayBath)
            {
                StartCoroutine(BathProcess(other.gameObject, _state));
                _state._currentstate = StateManeger.IngameState.Bath;//�X�e�[�^�X��bath�ɕύX
            }
        }

    }
    private IEnumerator BathProcess(GameObject target, StateManeger state)
    {
        yield return new WaitForSeconds(BathTime);//�w��b���҂@NEW���ĉ��H
        Transform fukidashi = target.transform.Find("Fukidashi");
        if (fukidashi != null)
        {
            _SR = fukidashi.GetComponent<SpriteRenderer>();//�����o���̃X�v���C�g���Q�b�g
            if (_SR != null && clean != null)
            {
                _SR.sprite = clean;
                Debug.Log($"{target.name} �̃X�v���C�g��ύX���܂���");
            }
            else
            {
                Debug.LogWarning("bath��������܂���");
            }
        }
        state._currentstate = StateManeger.IngameState.StayClean;//5�b��X�e�[�^�X��StayClean�ɕύX
        _boxCol2D.isTrigger = true;//�g���K�[���I��
        Debug.Log("BathArea�ɓ���܂��I");


    }
}
