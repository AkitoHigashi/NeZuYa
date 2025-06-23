using UnityEngine;

public class SetNezumiPos : MonoBehaviour
{
    [SerializeField] CharaPosition _PositoinDate;

    private Vector2 Nezumipos;

    private void Start()
    {
        if (_PositoinDate.hasSavedPosition == true)//ポジションが記録されていれば実行
        {
        this.transform.position = _PositoinDate.EndNezumiPos;
        //指定したオブジェクトのシーンの最終位置を記録しこのオブジェジェクトの位置に上書き
        }
    }

    private void OnDisable()
    {
        Nezumipos = this.transform.position;
        _PositoinDate.EndNezumiPos = Nezumipos;
        _PositoinDate.hasSavedPosition = true;//ポジションをセーブした事を記録
        //このオブジェクトの最終位置を常にスクリプタブルに送る。
    }
}
