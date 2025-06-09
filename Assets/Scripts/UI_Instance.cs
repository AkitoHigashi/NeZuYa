using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Inspector�Ŏw�肷��v���n�u
    public GameObject itemPrefab;

    // �����ʒu�̊�i�C�Ӂj
    public Transform spawnPoint;

    // �{�^������Ăяo���֐�
    public void SpawnItem()
    {
        if (itemPrefab != null)
        {
            
            Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("ItemPrefab ���ݒ肳��Ă��܂���I");
        }
    }
}
