using System.Collections;
using UnityEngine;

public class Area_Clean : MonoBehaviour
{
    [Header("���C���̃J����")]
    [SerializeField] GameObject _MainCamera;
    [Header("���|�̃J����")]
    [SerializeField] GameObject _CleanCamera;
    [Header("���|�p�[�g�̃X���C�hUI")]
    [SerializeField] GameObject _CleanUI;
    [Header("���|�p�[�g�̊���UI")]
    [SerializeField] GameObject _CleanFinishUI;

    [Header("�`�F���W�̃f�B���C�̎���")]
    [SerializeField] private float delaytime = 3f;
    [Header("�ޓX���̐����o��")]
    [SerializeField] private Sprite retun;

    private SpriteRenderer _SR;
    private Love_meter love_Meter;
    private Collider2D _boxCol2D;
    [SerializeField] private Clean_Finish _clean_Finish;



    private void Start()
    {
        _boxCol2D = GetComponent<Collider2D>();
        _CleanCamera.SetActive(false);
        _CleanUI.SetActive(false);
        _CleanFinishUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nezumi") || other.CompareTag("Nezuking") || other.CompareTag("Women"))
        {
            StateManeger _state = other.GetComponent<StateManeger>();
            if (_state != null && _state._currentstate == StateManeger.IngameState.StayClean)
            {
                if (_boxCol2D != null)
                {
                    _boxCol2D.isTrigger = false;//�g���K�[�ƃI�t
                    Debug.Log("CleanArea����Ȃ���I�I");
                }
                _clean_Finish.SetTarget(other.gameObject);
                Invoke(nameof(GoClean), delaytime);

            }

        }
    }

    private IEnumerator CleanProcess(GameObject target, StateManeger state)
    {
        yield return new WaitForSeconds(0f);

        Transform fukidashi = target.transform.Find("Fukidashi");
        if (fukidashi != null)
        {
            _SR = fukidashi.GetComponent<SpriteRenderer>();//�����o���̃X�v���C�g���Q�b�g
            if (_SR != null && retun != null)
            {
                _SR.sprite = retun;
                Debug.Log($"{target.name} �̃X�v���C�g��ύX���܂���");
            }
            else
            {
                Debug.LogWarning("retun��������܂���");
            }
        }

        love_Meter = target.GetComponentInChildren<Love_meter>();//���̃l�Y�~�̃��u���[�^�[�X�N���v�g����������
        if (love_Meter != null)
        {
            love_Meter.AddLove(0.2f);
            Debug.Log($"{target.name} �̃��u��2��������I");
        }
        state._currentstate = StateManeger.IngameState.Return;//5�b��X�e�[�^�X��StayBath�ɕύX
        _boxCol2D.isTrigger = true;

    }
    public void EndCleaning(GameObject target)
    {
        StateManeger state = target.GetComponent<StateManeger>();
        if (state != null)
        {
            StartCoroutine(CleanProcess(target, state));
        }
    }
    void GoClean()
    {
        _MainCamera.SetActive(false);
        _CleanCamera.SetActive(true);
        _CleanUI.SetActive(true);
        _CleanFinishUI.SetActive(true);
        _boxCol2D.isTrigger = true;//�g���K�[���I��
        Debug.Log("BathArea�ɓ���܂��I");
    }

}
