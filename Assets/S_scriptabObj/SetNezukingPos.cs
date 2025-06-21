using UnityEngine;

public class SetNezukingPos : MonoBehaviour
{
    [SerializeField] S GetS;

    private Vector2 Nezukingpos;

    private void Start()
    {
        this.transform.position = GetS.EndNezukingPos;
        //指定したオブジェクトのシーンの最終位置を記録しこのオブジェジェクトの位置に上書き
    }

    private void OnDisable()
    {
        Nezukingpos = this.transform.position;
        GetS.EndNezukingPos = Nezukingpos;
        //このオブジェクトの位置を常にスクリプタブルに送る。
    }
}
