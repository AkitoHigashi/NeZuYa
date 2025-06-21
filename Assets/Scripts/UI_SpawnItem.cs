using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class UI_SpawnItem : MonoBehaviour
{
    [SerializeField] GameObject _brushPrefab;
    [SerializeField] GameObject _towelPrefab;
    [SerializeField] GameObject _showerPrefab;


    [SerializeField] private Transform _SpawnPoint;

    GameObject _Item;
    GameObject _brushItem;
    GameObject _towelItem;
    GameObject _showerItem;

    public void BrushSpawn()
    {
        //ItemDestory
        if (_brushPrefab != null)
        {
            if (_Item == null)//Spawnitemが或る時
            {
                _Item = Instantiate(_brushPrefab, _SpawnPoint.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("既に生成されています");
            }
        }
        else
        {
            Debug.LogWarning("アイテムプレハブが設定されてない");
        }
    }
    public void TowelItem()
    {
        if (_towelPrefab != null)
        {
            if (_Item == null)
            {
                _Item = Instantiate(_towelPrefab, _SpawnPoint.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("既に生成されています");
            }
        }
        else
        {
            Debug.LogWarning("アイテムプレハブが設定されてない");
        }

    }
    public void ShowerItem()
    {
        if (_showerPrefab != null)
        {
            if (_Item == null)
            {
                _Item = Instantiate(_showerPrefab, _SpawnPoint.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("既に生成されています");
            }
        }
        else
        {
            Debug.LogWarning("アイテムプレハブが設定さていない");
        }
        
    }
}