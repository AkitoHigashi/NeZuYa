using UnityEngine;

public class SetPos : MonoBehaviour
{
    [SerializeField] S GetS;

    private Vector2 pos;

    private void Start()
    {
        this.transform.position = GetS.EndPlaypos;
        //指定したオブジェクトのシーンの最終位置を記録しこのオブジェジェクトの位置に上書き
    }
    private void Update()
    {
        pos = this.transform.position;
        GetS.EndPlaypos = pos;
        //このオブジェクトの位置を常にスクリプタブルに送る。
    }

}
