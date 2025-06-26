using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class Generator_chara : MonoBehaviour
{

    //[SerializeField] GameObject[] _characharacterPrefabs;//��������L����
    private List<GameObject> characterList = new List<GameObject>(); // �Q�[�����Ɉ����L�����N�^�[�̃��X�g
    private List<string> spawnedTags = new List<string>();
    [SerializeField] private GameObject[] FirstCharacters; // �ŏ��ɓo�^���Ă����L�����N�^�[�̃v���n�u�z��
    [Header("���X�ꏊ")]
    [SerializeField] Transform _SpawnPoint;

    private void Start()
    {
        // �ŏ��̃L�����N�^�[���������X�g�ɒǉ�
        characterList.AddRange(FirstCharacters);

        // �Q�[���J�n����1�̃����_���Ő������Ă݂�
        Invoke(nameof(SpawnRandomCharacter),1.5f);
    }

    // �L�����N�^�[���X�g���烉���_����1�̑I��Ő������郁�\�b�h
    public void SpawnRandomCharacter()
    {
        // ���o���L�������X�g�����
        List<GameObject> availableCharacters = new List<GameObject>();

        foreach (GameObject prefab in FirstCharacters)
        {
            if (!spawnedTags.Contains(prefab.tag))
            {
                availableCharacters.Add(prefab);
            }
        }

        if (availableCharacters.Count == 0)
        {
            Debug.LogWarning("���ׂẴL�������o���ς݂ł��I");
            return;
        }
        // �����_����1�̑I��ŏo��
        int index = Random.Range(0, availableCharacters.Count);
        GameObject selected = availableCharacters[index];
        // ����
        GameObject clone = Instantiate(selected, _SpawnPoint.position, Quaternion.identity);
        AudioManager.Instance.PlaySE("Appear");//���Đ�
        spawnedTags.Add(clone.tag);//�o���ς݃��X�g�ɒǉ��B
        Debug.Log("�o���L�����F" + selected.name);

    }
    public void AddCharacter(GameObject newCharacter)//�L��������p�̃��\�b�h
    {
        if (!characterList.Contains(newCharacter))
        {
            characterList.Add(newCharacter);
            Debug.Log("�L������ǉ����܂����F" + newCharacter.name);
        }
    }
    public void RemoveSpawnedCharacter(string _tag)
    {
        if (spawnedTags.Contains(_tag))
        {
            spawnedTags.Remove(_tag);
            Debug.Log("�^�O�u" + _tag + "�v�̃L�������ďo���\�ɂ��܂����B");
        }
    }

}
