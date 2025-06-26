using DG.Tweening;
using UnityEngine;

public class Bubble_Spawn : MonoBehaviour
{
    [Header("���ꂪ���邪���ʂ���X�N���v�g")]
     private CleanManeger _CM;
    [Header("��������A�̃v���n�u")]
    [SerializeField] GameObject _bubblePrefab;
    [Header("�����̃X�P�[���ɂ����鎞��")]
    [SerializeField] float scaleDuration = 0.3f; // �g��ɂ����鎞��
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        // �V�[������BodyCleaner�R���|�[�l���g��T���i1�����Ȃ�FindObjectOfType��OK�j
        _CM = FindFirstObjectByType<CleanManeger>();
        if (_CM == null)
        {
            Debug.LogWarning("BodyCleaner���V�[���ɑ��݂��܂���I");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Soap"))
        {
            if (_CM != null && _CM.AllCleanDirt())//_CM�������Ă��ĉ��ꂪ�Ȃ���
            {

                if (_bubblePrefab != null)
                {
                    // �v���n�u�������ȃX�P�[���Ő���
                    GameObject bubble = Instantiate(_bubblePrefab, transform.position, Quaternion.identity);
                    bubble.transform.localScale = Vector3.zero;

                    // DOTween�Ŋg��A�j���[�V���������s
                    bubble.transform.DOScale(Vector3.one, scaleDuration).SetEase(Ease.OutBack);
                }
                else
                {
                    Debug.LogWarning("�v���n�u���ݒ肳��Ă��܂���");
                }

            }
            else
            {
                Debug.Log("�܂����ꂪ�c���Ă���̂ŖA�͏o���܂���I");
            }
        }
;
    }
}
