using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Inspectorで指定するプレハブ
    public GameObject itemPrefab;

    // 生成位置の基準（任意）
    public Transform spawnPoint;

    // ボタンから呼び出す関数
    public void SpawnItem()
    {
        if (itemPrefab != null)
        {
            
            Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("ItemPrefab が設定されていません！");
        }
    }
}
