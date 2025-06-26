using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Clean_Finish : MonoBehaviour
{
    [Header("���C���̃J����")]
    [SerializeField] GameObject _MainCamera;
    [Header("���|�̃J����")]
    [SerializeField] GameObject _CleanCamera;
    [Header("���|�p�[�g�̃X���C�hUI")]
    [SerializeField] GameObject _CleanUI;
    [Header("���|�p�[�g�̊���UI")]
    [SerializeField] GameObject _CleanFinishUI;
    [Header("�ޓX���̐����o��")]
    [SerializeField] private Sprite retun;

    [Header("�L���������̃X�N���v�g")]
    [SerializeField] private Generator_chara _GC;
    [SerializeField] private CleanManeger CleanManeger;
    private GameObject _target;
    private Love_meter love_Meter;
    private SpriteRenderer _SR;


    //[Header("�`�F���W�̃f�B���C�̎���")]
    //[SerializeField] private float delaytime = 3f;


    public void GoInGame()
    {
        if (CleanManeger != null)
        {
            if (CleanManeger.AllCleanWater() && CleanManeger.AllCleanBubble() && CleanManeger.AllCleanDirt())
            {
                _MainCamera.SetActive(true);
                _CleanCamera.SetActive(false);
                _CleanUI.SetActive(false);
                _CleanFinishUI.SetActive(false);
                StartCoroutine(Change(_target.gameObject));//2
                StartCoroutine(ReturnMove(_target.gameObject));//2
               
            }
            else
            {
                Debug.Log("�g�̂̉��ꂪ���ꂢ�ɂȂ��Ă��܂���");
            }
        }
        else
        {
            Debug.Log("CleanManeger���擾�ł��܂���");
        }
    }
    public void SetTarget(GameObject target)
    {
        _target = target;//CleanArea�ɓ������I�u�W�F�N�g���擾�B
    }
    private IEnumerator Change(GameObject _target)
    {
        yield return new WaitForSeconds(2f);
        StateManeger _state = _target.GetComponent<StateManeger>();
        Transform fukidashi = _target.transform.Find("Fukidashi");
        if (fukidashi != null)
        {
            _SR = fukidashi.GetComponent<SpriteRenderer>();//�����o���̃X�v���C�g���Q�b�g
            if (_SR != null && retun != null)
            {
                _SR.sprite = retun;
                Debug.Log($"{_target.name} �̃X�v���C�g��ύX���܂���");
            }
            else
            {
                Debug.LogWarning("retun��������܂���");
            }
            love_Meter = _target.GetComponentInChildren<Love_meter>();//���̃l�Y�~�̃��u���[�^�[�X�N���v�g����������
            if (love_Meter != null)
            {
                love_Meter.AddLove(0.2f);
                Debug.Log($"{_target.name} �̃��u��2��������I");
            }
            _state._currentstate = StateManeger.IngameState.Return;

        }
    }
    private IEnumerator ReturnMove(GameObject _target)
    {
        yield return new WaitForSeconds(2f);
        _target.transform.DOMove(new Vector3(-12f, -3f, 0f), 3f)//�L�������ړ�����B5�b
                         .SetEase(Ease.InQuad)
                         .OnComplete(() =>
                         {
                             Destroy(_target.gameObject);//�ړ����폜
                             Debug.Log($"{_target.name}���ޓX���܂����B");
                             _GC.SpawnRandomCharacter();
                             _GC.RemoveSpawnedCharacter(_target.gameObject.tag);
                         });


}
}


