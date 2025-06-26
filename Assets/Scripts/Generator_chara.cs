using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class Generator_chara : MonoBehaviour
{

    //[SerializeField] GameObject[] _characharacterPrefabs;//生成するキャラ
    private List<GameObject> characterList = new List<GameObject>(); // ゲーム中に扱うキャラクターのリスト
    private List<string> spawnedTags = new List<string>();
    [SerializeField] private GameObject[] FirstCharacters; // 最初に登録しておくキャラクターのプレハブ配列
    [Header("入店場所")]
    [SerializeField] Transform _SpawnPoint;

    private void Start()
    {
        // 最初のキャラクターたちをリストに追加
        characterList.AddRange(FirstCharacters);

        // ゲーム開始時に1体ランダムで生成してみる
        Invoke(nameof(SpawnRandomCharacter),1.5f);
    }

    // キャラクターリストからランダムに1体選んで生成するメソッド
    public void SpawnRandomCharacter()
    {
        // 未出現キャラリストを作る
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
            Debug.LogWarning("すべてのキャラが出現済みです！");
            return;
        }
        // ランダムに1体選んで出現
        int index = Random.Range(0, availableCharacters.Count);
        GameObject selected = availableCharacters[index];
        // 生成
        GameObject clone = Instantiate(selected, _SpawnPoint.position, Quaternion.identity);
        AudioManager.Instance.PlaySE("Appear");//音再生
        spawnedTags.Add(clone.tag);//出現済みリストに追加。
        Debug.Log("出現キャラ：" + selected.name);

    }
    public void AddCharacter(GameObject newCharacter)//キャラ解放用のメソッド
    {
        if (!characterList.Contains(newCharacter))
        {
            characterList.Add(newCharacter);
            Debug.Log("キャラを追加しました：" + newCharacter.name);
        }
    }
    public void RemoveSpawnedCharacter(string _tag)
    {
        if (spawnedTags.Contains(_tag))
        {
            spawnedTags.Remove(_tag);
            Debug.Log("タグ「" + _tag + "」のキャラを再出現可能にしました。");
        }
    }

}
