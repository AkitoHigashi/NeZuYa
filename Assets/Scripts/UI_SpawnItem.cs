using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class UI_SpawnItem : MonoBehaviour
{

    [SerializeField] GameObject _SoapPrefab;
    [SerializeField] GameObject _brushPrefab;
    [SerializeField] GameObject _towelPrefab;
    [SerializeField] GameObject _showerPrefab;


    [SerializeField] private Transform _SpawnPoint;

    GameObject _Item;
    GameObject _SoapItem;
    GameObject _brushItem;
    GameObject _towelItem;
    GameObject _showerItem;

    public void BrushSpawn()
    {
        ItemDestory();
        if (_brushPrefab != null)
        {
            if (_Item == null)//Spawnitem�����鎞
            {
                _Item = Instantiate(_brushPrefab, _SpawnPoint.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("���ɐ�������Ă��܂�");
            }
        }
        else
        {
            Debug.LogWarning("�A�C�e���v���n�u���ݒ肳��ĂȂ�");
        }
    }
    public void SoapSpawn()
    {
        ItemDestory();
        if (_SoapPrefab != null)
        {
            if (_Item == null)
            {
                _Item = Instantiate(_SoapPrefab, _SpawnPoint.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("���ɐ�������Ă��܂�");
            }
        }
        else
        {
            Debug.LogWarning("�A�C�e���v���n�u���ݒ肳��Ă��܂���");
        }
    }
    public void TowelSpawn()
    {
        ItemDestory();
        if (_towelPrefab != null)
        {
            if (_Item == null)
            {
                _Item = Instantiate(_towelPrefab, _SpawnPoint.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("���ɐ�������Ă��܂�");
            }
        }
        else
        {
            Debug.LogWarning("�A�C�e���v���n�u���ݒ肳��ĂȂ�");
        }

    }
    public void ShowerSpawn()
    {
        ItemDestory();
        if (_showerPrefab != null)
        {
            if (_Item == null)
            {
                _Item = Instantiate(_showerPrefab, _SpawnPoint.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("���ɐ�������Ă��܂�");
            }
        }
        else
        {
            Debug.LogWarning("�A�C�e���v���n�u���ݒ肳�Ă��Ȃ�");
        }

    }
    private void ItemDestory()
    {
        if(_Item != null)
        {
            Destroy(_Item);
        }
    }
}
