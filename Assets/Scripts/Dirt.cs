using DG.Tweening;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    [SerializeField]int rubsToDisappear = 10; // ������܂ł̂������
    private int currentRubs = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Brush"))
        {
            currentRubs++;
            AudioManager.Instance.PlaySE("Brush");//���Đ�
            Debug.Log($"������ꂽ�I���̉�: {currentRubs}");

            // �傫��������������
            float scaleFactor = Mathf.Lerp(1f, 0f, (float)currentRubs / rubsToDisappear);
            // DOTween�ŃX�P�[�����A�j���[�V�����i0.1�b�����āj
            transform.DOScale(Vector3.one * scaleFactor, 0.1f);
            

            if (currentRubs >= rubsToDisappear)
            {
                Debug.Log("���ꂪ�������I");
                Destroy(gameObject);
            }
        }
    }
}
