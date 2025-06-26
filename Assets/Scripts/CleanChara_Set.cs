using UnityEngine;

public class CleanChara_Set : MonoBehaviour
{
    [SerializeField] private GameObject Nezumi_C_Prefab;
    [SerializeField] private GameObject Nezuking_C_Prefab;
    [SerializeField] private GameObject Women_C_Prefab;
    [SerializeField] private Transform _SetPos;
    public void CleanModeSet(GameObject other)
    {
        if (other.CompareTag("Nezumi"))
        {
            if (Nezumi_C_Prefab != null)
            {
                Instantiate(Nezumi_C_Prefab, _SetPos.position, Quaternion.identity);
                Debug.Log("Nezumiに対応したオブジェクトを生成しました");
            }
        }
        if (other.CompareTag("Nezuking"))
        {
            if (Nezuking_C_Prefab != null)
            {
                Instantiate(Nezuking_C_Prefab, _SetPos.position, Quaternion.identity);
                Debug.Log("Nezukingに対応したオブジェクトを生成しました");
            }
        }
        if (other.CompareTag("Women"))
        {
            if (Women_C_Prefab != null)
            {
                Instantiate(Women_C_Prefab, _SetPos.position, Quaternion.identity);
                Debug.Log("Nezukingに対応したオブジェクトを生成しました");
            }
        }
    }
}
