using UnityEngine;

public class SetNezumiPos : MonoBehaviour
{
    [SerializeField] S GetS;

    private Vector2 Nezumipos;

    private void Start()
    {
        this.transform.position = GetS.EndNezumiPos;
        //指定したオブジェクトのシーンの最終位置を記録しこのオブジェジェクトの位置に上書き
    }

    private void OnDisable()
    {
        Nezumipos = this.transform.position;
        GetS.EndNezumiPos = Nezumipos;
        //このオブジェクトの位置を常にスクリプタブルに送る。
    }
}
