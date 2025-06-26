using UnityEngine;

public class UI_SpawnItem : MonoBehaviour
{

    [SerializeField] private GameObject _SoapPrefab;
    [SerializeField] private GameObject _brushPrefab;
    [SerializeField] private GameObject _towelPrefab;
    [SerializeField] private GameObject _showerPrefab;
    [SerializeField] private GameObject _HandcuffsPrefab;


    [SerializeField] private Transform[] _SpawnPoint;

    private GameObject _Item;
    private GameObject _SoapItem;
    private GameObject _brushItem;
    private GameObject _towelItem;
    private GameObject _showerItem;

    public void BrushSpawn()
    {
        if (_brushPrefab != null)
        {
            if (_Item is not null)//item����������Ă��鎞
            {
                ItemDestory();
                Debug.Log("���ɐ�������Ă��I�u�W�F�N�g�������܂���");
            }
            AudioManager.Instance.PlaySE("PushButton");
            _Item = Instantiate(_brushPrefab, _SpawnPoint[0].position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("�A�C�e���v���n�u���ݒ肳��ĂȂ�");
        }
    }
    public void SoapSpawn()
    {
        if (_SoapPrefab != null)
        {
            if (_Item is not null)//item����������Ă��鎞
            {
                ItemDestory();
                Debug.Log("���ɐ�������Ă��I�u�W�F�N�g�������܂���");
            }
            AudioManager.Instance.PlaySE("PushButton");
            _Item = Instantiate(_SoapPrefab, _SpawnPoint[1].position, Quaternion.identity);
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
            if (_Item is not null)//item����������Ă��鎞
            {
                ItemDestory();
                Debug.Log("���ɐ�������Ă��I�u�W�F�N�g�������܂���");
            }
            AudioManager.Instance.PlaySE("PushButton");
            _Item = Instantiate(_towelPrefab, _SpawnPoint[2].position, Quaternion.identity);
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
            if (_Item is not null)//item����������Ă��鎞
            {
                ItemDestory();
                Debug.Log("���ɐ�������Ă��I�u�W�F�N�g�������܂���");
            }
            AudioManager.Instance.PlaySE("PushButton");
            _Item = Instantiate(_showerPrefab, _SpawnPoint[3].position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("�A�C�e���v���n�u���ݒ肳�Ă��Ȃ�");
        }

    }
    public void HandcuffsSpawn()
    {
        ItemDestory();
        if (_HandcuffsPrefab != null)
        {
            if (_Item is not null)//item����������Ă��鎞
            {
                ItemDestory();
                Debug.Log("���ɐ�������Ă��I�u�W�F�N�g�������܂���");
            }
            AudioManager.Instance.PlaySE("Handcuffs");
            _Item = Instantiate(_HandcuffsPrefab, _SpawnPoint[4].position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("�A�C�e���v���n�u���ݒ肳�Ă��Ȃ�");
        }
    }
    private void ItemDestory()
    {
        if (_Item != null)
        {
            Destroy(_Item);
        }
    }
}
