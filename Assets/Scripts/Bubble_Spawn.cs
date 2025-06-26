using DG.Tweening;
using UnityEngine;

public class Bubble_Spawn : MonoBehaviour
{
    [Header("��������A�̃v���n�u")]
    [SerializeField] GameObject _bubblePrefab;
    [Header("�����̃X�P�[���ɂ����鎞��")]
    [SerializeField] float scaleDuration = 0.3f; // �g��ɂ����鎞��
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BBpos"))
        {
            if (_bubblePrefab != null)
            {
                // �v���n�u�������ȃX�P�[���Ő���
                GameObject bubble = Instantiate(_bubblePrefab, other.transform.position, Quaternion.identity);
                bubble.transform.localScale = Vector3.zero;

                // DOTween�Ŋg��A�j���[�V���������s
                bubble.transform.DOScale(Vector3.one, scaleDuration).SetEase(Ease.OutBack);
            }
            else
            {
                Debug.LogWarning("�v���n�u���ݒ肳��Ă��܂���");
            }
        }
;
    }
}
