using System.Collections;
using UnityEngine;

public class Generator_chara : MonoBehaviour
{
    [SerializeField] GameObject[] _chara;//��������L����

    private void Start()
    {
        StartCoroutine(InstChara());
    }
    private void Update()
    {

    }
    void SpawnChara()
    {
        Instantiate(_chara[0], this.gameObject.transform.position, Quaternion.identity);
    }
    IEnumerator InstChara()
    {
        while (true)
        {
            SpawnChara();
            Debug.Log("�l�Y�~���X");
            yield return new WaitForSeconds(5f);


        }

    }
}
