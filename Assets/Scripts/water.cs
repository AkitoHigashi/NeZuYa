using UnityEngine;

public class WatorDryScript : MonoBehaviour
{
    public string targetTag = "Dryer";       // �ΏۂƂȂ�^�O
    public float requiredTime = 3f;          // ������܂ł̕K�v����
    private float currentTime = 0f;          // ���݂̃J�E���g����
    private bool isDryerInside = false;      // Dryer�����ɂ��邩�ǂ���

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            isDryerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            isDryerInside = false;
            currentTime = 0f; // �o����J�E���g���Z�b�g
        }
    }

    private void Update()
    {
        if (isDryerInside)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= requiredTime)
            {
                Debug.Log("Dryer����莞�Ԓ��ɂ����̂ŁAWator�������܂��I");
                Destroy(gameObject); // �������g�iWator�j������
            }
        }
    }
}